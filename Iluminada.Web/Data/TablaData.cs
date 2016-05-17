using Iluminada.Web.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Iluminada.Web.Data
{
    public class TablaData : BaseData
    {
        public List<Tabla> ListPorReferencia(string nombreTabla, int? codigoPadre = null)
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
                        command.Parameters.Add(ObjSqlParameter("@NombreTabla", nombreTabla, ParameterDirection.Input, System.Data.DbType.String));
                        if(codigoPadre.HasValue)
                            command.Parameters.Add(ObjSqlParameter("@CodigoPadre", codigoPadre.Value, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            tabla = new Tabla();
                            tabla.Codigo = dr.GetInt32(dr.GetOrdinal("Codigo"));
                            tabla.Valor = dr.GetString(dr.GetOrdinal("Valor"));
                            tabla.EsActivo = dr.GetBoolean(dr.GetOrdinal("EsActivo"));
                            tabla.CodigoPadre = dr.IsDBNull(dr.GetOrdinal("CodigoPadre")) ? (int?)null : dr.GetInt32(dr.GetOrdinal("CodigoPadre"));
                            tabla.Valor1 = dr.IsDBNull(dr.GetOrdinal("Valor1")) ? "" : dr.GetString(dr.GetOrdinal("Valor1"));
                            tabla.Valor2 = dr.IsDBNull(dr.GetOrdinal("Valor2")) ? "" : dr.GetString(dr.GetOrdinal("Valor2"));
                            tabla.Valor3 = dr.IsDBNull(dr.GetOrdinal("Valor3")) ? "" : dr.GetString(dr.GetOrdinal("Valor3"));
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