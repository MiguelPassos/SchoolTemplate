using Microsoft.AspNetCore.Mvc;
using SchoolBusiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolTemplate.Controllers
{
    public class CalendarController : BaseController
    {
        public CalendarController(IBaseBusiness baseBusiness) : base(baseBusiness)
        {
        }

        [HttpGet]
        public IActionResult Event(int id)
        {
            return View();
        }
    }
}
