using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Reader.Repository;
using Reader.Service;


namespace Reader.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RhinocerosController : ControllerBase
    {
        private readonly RhinocerosService _departmentService;

        public RhinocerosController(RhinocerosService rhinocerosService)
        {
            _departmentService = rhinocerosService;
        }

        [HttpGet]                                                   // https://localhost:5001/Rhinoceros/
        public ActionResult<List<ObjetDepartment>> Get() =>
            _departmentService.Get();  
            


        [HttpGet("{id:length(24)}", Name = "GetDepartmentByID")]    // https://localhost:5001/Rhinoceros/6162d1050f4cf766959653bc
        public ActionResult<ObjetDepartment> GetDepartmentsById(string id)
        {
            var NomDepartmentbyId = _departmentService.GetDepartmentsById(id);

            if (NomDepartmentbyId == null)
            {
                return NotFound();
            }

            return NomDepartmentbyId;
        }

        [HttpGet]                                                   // https://localhost:5001/Rhinoceros/Gironde
        [Route("{name}")]
        public IEnumerable<ObjetDepartment> GetDepartmentsByName(string name)
        {
            var NomDepartmentbyName = _departmentService.GetDepartmentsByName(name);
            return NomDepartmentbyName;
        }


        [HttpGet("GetDepartmentByPostalCode")]                      // https://localhost:5001/Rhinoceros/GetDepartmentByPostalCode?PostalCode=32
        public IEnumerable<ObjetDepartment> GetDepartmentsByPostalCode(string PostalCode)
        {
            var NomDepartmentbyPostalCode = _departmentService.GetDepartmentsByPostalCode(PostalCode);
            return NomDepartmentbyPostalCode;
        }


        [HttpPost("search")]                                        // curl -X POST "https://localhost:5001/Rhinoceros/search" -H  "accept: text/plain" -H  "Content-Type: application/json-patch+json" -d "{\"nom\":\"A\",\"nombre\":0,\"codePostal\":\"3\"}"
        public IEnumerable<ObjetDepartment>  Rechercher(Search Search)
        {
            var SearchDepartment =  _departmentService.SearchDepartment(Search); 
            return SearchDepartment; 
        }
        

    }    
}