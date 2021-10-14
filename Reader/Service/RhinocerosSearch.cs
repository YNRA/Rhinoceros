using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using Reader.Repository;
using Reader.Service;

namespace Reader.Service
{
    public class Search
    {
        public string DepartmentName { get; set; }
        
        public string PostalCode { get; set; }
        
        public int? Population { get; set; }

        public string ConditionPopulation { get; set; }
        
    }
}