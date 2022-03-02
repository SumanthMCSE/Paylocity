using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SIP.Entities;
using SIP.Business.Services;
using SumanthInPaylocity.Models;

namespace SumanthInPaylocity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Sumanth Reddy M";
            return View();
        }


    }
}