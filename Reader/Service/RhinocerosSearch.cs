using System.ComponentModel.DataAnnotations;

namespace Reader.Service
{
    public class Search
    {
        [MinLength(3)]
        public string DepartmentName { get; set; }
        
        public string PostalCode { get; set; }
        
        public int? Population { get; set; }

        public string ConditionPopulation { get; set; }
        
    }
}