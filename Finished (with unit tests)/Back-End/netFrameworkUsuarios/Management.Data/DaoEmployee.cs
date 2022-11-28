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
    public class DaoEmployee: Repositorio
    {
        private static volatile DaoEmployee instancia;
        private static object syncRoot = new Object();

        public static DaoEmployee Instance
        {
            get
            {
                if (instancia == null)
                {
                    lock (syncRoot)
                    {
                        if (instancia == null)
                            instancia = new DaoEmployee();
                    }
                }
                return instancia;
            }
        }

        public List<Employee> getAllEmployees()
        {
            DbCommand comando = DB.GetStoredProcCommand("Sp_Usuario");
            comando.CommandTimeout = 5;
            DB.AddInParameter(comando, "@ProcId", DbType.Int32, ProcId.getAllEmployees);

            DataSet dsCampos = this.DB.ExecuteDataSet(comando);

            if (dsCampos.Tables.Count > 0 && dsCampos.Tables[0].Rows.Count > 0)
            {

                var ListaSms = from row in dsCampos.Tables[0].AsEnumerable()
                               select new Employee()
                               {
                                   id=row.Field<Int32>("Id"),
                                   nombre =row.Field<String>("Nombre"),
                                   telefono = row.Field<long?>("Telefono"),
                                   activo = row.Field<Int32>("Activo"),
                                   usuario = row.Field<String>("Usuario"),
                                   password = row.Field<String>("Password"),
                                   cedula = row.Field<long?>("Cedula"),
                                   idRol = row.Field<Int32?>("idRol"),
                                   campaign = row.Field<string>("campaign")
                               };

                return ListaSms.ToList<Employee>();
            }
            return new List<Employee>();
        }
        public long updateEmployeeState(ActiveEmployee activeEmployee)
        {
            long retorno = -1;

            DbCommand comando = DB.GetStoredProcCommand("Sp_Usuario");
            comando.CommandTimeout = 5;
            DB.AddInParameter(comando, "@ProcId", DbType.Int32, ProcId.updateEmployeeState);
            DB.AddInParameter(comando, "@Activo", DbType.Int32, activeEmployee.Activo);
            DB.AddInParameter(comando, "@Id", DbType.Int32, activeEmployee.Id);

            this.DB.ExecuteNonQuery(comando);
            retorno = 1;
            return retorno;
        }
        enum ProcId
        {
            getAllEmployees = 1,
            updateEmployeeState=2

        }
    }
}
