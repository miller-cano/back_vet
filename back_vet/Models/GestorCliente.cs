using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace back_vet.Models
{
    public class GestorCliente
    {
         public List<Cliente> getCliente()
         {
            List<Cliente> lista = new List<Cliente>();
            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "cliente_all";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int idCliente = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    string apellido = dr.GetString(2).Trim();
                    string direccion = dr.GetString(3).Trim();
                    string telefono = dr.GetString(4).Trim();
                    string genero = dr.GetString(5).Trim();
                    string correo = dr.GetString(6).Trim();

                    Cliente cliente = new Cliente(idCliente, nombre, apellido, direccion, telefono, genero, correo);
                    lista.Add(cliente);
                }

                dr.Close();
                conn.Close();
            }
            return lista;
        }

        public bool addCliente(Cliente cliente)
        {
            bool res = false;
            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "cliente_add";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdCliente", cliente.idCliente);
                cmd.Parameters.AddWithValue("@Nombre", cliente.nombre);
                cmd.Parameters.AddWithValue("@Apellido", cliente.apellido);
                cmd.Parameters.AddWithValue("@Direccion", cliente.direccion);
                cmd.Parameters.AddWithValue("@telefono", cliente.telefono);
                cmd.Parameters.AddWithValue("@Genero", cliente.genero);
                cmd.Parameters.AddWithValue("@Correo", cliente.correo);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }

                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }
                return res;
            }
        }

        public bool updateCliente(int id, Cliente cliente)
        {
            bool res = false;
            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "cliente_update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdCliente", id);
                cmd.Parameters.AddWithValue("@Nombre", cliente.nombre);
                cmd.Parameters.AddWithValue("@Apellido", cliente.apellido);
                cmd.Parameters.AddWithValue("@Direccion", cliente.direccion);
                cmd.Parameters.AddWithValue("@telefono", cliente.telefono);
                cmd.Parameters.AddWithValue("@Genero", cliente.genero);
                cmd.Parameters.AddWithValue("@Correo", cliente.correo);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }

                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }
                return res;
            }
        }

        public bool deleteCliente(int id)
        {
            bool res = false;
            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "mascota_all";
                cmd.CommandType = CommandType.StoredProcedure;
                GestorMascota gMascota = new GestorMascota();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int idMascota = dr.GetInt32(0);
                    int idCliente = dr.GetInt32(6);
                    if(idCliente == id) {
                        gMascota.deleteMascota(idMascota);                    
                    }
                }
                dr.Close();
                cmd.Parameters.Clear();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "cliente_delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdCliente", id);

                try
                {
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }

                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }
                return res;
            }
        }
    }
}