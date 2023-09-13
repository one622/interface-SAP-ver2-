using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NLog;
using BookListRazor.Repository;

namespace BookListRazor.Controllers
{
    [Route("api/Farmarea")]
    [ApiController]
    public class FarmareaController : Controller
    {



        private readonly HttpContext _context;
        private IFarmareaRepository _data;
        //private readonly IHostingEnvironment _hostingEnvironment;
        public FarmareaController(
            IFarmareaRepository data)
        {
            //_hostingEnvironment = hostingEnvironment;
            //_context = httpContextAccessor.HttpContext;
            _data = data;
            _data.LoadFarmarea();
            
        }

        
        //[HttpGet]
        //public IActionResult Index()
        //{
            
        //    return View();

          
        //}

        [HttpGet]
        public IActionResult Index()
        {
            return View(_data.LoadFarmarea());


        }






    }
}
