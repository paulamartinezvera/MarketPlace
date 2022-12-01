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
    public class DaoUsers: Repositorio
    {
        private static volatile DaoUsers instancia;
        private static object syncRoot = new Object();
        public static DaoUsers Instance
        {
            get
            {
                if (instancia == null)
                {
                    lock (syncRoot)
                    {
                        if (instancia == null)
                            instancia = new DaoUsers();
                    }
                }
                return instancia;
            }
        }
        public List<User> login(User User)
        {
            DbCommand comando = DB.GetStoredProcCommand("SP_Login");
            comando.CommandTimeout = 100;
            DB.AddInParameter(comando, "@Username", DbType.String, User.Username);
            DB.AddInParameter(comando, "@Password", DbType.String, User.Password);
            DataSet dsCampos = this.DB.ExecuteDataSet(comando);
            if (dsCampos.Tables.Count > 0 && dsCampos.Tables[0].Rows.Count > 0)
            {

                var ListaSms = from row in dsCampos.Tables[0].AsEnumerable()
                               select new User()
                               {
                                   Id = row.Field<Int32?>("Id"),
                                   Username = row.Field<String>("Username"),
                                   Password = row.Field<String>("Password"),
                                   Name = row.Field<String>("Name")
                                
                               };

                return ListaSms.ToList<User>();
            }
            return new List<User>();
        }
    }
}
