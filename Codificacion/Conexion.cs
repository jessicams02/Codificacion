using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Codificacion
{
    public class Conexion
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["entrevista"].ToString());
        StringBuilder query = new StringBuilder();

        #region Vacantes
        public DataTable ListadoVacantes(int id)
        {
            DataTable dt = new DataTable();

            query.Clear();
            query.AppendLine($"EXEC sp_ListVacantes @id = '{id}'");

            try
            {
                SqlCommand cmd = new SqlCommand(query.ToString(), cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                dt.Load( rdr );
            }
            catch (Exception) { throw; }
            finally { cn.Close(); }

            return dt;
        }

        public string InsertVacante(string area, double sueldo, Boolean activo)
        {
            string respuesta;
            query.Clear();
            query.AppendLine($"EXEC sp_InsertVacante @area = '{area}', @sueldo = {sueldo}, @activo = {activo}");
            SqlCommand cmd = new SqlCommand(query.ToString(), cn);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                respuesta = "insVac";
            }
            catch (Exception x) { respuesta = x.Message; }
            finally { cn.Close(); }

            return respuesta;
        }

        public string UpdateVacante(int id, string area, double sueldo, Boolean activo)
        {
            string respuesta;
            query.Clear();
            query.AppendLine($"EXEC sp_UpdateVacante @id = '{id}', @area = '{area}', @sueldo = {sueldo}, @activo = {activo}");
            SqlCommand cmd = new SqlCommand(query.ToString(), cn);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                respuesta = "updVac";
            }
            catch (Exception x) { respuesta = x.Message; }
            finally { cn.Close(); }

            return respuesta;
        }

        public string DeleteVacante(int id)
        {
            string respuesta;
            query.Clear();
            query.AppendLine($"EXEC sp_DeleteVacante @id = '{id}'");
            SqlCommand cmd = new SqlCommand(query.ToString(), cn);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                respuesta = "delVac";
            }
            catch (Exception x) { respuesta = x.Message; }
            finally { cn.Close(); }

            return respuesta;
        }
        #endregion

        #region Prospecto 
        public DataTable ListadoProspectos(int id)
        {
            DataTable dt = new DataTable();

            query.Clear();
            query.AppendLine($"EXEC sp_ListProspectos @id = '{id}'");

            try
            {
                SqlCommand cmd = new SqlCommand(query.ToString(), cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                dt.Load(rdr);
            }
            catch (Exception) { throw; }
            finally { cn.Close(); }

            return dt;
        }

        public string InsertProspecto(string nombre, string correo, string fecha)
        {
            string respuesta;
            query.Clear();
            query.AppendLine($"EXEC sp_InsertProspecto @nombre = '{nombre}', @correo = '{correo}', @fecha = '{fecha}'");
            SqlCommand cmd = new SqlCommand(query.ToString(), cn);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                respuesta = "insPro";
            }
            catch (Exception x) { respuesta = x.Message; }
            finally { cn.Close(); }
            return respuesta;
        }

        public string UpdateProspecto(int id, string nombre, string correo, string fecha)
        {
            string respuesta;
            query.Clear();
            query.AppendLine($"EXEC sp_UpdateProspecto @id = '{id}', @nombre = '{nombre}', @correo = '{correo}', @fecha = '{fecha}'");
            SqlCommand cmd = new SqlCommand(query.ToString(), cn);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                respuesta = "updPro";
            }
            catch (Exception x) { respuesta = x.Message; }
            finally { cn.Close(); }
            return respuesta;
        }

        public string DeleteProspecto(int id)
        {
            string respuesta;
            query.Clear();
            query.AppendLine($"EXEC sp_DeleteProspecto @id = '{id}'");
            SqlCommand cmd = new SqlCommand(query.ToString(), cn);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                respuesta = "delPro";
            }
            catch (Exception x) { respuesta = x.Message; }
            finally { cn.Close(); }
            return respuesta;
        }
        #endregion

        #region Entrevista
        public DataTable ListadoEntrevistas(int id)
        {
            DataTable dt = new DataTable();

            query.Clear();
            query.AppendLine($"EXEC sp_ListEntrevistas @id = '{id}'");

            try
            {
                SqlCommand cmd = new SqlCommand(query.ToString(), cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                dt.Load(rdr);
            }
            catch (Exception) { throw; }
            finally { cn.Close(); }

            return dt;
        }

        public string InsertEntrevista(int idVac, int idPro, string fecha, string notas, Boolean reclutado)
        {
            string respuesta;
            query.Clear();
            query.AppendLine($"EXEC sp_InsertEntrevista @vacante = '{idVac}', @prospecto = '{idPro}', @fecha = '{fecha}', @notas = '{notas}', @reclutado = {reclutado}");
            SqlCommand cmd = new SqlCommand(query.ToString(), cn);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                respuesta = "insEnt";
            }
            catch (Exception x) { respuesta = x.Message; }
            finally { cn.Close(); }
            return respuesta;
        }

        public string UpdateEntrevista(int id, int idVac, int idPro, string fecha, string notas, Boolean reclutado)
        {
            string respuesta;
            query.Clear();
            query.AppendLine($"EXEC sp_UpdateEntrevista @id = '{id}', @vacante = '{idVac}', @prospecto = '{idPro}', @fecha = '{fecha}', @notas = '{notas}', @reclutado = {reclutado}");
            SqlCommand cmd = new SqlCommand(query.ToString(), cn);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                respuesta = "updEnt";
            }
            catch (Exception x) { respuesta = x.Message; }
            finally { cn.Close(); }
            return respuesta;
        }

        public string DeleteEntrevista(int id)
        {
            string respuesta;
            query.Clear();
            query.AppendLine($"EXEC sp_DeleteEntrevista @id = '{id}'");
            SqlCommand cmd = new SqlCommand(query.ToString(), cn);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                respuesta = "delEnt";
            }
            catch (Exception x) { respuesta = x.Message; }
            finally { cn.Close(); }
            return respuesta;
        }
        #endregion
    }
}