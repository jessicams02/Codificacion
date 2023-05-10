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
        public DataTable ListadoVacantes()
        {
            DataTable dt = new DataTable();

            query.Clear();
            //query.AppendLine($"EXEC sp_ListVacante @area = '{area}'");

            try
            {

                cn.Open();
            }
            catch (Exception)
            {

                throw;
            }
            finally { cn.Close(); }

            return dt;

            /*
             CREATE PROCEDURE sp_AsignaSellos @cliente varchar(MAX), @numcaja varchar(10), @fechasig smalldatetime, @perasig varchar(50), @traref varchar(20), @traped varchar(15), @color varchar(10), @sello varchar(20) output
                AS BEGIN
	                DECLARE @Nsello AS VARCHAR(MAX) = (SELECT TOP 1 numsello 'SELLO FISCAL' FROM SELLOS 
	                WHERE COLOR = @color AND fechasig IS NULL AND fechareg >= DATEADD(yy, -1, GETDATE())
	                ORDER BY Cast(Substring(numsello + '0', Patindex('%[0-9]%',numsello + '0'), len(numsello + '0')) As Int))
	
	                UPDATE Sellos SET cliente = @cliente, numcaja = @numcaja, fechasig = @fechasig, perasig = @perasig,
                    traref = @traref, traped = @traped WHERE numsello = @Nsello AND color = @color
	
	                SELECT numsello from sellos where numsello = @Nsello
                END
             */

            // código para insertar mediante sp
            /*SqlQuery.AppendLine($"declare @sello varchar(20);");
            SqlQuery.AppendLine($"EXEC sp_AsignaSellos @cliente = '{tr.Cliente}', @numcaja = '{tr.Caja}', @fechasig = '{fecha}',");
            SqlQuery.AppendLine($"@perasig = '{tr.Ejecutivo}', @traref = '{tr.Referencia}', @traped = '{tr.Pedimento}', @color = '{tr.Color}', @sello = ''");
            SqlQuery.AppendLine($"print @sello");

            SqlCommand cmd = new SqlCommand(SqlQuery.ToString(), cnn);

            try
            {
                cnn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tr.Sello = dr.GetValue(0).ToString();
                        tr.Fecha = fecha;
                    }
                }
                else
                {
                    tr.Sello = "Error";
                }
            }
            catch (Exception)
            {
                tr.Sello = "Error";
            }
            finally
            {
                cnn.Close();
            }*/
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
                respuesta = "InsVac";
            }
            catch (Exception x)
            {
                respuesta = x.Message;
            }
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
                respuesta = "UpdVac";
            }
            catch (Exception x)
            {
                respuesta = x.Message;
            }
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
            catch (Exception x)
            {
                respuesta = x.Message;
            }
            finally { cn.Close(); }

            return respuesta;
        }
        #endregion

        #region Prospecto 
        public DataTable ListadoProspectos()
        {
            DataTable dt = new DataTable();
            return dt;
        }

        public void InsertProspecto(string nombre, string correo, string fechareg)
        {
            query.Clear();
            query.AppendLine($"EXEC sp_InsertProspecto @nombre = '{nombre}', @sueldo = '{correo}', @fechareg = '{fechareg}'");
            SqlCommand cmd = new SqlCommand(query.ToString(), cn);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { cn.Close(); }
        }

        public void UpdateProspecto(int id, string nombre, string correo, string fechareg)
        {
            query.Clear();
            query.AppendLine($"EXEC sp_UpdateProspecto @id = '{id}', @nombre = '{nombre}', @correo = '{correo}', @fechareg = '{fechareg}'");
            SqlCommand cmd = new SqlCommand(query.ToString(), cn);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { cn.Close(); }
        }

        public void DeleteProspecto(int id)
        {
            query.Clear();
            query.AppendLine($"EXEC sp_DeleteProspecto @id = '{id}'");
            SqlCommand cmd = new SqlCommand(query.ToString(), cn);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { cn.Close(); }
        }
        #endregion

        #region Entrevista
        public DataTable ListadoEntrevistas()
        {
            DataTable dt = new DataTable();
            return dt;
        }

        public void InsertEntrevista(int idVac, int idPro, string fecha, string notas, Boolean reclutado)
        {
            query.Clear();
            query.AppendLine($"EXEC sp_InsertVacante @vacante = '{idVac}', @prospecto = '{idPro}', @fecha = '{fecha}', @notas = '{notas}', @reclutado = {reclutado}");
            SqlCommand cmd = new SqlCommand(query.ToString(), cn);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { cn.Close(); }
        }

        public void UpdateEntrevista(int id, int idVac, int idPro, string fecha, string notas, Boolean reclutado)
        {
            query.Clear();
            query.AppendLine($"EXEC sp_UpdateEntrevista @id = '{id}', @vacante = '{idVac}', @prospecto = '{idPro}', @fecha = '{fecha}', @notas = '{notas}', @reclutado = {reclutado}");
            SqlCommand cmd = new SqlCommand(query.ToString(), cn);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { cn.Close(); }
        }

        public void DeleteEntrevista(int id)
        {
            query.Clear();
            query.AppendLine($"EXEC sp_DeleteEntrevista @id = '{id}'");
            SqlCommand cmd = new SqlCommand(query.ToString(), cn);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { cn.Close(); }
        }
        #endregion
    }
}