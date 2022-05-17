using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolucionCacao.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Http;
using Newtonsoft.Json;

namespace SolucionCacao.Controllers
{
    [Authorize]
    public class ClimasController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        Climas clima = new Climas();

        public ClimasController ()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = 
                (sender, cert, chain, sslPolicyErrors) => {
                    return true;
                };
        }

        public IActionResult Index()
        {
            return View();
        }      

        public async Task<IActionResult> climaResult(string ciudad)
        {
            using(var httpClient = new HttpClient(_clientHandler))
            {
                try{
                    using(var response = 
                    await httpClient
                        .GetAsync("https://localhost:44330/api/Climas/"+ciudad))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        clima  = JsonConvert.DeserializeObject<Climas>(apiResponse);
                    }
                }
                catch (Exception ex){
                    return View("Error");
                }
                
            }
            if(clima == null){
                Response.StatusCode = 404;
                return View("cityNotFound", ciudad);
            }
            return View(clima);
        }
    }
}