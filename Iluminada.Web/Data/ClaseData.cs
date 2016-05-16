using Iluminada.Web.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Iluminada.Web.Data
{
    public class ClaseData:BaseData
    {
        public int Crear(Clase clase)
        {
            string spName = "sp_clase_insert";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@ColegioId", clase.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@Profesor", clase.Profesor, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@AreaId", clase.AreaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@NivelId", clase.NivelId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@GradoId", clase.GradoId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@CompetenciaLvId", clase.CompetenciaLvId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@CapacidadLvId", clase.CapacidadLvId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@MetodologiaLvId", clase.MetodologiaLvId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@TituloId", clase.TituloId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@TemaId", clase.TemaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@Contenido", clase.Contenido, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@Competencia", clase.Competencia, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@Capacidad", clase.Capacidad, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@TemaContenido", clase.TemaContenido, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@VirtudGeneralId", clase.VirtudGeneralId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@VirtudEspecificaId", clase.VirtudEspecificaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@Indicador", clase.Indicador, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add("@new_identity", SqlDbType.BigInt, 12).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.ExecuteNonQuery();
                        retVal = Convert.ToInt32(command.Parameters["@new_identity"].Value);
                        clase.ClaseId = retVal;
                    }
                    return retVal;
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
        }

        public int Actualizar(Clase clase)
        {
            string spName = "sp_clase_update";
            int retVal = 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@ClaseId", clase.ClaseId, ParameterDirection.Input, System.Data.DbType.Int64));
                        command.Parameters.Add(ObjSqlParameter("@ColegioId", clase.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@Profesor", clase.Profesor, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@AreaId", clase.AreaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@NivelId", clase.NivelId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@GradoId", clase.GradoId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@CompetenciaLvId", clase.CompetenciaLvId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@CapacidadLvId", clase.CapacidadLvId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@MetodologiaLvId", clase.MetodologiaLvId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@TituloId", clase.TituloId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@TemaId", clase.TemaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@Contenido", clase.Contenido, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@Competencia", clase.Competencia, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@Capacidad", clase.Capacidad, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@TemaContenido", clase.TemaContenido, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@VirtudGeneralId", clase.VirtudGeneralId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@VirtudEspecificaId", clase.VirtudEspecificaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@Indicador", clase.Indicador, ParameterDirection.Input, System.Data.DbType.String));
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        retVal = command.ExecuteNonQuery();
                    }
                    return retVal;
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
        }
        
        public List<Clase> Buscar(Clase claseBusqueda)
        {
            string spName = "sp_clase_search";
            var lista = new List<Clase>();
            Clase clase = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@ClaseId", claseBusqueda.ClaseId, ParameterDirection.Input, System.Data.DbType.Int64));
                        command.Parameters.Add(ObjSqlParameter("@ColegioId", claseBusqueda.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@Profesor", claseBusqueda.Profesor, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@AreaId", claseBusqueda.AreaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@NivelId", claseBusqueda.NivelId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@GradoId", claseBusqueda.GradoId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@CompetenciaLvId", claseBusqueda.CompetenciaLvId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@CapacidadLvId", claseBusqueda.CapacidadLvId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@MetodologiaLvId", claseBusqueda.MetodologiaLvId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@TituloId", claseBusqueda.TituloId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@TemaId", claseBusqueda.TemaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@Contenido", claseBusqueda.Contenido, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@Competencia", claseBusqueda.Competencia, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@Capacidad", claseBusqueda.Capacidad, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@TemaContenido", claseBusqueda.TemaContenido, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@VirtudGeneralId", claseBusqueda.VirtudGeneralId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@VirtudEspecificaId", claseBusqueda.VirtudEspecificaId, ParameterDirection.Input, System.Data.DbType.Int32));
                        command.Parameters.Add(ObjSqlParameter("@Indicador", claseBusqueda.Indicador, ParameterDirection.Input, System.Data.DbType.String));
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            clase = new Clase();
                            clase.ClaseId = dr.GetInt64(dr.GetOrdinal("ClaseId"));
                            clase.ColegioId = dr.IsDBNull(dr.GetOrdinal("ColegioId")) ? 0 : dr.GetInt32(dr.GetOrdinal("ColegioId"));
                            clase.Profesor = dr.IsDBNull(dr.GetOrdinal("Profesor")) ? "" : dr.GetString(dr.GetOrdinal("Profesor"));
                            clase.AreaId = dr.IsDBNull(dr.GetOrdinal("AreaId")) ? 0 : dr.GetInt32(dr.GetOrdinal("AreaId"));
                            clase.NivelId = dr.IsDBNull(dr.GetOrdinal("NivelId")) ? 0 : dr.GetInt32(dr.GetOrdinal("NivelId"));
                            clase.GradoId = dr.IsDBNull(dr.GetOrdinal("GradoId")) ? 0 : dr.GetInt32(dr.GetOrdinal("GradoId"));
                            clase.CompetenciaLvId = dr.IsDBNull(dr.GetOrdinal("CompetenciaLvId")) ? 0 : dr.GetInt32(dr.GetOrdinal("CompetenciaLvId"));
                            clase.CapacidadLvId = dr.IsDBNull(dr.GetOrdinal("CapacidadLvId")) ? 0 : dr.GetInt32(dr.GetOrdinal("CapacidadLvId"));
                            clase.MetodologiaLvId = dr.IsDBNull(dr.GetOrdinal("MetodologiaLvId")) ? 0 : dr.GetInt32(dr.GetOrdinal("MetodologiaLvId"));
                            clase.TituloId = dr.IsDBNull(dr.GetOrdinal("TituloId")) ? 0 : dr.GetInt32(dr.GetOrdinal("TituloId"));
                            clase.TemaId = dr.IsDBNull(dr.GetOrdinal("TemaId")) ? 0 : dr.GetInt32(dr.GetOrdinal("TemaId"));
                            clase.Contenido = dr.IsDBNull(dr.GetOrdinal("Contenido")) ? "" : dr.GetString(dr.GetOrdinal("Contenido"));
                            clase.Competencia = dr.IsDBNull(dr.GetOrdinal("Competencia")) ? "" : dr.GetString(dr.GetOrdinal("Competencia"));
                            clase.Capacidad = dr.IsDBNull(dr.GetOrdinal("Capacidad")) ? "" : dr.GetString(dr.GetOrdinal("Capacidad"));
                            clase.TemaContenido = dr.IsDBNull(dr.GetOrdinal("TemaContenido")) ? "" : dr.GetString(dr.GetOrdinal("TemaContenido"));
                            clase.VirtudGeneralId = dr.IsDBNull(dr.GetOrdinal("VirtudGeneralId")) ? 0 : dr.GetInt32(dr.GetOrdinal("VirtudGeneralId"));
                            clase.VirtudEspecificaId = dr.IsDBNull(dr.GetOrdinal("VirtudEspecificaId")) ? 0 : dr.GetInt32(dr.GetOrdinal("VirtudEspecificaId"));
                            clase.Indicador = dr.IsDBNull(dr.GetOrdinal("Indicador")) ? "" : dr.GetString(dr.GetOrdinal("Indicador"));
                            lista.Add(claseBusqueda);
                        }
                    }
                    return lista;
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
        }

        public Clase Obtener(long claseId)
        {
            string spName = "sp_clase_getById";
            Clase clase = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(ObjSqlParameter("@ClaseId", claseId, ParameterDirection.Input, System.Data.DbType.Int64));
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            clase = new Clase();
                            clase.ClaseId = dr.GetInt64(dr.GetOrdinal("ClaseId"));
                            clase.ColegioId = dr.IsDBNull(dr.GetOrdinal("ColegioId")) ? 0 : dr.GetInt32(dr.GetOrdinal("ColegioId"));
                            clase.Profesor = dr.IsDBNull(dr.GetOrdinal("Profesor")) ? "" : dr.GetString(dr.GetOrdinal("Profesor"));
                            clase.AreaId = dr.IsDBNull(dr.GetOrdinal("AreaId")) ? 0 : dr.GetInt32(dr.GetOrdinal("AreaId"));
                            clase.NivelId = dr.IsDBNull(dr.GetOrdinal("NivelId")) ? 0 : dr.GetInt32(dr.GetOrdinal("NivelId"));
                            clase.GradoId = dr.IsDBNull(dr.GetOrdinal("GradoId")) ? 0 : dr.GetInt32(dr.GetOrdinal("GradoId"));
                            clase.CompetenciaLvId = dr.IsDBNull(dr.GetOrdinal("CompetenciaLvId")) ? 0 : dr.GetInt32(dr.GetOrdinal("CompetenciaLvId"));
                            clase.CapacidadLvId = dr.IsDBNull(dr.GetOrdinal("CapacidadLvId")) ? 0 : dr.GetInt32(dr.GetOrdinal("CapacidadLvId"));
                            clase.MetodologiaLvId = dr.IsDBNull(dr.GetOrdinal("MetodologiaLvId")) ? 0 : dr.GetInt32(dr.GetOrdinal("MetodologiaLvId"));
                            clase.TituloId = dr.IsDBNull(dr.GetOrdinal("TituloId")) ? 0 : dr.GetInt32(dr.GetOrdinal("TituloId"));
                            clase.TemaId = dr.IsDBNull(dr.GetOrdinal("TemaId")) ? 0 : dr.GetInt32(dr.GetOrdinal("TemaId"));
                            clase.Contenido = dr.IsDBNull(dr.GetOrdinal("Contenido")) ? "" : dr.GetString(dr.GetOrdinal("Contenido"));
                            clase.Competencia = dr.IsDBNull(dr.GetOrdinal("Competencia")) ? "" : dr.GetString(dr.GetOrdinal("Competencia"));
                            clase.Capacidad = dr.IsDBNull(dr.GetOrdinal("Capacidad")) ? "" : dr.GetString(dr.GetOrdinal("Capacidad"));
                            clase.TemaContenido = dr.IsDBNull(dr.GetOrdinal("TemaContenido")) ? "" : dr.GetString(dr.GetOrdinal("TemaContenido"));
                            clase.VirtudGeneralId = dr.IsDBNull(dr.GetOrdinal("VirtudGeneralId")) ? 0 : dr.GetInt32(dr.GetOrdinal("VirtudGeneralId"));
                            clase.VirtudEspecificaId = dr.IsDBNull(dr.GetOrdinal("VirtudEspecificaId")) ? 0 : dr.GetInt32(dr.GetOrdinal("VirtudEspecificaId"));
                            clase.Indicador = dr.IsDBNull(dr.GetOrdinal("Indicador")) ? "" : dr.GetString(dr.GetOrdinal("Indicador"));
                        }
                    }
                    return clase;
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
        }

    }
}