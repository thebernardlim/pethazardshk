using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetHazardsHKAPI.Data;
using PetHazardsHKAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetHazardsHKAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportingController : ControllerBase
    {
        private readonly HazardContext _context;

        public ReportingController(HazardContext context)
        {
            _context = context;
        }

        // GET: api/<ReportingController>
        [HttpGet]
        public IEnumerable<Reporting> Get()
        {
            try
            {
                return _context.Set<Reporting>().ToList<Reporting>().AsEnumerable<Reporting>();
            }
            catch(Exception ex)
            {
                var text = ex.InnerException;
                return null;
            }
        }

        // GET api/<ReportingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReportingController>
        [HttpPost]
        public void Post([FromBody] Reporting reporting)
        {
            try
            {
                reporting.ID = 0;   //ID is Primary Key
                _context.Reporting.Add(reporting);
                int a = _context.SaveChanges();
            }
            catch(Exception ex)
            {

            }
            
        }

        // PUT api/<ReportingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReportingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
