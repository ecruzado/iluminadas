using Iluminada.Web.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Iluminada.Web.Data
{
    public class TablaData : BaseData
    {
        public List<Tabla> ListPorReferencia(string nombreTabla, int? tablaPadreId = null)
        {

            string spName = "sp_tabla_list";
            var lista = new List<Tabla>();
            Tabla tabla = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.Parameters.Add(ObjSqlParameter("@nombreTabla", nombreTabla, ParameterDirection.Input, System.Data.DbType.String));
                        if(tablaPadreId.HasValue)
                            command.Parameters.Add(ObjSqlParameter("@tablaPadreId", tablaPadreId.Value, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            tabla = new Tabla();
                            tabla.TablaId = dr.GetInt32(dr.GetOrdinal("tablaId"));
                            tabla.Valor = dr.GetString(dr.GetOrdinal("valor"));
                            tabla.EsActivo = dr.GetBoolean(dr.GetOrdinal("esActivo"));
                            tabla.TablaPadreId = dr.IsDBNull(dr.GetOrdinal("tablaPadreId")) ? (int?)null : dr.GetInt32(dr.GetOrdinal("tablaPadreId"));
                            tabla.Valor1 = dr.IsDBNull(dr.GetOrdinal("valor1")) ? "" : dr.GetString(dr.GetOrdinal("valor1"));
                            tabla.Valor2 = dr.IsDBNull(dr.GetOrdinal("valor2")) ? "" : dr.GetString(dr.GetOrdinal("valor2"));
                            tabla.Valor3 = dr.IsDBNull(dr.GetOrdinal("valor3")) ? "" : dr.GetString(dr.GetOrdinal("valor3"));
                            lista.Add(tabla);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
            return lista;

        }



    }
}