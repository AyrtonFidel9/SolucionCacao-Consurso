using System;

using System.Collections.Generic;

using System.Diagnostics;

using System.Linq;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;

using SolucionCacao.Models;



namespace SolucionCacao.Controllers

{

    public class loginController : Controller

    {

        public IActionResult Index()

        {

            return View();

        }

    }

}