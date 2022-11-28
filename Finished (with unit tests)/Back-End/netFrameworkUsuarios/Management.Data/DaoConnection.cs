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
    public class DaoConnection: Repositorio
    {
        private static volatile DaoConnection instancia;
        private static object syncRoot = new Object();

        public static DaoConnection Instance
        {
            get
            {
                if (instancia == null)
                {
                    lock (syncRoot)
                    {
                        if (instancia == null)
                            instancia = new DaoConnection();
                    }
                }
                return instancia;
            }
        }

        public void addConnection(Connection connection)
        {

            DbCommand comando = DB.GetStoredProcCommand("Sp_Conexion");
            comando.CommandTimeout = 5;
            DB.AddInParameter(comando, "@ProcId", DbType.Int32, ProcId.addConnection);
            DB.AddInParameter(comando, "@fechaConexion", DbType.DateTime, connection.fechaConexion);
            DB.AddInParameter(comando, "@IdUsuario", DbType.Int32, connection.IdUsuario);
            this.DB.ExecuteNonQuery(comando);

        }
        public long updateDisconnect(FinalConnection connection)
        {
            long retorno = -1;

            DbCommand comando = DB.GetStoredProcCommand("Sp_Conexion");
            comando.CommandTimeout = 5;
            DB.AddInParameter(comando, "@ProcId", DbType.Int32, ProcId.updateDisconnect);
            DB.AddInParameter(comando, "@fechaDesconexion", DbType.DateTime, connection.fechaDesconexion);
            DB.AddInParameter(comando, "@fechaConexion", DbType.DateTime, connection.fechaConexion);
            DB.AddInParameter(comando, "@IdUsuario", DbType.Int32, connection.IdUsuario);

            this.DB.ExecuteNonQuery(comando);
            retorno = 1;
            return retorno;
        }
        public List<FinalConnection> getLastConnection(Int32 IdUsuario)
        {
            DbCommand comando = DB.GetStoredProcCommand("Sp_Conexion");
            comando.CommandTimeout = 5;
            DB.AddInParameter(comando, "@ProcId", DbType.Int32, ProcId.getLastConnection);
            DB.AddInParameter(comando, "@IdUsuario", DbType.Int32, IdUsuario);

            DataSet dsCampos = this.DB.ExecuteDataSet(comando);

            if (dsCampos.Tables.Count > 0 && dsCampos.Tables[0].Rows.Count > 0)
            {

                var ListaSms = from row in dsCampos.Tables[0].AsEnumerable()
                               select new FinalConnection()
                               {
                                   IdUsuario = row.Field<Int32>("IdUsuario"),
                                   fechaConexion = row.Field<DateTime>("fechaConexion"),
                                   fechaDesconexion = row.Field<DateTime?>("fechaDesconexion")

                               };

                return ListaSms.ToList<FinalConnection>();
            }
            return new List<FinalConnection>();
        }
        public List<FinalConnection> getConnectionsByIdUsuario(Int32 IdUsuario)
        {
            DbCommand comando = DB.GetStoredProcCommand("Sp_Conexion");
            comando.CommandTimeout = 5;
            DB.AddInParameter(comando, "@ProcId", DbType.Int32, ProcId.getConnectionsByIdUsuario);
            DB.AddInParameter(comando, "@IdUsuario", DbType.Int32, IdUsuario);

            DataSet dsCampos = this.DB.ExecuteDataSet(comando);

            if (dsCampos.Tables.Count > 0 && dsCampos.Tables[0].Rows.Count > 0)
            {

                var ListaSms = from row in dsCampos.Tables[0].AsEnumerable()
                               select new FinalConnection()
                               {
                                   IdUsuario = row.Field<Int32>("IdUsuario"),
                                   fechaConexion = row.Field<DateTime>("fechaConexion"),
                                   fechaDesconexion = row.Field<DateTime?>("fechaDesconexion")

                               };

                return ListaSms.ToList<FinalConnection>();
            }
            return new List<FinalConnection>();
        }
        enum ProcId
        {
            addConnection = 1,
            updateDisconnect=2,
            getLastConnection=3,
            getConnectionsByIdUsuario=4

        }


    }
}
