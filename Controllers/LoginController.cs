using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SolucionCacao.Models;
using SolucionCacao.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Encodings.Web;


namespace SolucionCacao.Controllers
{
    public class loginController : Controller
    {
        private readonly SignInManager<IdentityUser> gestionLogin;
        private readonly UserManager<IdentityUser> gestionUsuario;
        private readonly db_concursoContext _context;

        private readonly RoleManager<IdentityRole> gestionRol;

        public loginController(db_concursoContext context, SignInManager<IdentityUser> gestionLogin,
        UserManager<IdentityUser> gestionUsuario, RoleManager<IdentityRole> gestionRol)
        {
            _context = context;
            this.gestionLogin = gestionLogin;
            this.gestionUsuario = gestionUsuario;
            this.gestionRol = gestionRol;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Login/Index")]
        [AllowAnonymous]
        public async Task<IActionResult> Index([Bind("Usuario,Password, isPersistent")] Login login, string returnUrl)
        {
            //bool x = await gestionRol.RoleExistsAsync("Admin");
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await this.gestionUsuario.FindByNameAsync(login.Usuario);
                    var result = await gestionLogin.PasswordSignInAsync(
                        user.UserName, login.Password, isPersistent: login.isPersistent, lockoutOnFailure: true
                    );
                    if (result.Succeeded)
                    {
                        if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl) && 
                        returnUrl != "/")
                            return Redirect(returnUrl);
                        else
                            return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["mensaje"]="Compruebe si las credenciales usuario y contraseña esten correctas";
                        return View();
                    }
                        
                }
                catch
                {
                    TempData["mensaje"]="Compruebe si las credenciales usuario y contraseña están correctas";
                }
            }
            return View();
        }
        [HttpPost]
        [Route("Login/Logout")]
        [Authorize(Roles ="Admin, Tecnico, Propietario")]
        public async Task<IActionResult> Logout()
        {
            await gestionLogin.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult Registrar()
        {
            ViewData["Cargos"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Login/Registrar")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Registrar([Bind("Usuario,Cargo,Password")] RegistrarViewModel registrar)
        {
            //bool x = await gestionRol.RoleExistsAsync("Admin");
            if (ModelState.IsValid && registrar.Cargo != "Seleccione un cargo")
            {
                try
                {
                    var usuario = new IdentityUser
                    {
                        UserName = registrar.Usuario
                    };
                    var comprobar = await gestionUsuario.FindByNameAsync(registrar.Usuario);
                    if (comprobar == null)
                    {
                        var role = await gestionRol.FindByIdAsync(registrar.Cargo);
                        try{
                            var result = await gestionUsuario.CreateAsync(usuario, registrar.Password);
                            var result2 = await gestionUsuario.AddToRoleAsync(usuario, role.Name);
                            if (result.Succeeded && result2.Succeeded)
                            {
                                //await gestionLogin.SignInAsync(usuario, isPersistent: false);
                                ViewData["Cargos"] = new SelectList(_context.Roles, "Id", "Name");
                                TempData["mensaje"]="<div class='alert alert-success' role='alert'>El usuario "+registrar.Usuario+" se ha registrado correctamente </div>";
                                return View();
                            }
                            else
                            {
                                TempData["mensaje"]="<div class='alert alert-danger' role='alert'>"+result.Errors.ToString()+"</div>";
                                return View();
                            }
                        }
                        catch{
                            TempData["mensaje"]="<div class='alert alert-danger' role='alert'> Contraseña incorrecta, intente con una contraseña válida</div>";
                        }
                        
                    }
                    else
                    {
                        TempData["mensaje"]="<div class='alert alert-danger' role='alert'>Error, el usuario ya se encuentra registrado</div>";
                        return View();
                    }
                    
                }
                catch (Exception ex)
                {
                    TempData["mensaje"]="<div class='alert alert-danger' role='alert'>"+ex.Message+" </div>";
                }
            }
            else
            {
                TempData["mensaje"]="<div class='alert alert-danger' role='alert'> Datos incorrectos, asegurese de haber llenado todos los campos</div>";
            }
            
            return View();
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult CrearRoles()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Login/CrearRoles")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CrearRoles([Bind("Rol")] RolViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var role = gestionRol.FindByNameAsync(model.Rol);
                    if(role.Result!=null)
                    {
                        TempData["mensaje"]="<div class='alert alert-danger' role='alert'>Error, el rol ya existe</div>";
                        return View();
                    }

                    IdentityRole identityRole = new IdentityRole()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = model.Rol
                    };

                    IdentityResult result = await gestionRol.CreateAsync(identityRole);

                    if (result.Succeeded)
                    {
                        TempData["mensaje"]="<div class='alert alert-success' role='alert'>El rol "+identityRole.Name+" se ha insertado correctamente </div>";
                        return View();
                    }
                }
                catch (Exception ex)
                {
                    TempData["mensaje"]="<div class='alert alert-danger' role='alert'>"+ex.Message+" </div>";
                }
            }
            return View();

        }

        [HttpGet]
        [Authorize]
        [Route("Login/ErrorDisp")]
        public IActionResult ErrorDisp()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        [Route("Login/dashboard")]
        public IActionResult dashboard()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        [Route("Login/BuscarUsuario")]
        public IActionResult BuscarUsuario()
        {
            return View();
        }

        [Route("Login/BuscarUsuario")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> BuscarUsuario(string usuario)
        {
           if (usuario == null)
            {
                return NotFound();
            }

            var user =  gestionUsuario.Users
                .FirstOrDefault(m => m.UserName == usuario);

            if(user==null){
                TempData["mensaje"]="<div class='alert alert-primary' role='alert'>Usuario no encontrado, intentelo otra vez.</div>";
                return View();
            }
            
            return RedirectToAction("EliminarUsuario","Login", new{@Id=user.Id,
            @Usuario = user.UserName, @Correo = user.Email,@Numero=user.PhoneNumber});
        }

        [Authorize(Roles ="Admin")]
        [Route("Login/EliminarUsuario")]
        public IActionResult EliminarUsuario(EliminarViewModel us)
        {
            return View(us);
        }

        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> EliminarUsuarioConfirmed(string id)
        {
            var user = await gestionUsuario.FindByIdAsync(id);
            var result = await gestionUsuario.DeleteAsync(user);
            if(result.Succeeded){
                TempData["mensaje"]="<div class='alert alert-success' role='alert'>Usuario "+user.UserName+" eliminado correctamente.</div>";
                return View();
            }
            else
                TempData["mensaje"]="<div class='alert alert-primary' role='alert'>Error al intentar eliminar el usuario</div>";

            return View("EliminarUsuario");
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        [Route("Login/BuscarRol")]
        public IActionResult BuscarRol()
        {
            return View();
        }

        [Route("Login/BuscarRol")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> BuscarRol(string name)
        {
           if (name == null)
            {
                TempData["mensaje"]="<div class='alert alert-danger' role='alert'>No se admiten campos vacíos</div>";
                return View();
            }

            var role =  gestionRol.Roles
                        .FirstOrDefault(m => m.Name == name);

            if(role==null){
                TempData["mensaje"]="<div class='alert alert-primary' role='alert'>El rol a buscar no existe</div>";
                return View();
            }
            return RedirectToAction("EliminarRol","Login", new {@Id=role.Id, @Name=role.Name});
        }

        [Authorize(Roles ="Admin")]
        public IActionResult EliminarRol(RolEliminarViewModel rol)
        {
            return View(rol);
        }

        [HttpPost, ActionName("DeleteRol")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> EliminarRolConfirmed(string id)
        {
            var role = await gestionRol.FindByIdAsync(id);
            var result = await gestionRol.DeleteAsync(role);
            if(result.Succeeded){
                TempData["mensaje"]="<div class='alert alert-success' role='alert'> El rol "+role.Name+" se ha eliminado correctamente. </div>";
                return View();
            }
            return View("EliminarRol");
        }
    }
}