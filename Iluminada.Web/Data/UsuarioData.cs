using Iluminada.Web.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Iluminada.Web.Data
{
    public class UsuarioData : BaseData
    {
        public List<Usuario> List(int colegioId)
        {

            string spName = "sp_usuario_lstByColegio";
            var lista = new List<Usuario>();
            Usuario usuario = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(ObjSqlParameter("@ColegioId", colegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            usuario = new Usuario();
                            usuario.UsuarioId = dr.GetInt32(dr.GetOrdinal("UsuarioId"));
                            usuario.Codigo = dr.GetString(dr.GetOrdinal("Usuario"));
                            usuario.Nombre = dr.IsDBNull(dr.GetOrdinal("Nombres")) ? "" : dr.GetString(dr.GetOrdinal("Nombres"));
                            usuario.ApellidoMaterno = dr.IsDBNull(dr.GetOrdinal("Apematerno")) ? "" : dr.GetString(dr.GetOrdinal("Apematerno"));
                            usuario.ApellidoPaterno = dr.IsDBNull(dr.GetOrdinal("Apepaterno")) ? "" : dr.GetString(dr.GetOrdinal("Apepaterno"));
                            usuario.Correo = dr.IsDBNull(dr.GetOrdinal("Correo")) ? "" : dr.GetString(dr.GetOrdinal("Correo"));
                            usuario.ColegioId = dr.IsDBNull(dr.GetOrdinal("ColegioId")) ? 0 : dr.GetInt32(dr.GetOrdinal("ColegioId"));
                            usuario.Estado = dr.IsDBNull(dr.GetOrdinal("EsActivo")) ? false : dr.GetBoolean(dr.GetOrdinal("EsActivo"));
                            usuario.Colegio = dr.IsDBNull(dr.GetOrdinal("Colegio")) ? "" : dr.GetString(dr.GetOrdinal("Colegio"));
                            lista.Add(usuario);
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

        public Usuario GetByUsuarioAndPassword(string nombreUsuario, string password)
        {

            string spName = "sp_usuario_lstByUsuarioAndPass";
            Usuario usuario = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(ObjSqlParameter("@usuario", nombreUsuario, ParameterDirection.Input, System.Data.DbType.String));
                        command.Parameters.Add(ObjSqlParameter("@pass", password, ParameterDirection.Input, System.Data.DbType.String));
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            usuario = new Usuario();
                            usuario.UsuarioId = dr.GetInt32(dr.GetOrdinal("UsuarioId"));
                            usuario.Codigo = dr.GetString(dr.GetOrdinal("Usuario"));
                            usuario.Nombre = dr.IsDBNull(dr.GetOrdinal("Nombres")) ? "" : dr.GetString(dr.GetOrdinal("Nombres"));
                            usuario.ApellidoMaterno = dr.IsDBNull(dr.GetOrdinal("Apematerno")) ? "" : dr.GetString(dr.GetOrdinal("Apematerno"));
                            usuario.ApellidoPaterno = dr.IsDBNull(dr.GetOrdinal("Apepaterno")) ? "" : dr.GetString(dr.GetOrdinal("Apepaterno"));
                            usuario.Correo = dr.IsDBNull(dr.GetOrdinal("Correo")) ? "" : dr.GetString(dr.GetOrdinal("Correo"));
                            usuario.ColegioId = dr.IsDBNull(dr.GetOrdinal("ColegioId")) ? 0 : dr.GetInt32(dr.GetOrdinal("ColegioId"));
                            usuario.Estado = dr.IsDBNull(dr.GetOrdinal("EsActivo")) ? false : dr.GetBoolean(dr.GetOrdinal("EsActivo"));
                            usuario.Colegio = dr.IsDBNull(dr.GetOrdinal("Colegio")) ? "" : dr.GetString(dr.GetOrdinal("Colegio"));
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
            return usuario;

        }

        public Usuario GetById(int usuarioId)
        {

            string spName = "sp_usuario_getByid";
            Usuario usuario = null;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(spName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(ObjSqlParameter("@usuario_id", usuarioId, ParameterDirection.Input, System.Data.DbType.Int32));
                        conn.Open();

                        IDataReader dr = command.ExecuteReader();

                        while (dr.Read())
                        {
                            usuario = new Usuario();
                            usuario.UsuarioId = dr.GetInt32(dr.GetOrdinal("usuario_id"));
                            usuario.Codigo = dr.GetString(dr.GetOrdinal("usuario"));
                            usuario.Nombre = dr.IsDBNull(dr.GetOrdinal("nombres")) ? "" : dr.GetString(dr.GetOrdinal("nombres"));
                            usuario.ApellidoMaterno = dr.IsDBNull(dr.GetOrdinal("apematerno")) ? "" : dr.GetString(dr.GetOrdinal("apematerno"));
                            usuario.ApellidoPaterno = dr.IsDBNull(dr.GetOrdinal("apepaterno")) ? "" : dr.GetString(dr.GetOrdinal("apepaterno"));
                            usuario.Correo = dr.IsDBNull(dr.GetOrdinal("correo")) ? "" : dr.GetString(dr.GetOrdinal("correo"));
                            usuario.ColegioId = dr.IsDBNull(dr.GetOrdinal("colegio_id")) ? 0 : dr.GetInt32(dr.GetOrdinal("colegio_id"));
                            usuario.Estado = dr.IsDBNull(dr.GetOrdinal("estado")) ? false : dr.GetBoolean(dr.GetOrdinal("estado"));
                            usuario.Colegio = dr.IsDBNull(dr.GetOrdinal("colegio")) ? "" : dr.GetString(dr.GetOrdinal("colegio"));
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
            return usuario;

        }

        public int Insert(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {

                string spName = "clase.sp_usuario_insert";
                int retVal = 0;

                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@usuario", usuario.Codigo, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@nombres", usuario.Nombre, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@apematerno", usuario.ApellidoMaterno, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@apepaterno", usuario.ApellidoPaterno, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@pass", usuario.Password, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@correo", usuario.Correo, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@colegio_id", usuario.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@estado", usuario.Estado, ParameterDirection.Input, System.Data.DbType.Boolean));
                    command.Parameters.Add("@new_identity", SqlDbType.Int, 12).Direction = ParameterDirection.Output;
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    command.ExecuteNonQuery();
                    retVal = Convert.ToInt32(command.Parameters["@new_identity"].Value);
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

        public int Update(Usuario usuario)
        {

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {

                string spName = "clase.sp_usuario_update";
                int retVal = 0;


                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@usuario_id", usuario.UsuarioId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@usuario", usuario.Codigo, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@nombres", usuario.Nombre, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@apematerno", usuario.ApellidoMaterno, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@apepaterno", usuario.ApellidoPaterno, ParameterDirection.Input, System.Data.DbType.String));
                    //command.Parameters.Add(ObjSqlParameter("@pass", AreaEntity., ParameterDirection.Input, System.Data.DbType.String))
                    command.Parameters.Add(ObjSqlParameter("@correo", usuario.Correo, ParameterDirection.Input, System.Data.DbType.String));
                    command.Parameters.Add(ObjSqlParameter("@colegio_id", usuario.ColegioId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@estado", usuario.Estado, ParameterDirection.Input, System.Data.DbType.Boolean));
                    conn.Open();
                    retVal = command.ExecuteNonQuery();
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

        public int UpdatePassword(int usuarioId, string password)
        {
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {

                string spName = "sp_usuario_update_clave";
                int retVal = 0;


                try
                {
                    SqlCommand command = new SqlCommand(spName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(ObjSqlParameter("@usuario_id", usuarioId, ParameterDirection.Input, System.Data.DbType.Int32));
                    command.Parameters.Add(ObjSqlParameter("@pass", password, ParameterDirection.Input, System.Data.DbType.String));
                    conn.Open();
                    retVal = command.ExecuteNonQuery();
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
    }

}