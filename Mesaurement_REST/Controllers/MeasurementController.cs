using System.Collections.Generic;
using lib;
using Mesaurement_REST.DBUTil;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mesaurement_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly ManageMesaurement mgr = new ManageMesaurement();

        // GET: api/<MeasurementController>
        [HttpGet]
        public IEnumerable<Mesaurement> Get()
        {
            return mgr.GetAll();
        }
        // POST api/<MeasurementController>
        [HttpPost]
        public void Post([FromBody] Mesaurement value)
        {
            mgr.CreateMeasaurement(value);
        }
        // GET: api/Measurement/get/<id>
        [HttpGet]
        [Route("get/{id}")]
        public Mesaurement Get(int id)
        {
            return mgr.GetById(id);
        }
        // api/Measurement/delete/<id>
        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            mgr.DeleteMesurement(id);
        }
    }
}
