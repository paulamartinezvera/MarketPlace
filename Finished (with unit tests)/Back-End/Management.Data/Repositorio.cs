using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data
{
    public class Repositorio
    {
        public Database DB;

        public Repositorio()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            DB = factory.Create("TimeManagement");
        }
       
    }
}
