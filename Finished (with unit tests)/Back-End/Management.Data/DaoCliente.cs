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
    public class DaoCliente : Repositorio
    {
        private static volatile DaoCliente instancia;
        private static object syncRoot = new Object();
        public string spCliente = "SP_Cliente";
        public static DaoCliente Instance
        {
            get
            {
                if (instancia == null)
                {
                    lock (syncRoot)
                    {
                        if (instancia == null)
                            instancia = new DaoCliente();
                    }
                }
                return instancia;
            }
        }
        public long insertaMetas(Metas meta)
        {
            long retorno = -1;

            DbCommand comando = DB.GetStoredProcCommand("SP_Dashboard");
            comando.CommandTimeout = 5;
            DB.AddInParameter(comando, "@ProcId", DbType.Int32, ProcId.insertaMetas);
            DB.AddInParameter(comando, "@NumeroVentasDia", DbType.String, meta.NumeroVentasDia);
            DB.AddInParameter(comando, "@NumeroVentasMes", DbType.String, meta.NumeroVentasMes);
            DB.AddInParameter(comando, "@Mes", DbType.String, meta.Mes);
            DB.AddInParameter(comando, "@YearValue", DbType.String, meta.YearValue);
            DB.AddInParameter(comando, "@Campaign", DbType.String, meta.Campaign);
            this.DB.ExecuteNonQuery(comando);
            retorno = 1;
            return retorno;
        }
        enum ProcId
        {
            traeVentasTotales = 1,
            traeSkills = 2,
            traeEstadosVenta = 3,
            traeVentasSkillEstado = 4,
            traeVentasTotalesPorSkill = 5,
            traeVentasTotalesMensual = 6,
            traeVentasTotalesMensualSkill = 7,
            traeMetas = 8,
            traeCampaigns = 9,
            insertaMetas = 10,
            actualizaMetas = 11,
            puedenUsarManejoMetas = 12,
            traeMetasMes = 13,
            traeNumeroVentasMes = 14,
            traeNumeroVentasDia = 15,
            traeNumeroVentasMesCampaigns = 16,
            cantidadVentasMesCampaign = 17,
            traeNumeroVentasDiaCampaigns = 18,
            cantidadVentasDiaCampaign = 19
        }
    }
}
}
