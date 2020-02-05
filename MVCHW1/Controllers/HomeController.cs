using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCHW1.Models;

namespace MVCHW1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Process(Calculator calculator)
        {

            if (calculator.Concat != null)
            {
                calculator.Field += calculator.Concat;
            }
            else if (calculator.ClearAll != null)
            {
                calculator.Field = "";
            }
            else if (calculator.Clear != null)
            {
                calculator.Field = calculator.Field.Substring(0, calculator.Field.Length - 1);
            }
            else if (calculator.Calculate != null)
            {
                calculator.Field = new DataTable().Compute(calculator.Field, null).ToString();
            }
            else if (calculator.Sign != null)
            {
                calculator.Field = "-" + calculator.Field;
            }

            return View("Index", calculator);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
