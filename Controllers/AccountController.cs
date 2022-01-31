using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleAPI.Models;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SampleDBContext _context;
        public AccountController(SampleDBContext context)
        {
            _context=context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Country>> Get()
        {
           return _context.Countries.ToList();
        }
    }
}