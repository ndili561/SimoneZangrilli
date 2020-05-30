using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimoneZangrilli.Models;

namespace SimoneZangrilli.Controllers
{
    public class HomeController : Controller
    {
        public readonly SimoneZangrilli.SMTP.IEmailSender emailSender;

        public HomeController(SimoneZangrilli.SMTP.IEmailSender email)
        {
            emailSender = email;
        }
        public IActionResult Index(bool? wasRedirected)
        {
            if (wasRedirected != null)
            {
                TempData["displayModal"]="showmodal";
            }
            return View();
        }

        public ActionResult Post(ContactInfo info)
        {
            //await emailSender.SendEmailAsync("dilillo.nico@gmail.com","Test","hello");
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("Index");
            //}
            //ViewBag.
            return this.RedirectToAction("Index", new { wasRedirected = true });
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
