using Microsoft.AspNetCore.Mvc;
using MVCBasic.Models;

namespace MVCBasic.Controllers
{
    
        public class DoctorController : Controller
        {
            [HttpGet]
            public IActionResult FeverCheck()
            {
                return View();
            }


            [HttpPost]
            public IActionResult FeverCheck(string temp)
            {


                try
                {
                    ViewBag.Msg = FeverHelper.Diagnose(temp);
                    return View();
                }
                catch
                {
                    return View();
                }
            }
        }
 }

