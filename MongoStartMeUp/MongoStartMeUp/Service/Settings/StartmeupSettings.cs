using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoStartMeUp.Service.Settings
{
    public class StartmeUpSettings : IStartmeUpSettings
    {
        public string EmployeesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IStartmeUpSettings
    {
        public string EmployeesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
