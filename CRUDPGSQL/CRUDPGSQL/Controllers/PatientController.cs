using CRUDPGSQL.DataAccess;
using CRUDPGSQL.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CRUDPGSQL.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public PatientController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return _dataAccessProvider.GetPatientRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Patient patient)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                patient.id = obj.ToString();
                _dataAccessProvider.AddPatientRecord(patient);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Patient Details(string id)
        {
            return _dataAccessProvider.GetPatientSingleRecord(id);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id , [FromBody] Patient patient)
        {
            if (ModelState.IsValid)
            {
                patient.id = id;
                _dataAccessProvider.UpdatePatientRecord(patient);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(string id)
        {
            var data = _dataAccessProvider.GetPatientSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeletePatientRecord(id);
            return Ok();
        }
    }
}
