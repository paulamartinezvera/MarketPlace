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
    public class DaoClientes : Repositorio
    {
        private static volatile DaoClientes instancia;
        private static object syncRoot = new Object();
        public string spClientes = "SP_Clientes";
        public static DaoClientes Instance
        {
            get
            {
                if (instancia == null)
                {
                    lock (syncRoot)
                    {
                        if (instancia == null)
                            instancia = new DaoClientes();
                    }
                }
                return instancia;
            }
        }
        public List<Clientes> traeClientes(FiltroCliente filtroCliente, long idCliente)
        {
            DbCommand comando = DB.GetStoredProcCommand("SP_BuscaClientes");
            comando.CommandTimeout = 300;
            if (filtroCliente.Nombres == null)
            {
                DB.AddInParameter(comando, "@Nombres", DbType.String, "");
            }
            else
            {
                DB.AddInParameter(comando, "@Nombres", DbType.String, filtroCliente.Nombres);
            }
            if (filtroCliente.Movil == null)
            {
                DB.AddInParameter(comando, "@Movil", DbType.String, "");
            }
            else
            {
                DB.AddInParameter(comando, "@Movil", DbType.String, filtroCliente.Movil);
            }
            DB.AddInParameter(comando, "@IdCliente", DbType.Int32, Convert.ToInt32(idCliente));
            DataSet dsCampos = this.DB.ExecuteDataSet(comando);
            if (dsCampos.Tables.Count > 0 && dsCampos.Tables[0].Rows.Count > 0)
            {

                var ListaSms = from row in dsCampos.Tables[0].AsEnumerable()
                               select new Clientes()
                               {
                                   ID = row.Field<String>("ID"),
                                   SKILL = row.Field<String>("SKILL"),
                                   NOMBRE_CLIENTE = row.Field<String>("NOMBRE_CLIENTE"),
                                   IDENTIFICACION = row.Field<String>("IDENTIFICACION"),
                                   REGION_UBICACION = row.Field<String>("REGION_UBICACION"),
                                   CALLING_NUMBER = row.Field<String>("CALLING_NUMBER"),
                                   MES = row.Field<String>("MES"),
                                   ANIO = row.Field<String>("ANIO"),
                                   TELEFONO_1 = row.Field<String>("TELEFONO_1"),
                                   TELEFONO_2 = row.Field<String>("TELEFONO_2"),
                                   TELEFONO_3 = row.Field<String>("TELEFONO_3"),
                                   CELULAR_1 = row.Field<String>("CELULAR_1"),
                                   CELULAR_2 = row.Field<String>("CELULAR_2"),
                                   CELULAR_3 = row.Field<String>("CELULAR_3"),
                                   TEL1_HOG = row.Field<String>("TEL1_HOG"),
                                   TEL2_HOG = row.Field<String>("TEL2_HOG")

                               };

                return ListaSms.ToList<Clientes>();
            }
            return new List<Clientes>();
        }
        public List<Valores> traeCampanaLlamadaManual()
        {
            DbCommand comando = DB.GetStoredProcCommand(spClientes);
            comando.CommandTimeout = 300;
            DB.AddInParameter(comando, "@ProcId", DbType.Int32, ProcId.traeCampanaLlamadaManual);
            DataSet dsCampos = this.DB.ExecuteDataSet(comando);
            if (dsCampos.Tables.Count > 0 && dsCampos.Tables[0].Rows.Count > 0)
            {

                var ListaSms = from row in dsCampos.Tables[0].AsEnumerable()
                               select new Valores()
                               {
                                   Id = row.Field<Int32>("Id"),
                                   Valor = row.Field<String>("Valor")
                               };

                return ListaSms.ToList<Valores>();
            }
            return new List<Valores>();
        }
        enum ProcId
        {
            traeCampanaLlamadaManual = 1
        }
    }
}
