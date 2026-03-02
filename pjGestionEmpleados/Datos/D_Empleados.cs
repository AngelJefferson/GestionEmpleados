using pjGestionEmpleados.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjGestionEmpleados.Datos
{
    public class D_Empleados
    {
        public DataTable Listar_Empleados(string cBusqueda)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            { 
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_LISTAR_EMPLEADOS", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@cBusqueda", SqlDbType.VarChar).Value = cBusqueda;
                SqlCon.Open();

                resultado = Comando.ExecuteReader();
                tabla.Load(resultado);

                return tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
                
            }
        }


        public string Guardar_Empleado(E_Empleado Empleado) 
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_GUARDAR_EMPLEADOS", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@cNombre", SqlDbType.VarChar).Value = Empleado.Nombre_Empleado;
                Comando.Parameters.Add("@cDireccion", SqlDbType.VarChar).Value = Empleado.Direccion_Empleado;
                Comando.Parameters.Add("@dFechaNacimiento", SqlDbType.Date).Value = Empleado.Fecha_Nacimiento_Empleado;
                Comando.Parameters.Add("@cTelefono", SqlDbType.VarChar).Value = Empleado.Telefono;
                Comando.Parameters.Add("@nSalario", SqlDbType.Money).Value = Empleado.Salario;
                Comando.Parameters.Add("@nIdDepartamento", SqlDbType.Int).Value = Empleado.ID_Departamento;
                Comando.Parameters.Add("@cIdCargo", SqlDbType.Int).Value = Empleado.ID_Cargo;

                SqlCon.Open();

                respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "Los Datos No se Pudieron Registrar";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return respuesta;
        }

        public string Actualizar_Empleado(E_Empleado Empleado)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_ACTUALIZAR_EMPLEADOS", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@nIdEmpleado", SqlDbType.Int).Value = Empleado.ID_Empleado;
                Comando.Parameters.Add("@cNombre", SqlDbType.VarChar).Value = Empleado.Nombre_Empleado;
                Comando.Parameters.Add("@cDireccion", SqlDbType.VarChar).Value = Empleado.Direccion_Empleado;
                Comando.Parameters.Add("@dFechaNacimiento", SqlDbType.Date).Value = Empleado.Fecha_Nacimiento_Empleado;
                Comando.Parameters.Add("@cTelefono", SqlDbType.VarChar).Value = Empleado.Telefono;
                Comando.Parameters.Add("@nSalario", SqlDbType.Money).Value = Empleado.Salario;
                Comando.Parameters.Add("@nIdDepartamento", SqlDbType.Int).Value = Empleado.ID_Departamento;
                Comando.Parameters.Add("@cIdCargo", SqlDbType.Int).Value = Empleado.ID_Cargo;

                SqlCon.Open();

                respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "Los Datos No se Pudieron Registrar";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return respuesta;
        }

        public string Desactivar_Empleado(int iCodigoEmpleado)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon = Conexion.crearInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("SP_DESACTIVAR_EMPLEADO", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@nIdEmpleado", SqlDbType.Int).Value = iCodigoEmpleado;
                

                SqlCon.Open();

                respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "Los Datos No se Pudieron Registrar";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return respuesta;
        }

    }

}
