using Management.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data
{
    public class DaoProducts : Repositorio
    {
        private static volatile DaoProducts instancia;
        private static object syncRoot = new Object();
        public static DaoProducts Instance
        {
            get
            {
                if (instancia == null)
                {
                    lock (syncRoot)
                    {
                        if (instancia == null)
                            instancia = new DaoProducts();
                    }
                }
                return instancia;
            }
        }
        public List<Product> traeCampanaLlamadaManual()
        {
            DbCommand comando = DB.GetStoredProcCommand("SP_GetProducts");
            comando.CommandTimeout = 300;
            DataSet dsCampos = this.DB.ExecuteDataSet(comando);
            if (dsCampos.Tables.Count > 0 && dsCampos.Tables[0].Rows.Count > 0)
            {

                var ListaSms = from row in dsCampos.Tables[0].AsEnumerable()
                               select new Product()
                               {
                                   id = row.Field<Int32>("Id"),
                                   name = row.Field<String>("Name"),
                                   author = row.Field<String>("Author"),
                                   isbn = row.Field<String>("Isbn"),
                                   description = row.Field<String>("Description"),
                                   photoUrl = row.Field<String>("PhotoUrl"),
                                   price = row.Field<Int64>("Price"),
                                   amount = row.Field<Int64>("Amount")
                               };

                return ListaSms.ToList<Product>();
            }
            return new List<Product>();
        }

    }
}
