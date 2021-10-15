using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
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
                      .Where(p => p.CodePostale == PostalCode)
                      .Select(p => p);

            return query;
        } 

        public IEnumerable<ObjetDepartment> SearchDepartment(Search search)
        {   
            if (search.ConditionPopulation.Contains(">"))
            {
                var query = _departments.AsQueryable()
                      .Where(p => p.CodePostale.Contains(search.PostalCode) && p.DepartmentNom.Contains(search.DepartmentName) )
                      .Select(p => p).ToList();
                
                var query2 = query.Where(p => p.Population < search.Population).Select( p=>p );
                      return query;
            }
            else
            {
                var query = _departments.AsQueryable()
                      .Where(p => p.CodePostale.Contains(search.PostalCode) && p.DepartmentNom.Contains(search.DepartmentName) )
                      .Select(p => p).ToList();

                var query2 = query.Where(p => p.Population > search.Population).Select( p=>p );
                      return query;             
            }        
            
        }        

    }  
}
