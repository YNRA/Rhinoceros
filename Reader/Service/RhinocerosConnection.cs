using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using Reader.Repository;

namespace Reader.Service
{
    public class RhinocerosService
    {
        private readonly IMongoCollection<ObjetDepartment> _departments;

        public RhinocerosService(IRhinocerosDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _departments = database.GetCollection<ObjetDepartment>(settings.CollectionName);
        }

        public List<ObjetDepartment> Get() =>
            _departments.Find(ObjetDepartment => true).ToList();


        public ObjetDepartment GetDepartmentsById(string id) =>
            _departments.Find<ObjetDepartment>(ObjetDepartment => ObjetDepartment.Id == id).FirstOrDefault();            


        public IEnumerable<ObjetDepartment> GetDepartmentsByName(string name)
        {
            var query = _departments.AsQueryable()
                      .Where(p => p.DepartmentNom == name)
                      .Select(p => p);

            return query;
        } 

        public IEnumerable<ObjetDepartment> GetDepartmentsByPostalCode(string PostalCode)
        {
            var query = _departments.AsQueryable()
                      .Where(p => p.Code_Postale == PostalCode)
                      .Select(p => p);

            return query;
        } 

        public IEnumerable<ObjetDepartment> SearchDepartment(Search search)
        {   
            
            if (search.DepartmentName.Length < 3 | search.PostalCode.Length > 3)
            {
                throw new Exception("La recherche est invalide");
            }
            else
            {        
            var query = _departments.AsQueryable()
                      .Where(p => p.Code_Postale.Contains(search.PostalCode) && p.DepartmentNom.Contains(search.DepartmentName) )
                      .Select(p => p);

            return query;
            }
        }        

    }  
}


            // var query = _departments.AsQueryable()
            //           .Where(p => p.Code_Postale.Contains(search.PostalCode) && p.DepartmentNom.Contains(search.DepartmentName) && (p.Population > search.Population)  )
            //           .Select(p => p);
