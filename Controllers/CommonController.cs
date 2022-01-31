using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SampleAPI.Models;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly SampleDBContext _context;
        public CommonController(SampleDBContext context)
        {
            _context = context;
        }


        [Route("countrylist")]
        [HttpGet]
        public List<SelectListItem> Countries()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            var countries = _context.Countries.ToList();
            foreach (var item in countries)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Value = item.country_code;
                selectListItem.Text = item.name;
                lst.Add(selectListItem);
            }

            return lst;
        }

        [Route("statelist")]
        [HttpPost]
        public List<SelectListItem> States([FromForm] State model)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            var states = _context.States.Where(x=>x.country_code == model.country_code).ToList();
            foreach (var item in states)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Value = item.state_code;
                selectListItem.Text = item.name;
                lst.Add(selectListItem);
            }

            return lst;
        }

        
        [Route("citylist")]
        [HttpPost]
        public List<SelectListItem> Cities([FromForm] City model)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            var cities = _context.Cities.Where(x => x.country_code == model.country_code && x.state_code== model.state_code).ToList();
            foreach (var item in cities)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Value = item.city_code;
                selectListItem.Text = item.name;
                lst.Add(selectListItem);
            }

           return lst;
        }
    }
}