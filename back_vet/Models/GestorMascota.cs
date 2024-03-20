using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace back_vet.Models
{
    public class GestorMascota
    {
        public List<Mascota> getMascota()
        {
            List<Mascota> lista = new List<Mascota>();
            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "mascota_all";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int idMascota = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    string raza = dr.GetString(2).Trim();
                    int edad = dr.GetInt32(3);
                    float peso = (float)dr.GetDouble(4);
                    int idMedicamento = dr.GetInt32(5);
                    int idCliente = dr.GetInt32(6);

                    Mascota mascota = new Mascota(idMascota, nombre, raza, edad, peso, idMedicamento, idCliente);
                    lista.Add(mascota);
                }

                dr.Close();
                conn.Close();
            }
            return lista;
        }
        
        public bool addMascota(Mascota mascota)
        {
            bool res = false;
            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "mascota_add";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdMascota", mascota.idMascota);
                cmd.Parameters.AddWithValue("@Nombre", mascota.nombre);
                cmd.Parameters.AddWithValue("@Raza", mascota.raza);
                cmd.Parameters.AddWithValue("@Edad", mascota.edad);
                cmd.Parameters.AddWithValue("@Peso", mascota.peso);
                cmd.Parameters.AddWithValue("@IdMedicamento", mascota.idMedicamento);
                cmd.Parameters.AddWithValue("@IdCliente", mascota.idCliente);

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

        public bool updateMascota(int id, Mascota mascota)
        {
            bool res = false;
            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "mascota_update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdMascota", id);
                cmd.Parameters.AddWithValue("@Nombre", mascota.nombre);
                cmd.Parameters.AddWithValue("@Raza", mascota.raza);
                cmd.Parameters.AddWithValue("@Edad", mascota.edad);
                cmd.Parameters.AddWithValue("@Peso", mascota.peso);
                cmd.Parameters.AddWithValue("@IdMedicamento", mascota.idMedicamento);
                cmd.Parameters.AddWithValue("@IdCliente", mascota.idCliente);

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

        public bool deleteMascota(int id)
        {
            bool res = false;
            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "mascota_delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdMascota", id);
                

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
    }
}