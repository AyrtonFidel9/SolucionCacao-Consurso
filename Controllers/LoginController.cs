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

namespace SolucionCacao.Controllers
{
    public class loginController : Controller
    {
        private readonly SignInManager<IdentityUser> gestionLogin;
        private readonly UserManager<IdentityUser> gestionUsuario;
        private readonly db_concursoContext _context;
        public loginController(db_concursoContext context, SignInManager<IdentityUser> gestionLogin,
        UserManager<IdentityUser> gestionUsuario)
        {
            _context = context;
            this.gestionLogin = gestionLogin;
            this.gestionUsuario = gestionUsuario;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Index([Bind("Usuario,Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    /*
                    var usuario =  from log in _context.Logins
                                   where log.Usuario.Equals(login.Usuario) && log.Password.Equals(login.Password.Trim())
                                   select log.Usuario;
                    if(usuario.Count() > 0)
                    {
                        //Session["Usuario"] = usuario;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View();
                    }*/
                    /*var hasher = new PasswordHasher<IdentityUser>();
                    var user = new IdentityUser(){
                        UserName = login.Usuario,
                        PasswordHash = hasher.HashPassword(null, login.Password)
                    };
                    var password = await gestionUsuario.CheckPasswordAsync(user, login.Password);*/

                    var usuario = (from log in _context.usuarios
                                    where log.UserName.Equals(login.Usuario)
                                    select log.UserName).FirstOrDefault();
                    int cant = usuario.Count();
                    /*var user3 = await gestionUsuario.FindByLoginAsync("admin@mail.com","1234");
                    //var user = await this.gestionUsuario.FindByNameAsync(login.Usuario);
                    var user = new IdentityUser(){
                        UserName = login.Usuario
                    };
                    var result = await gestionLogin.PasswordSignInAsync(
                        user.UserName, login.Password, isPersistent: true, lockoutOnFailure: true
                    );*/
                    if (cant > 0)
                        return RedirectToAction("Index", "Home");
                    else
                        return View();
                }
                catch
                {

                }
            }
            return View();
        }
    }
}