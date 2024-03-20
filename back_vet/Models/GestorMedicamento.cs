using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace back_vet.Models
{
    public class GestorMedicamento
    {
        public List<Medicamento> getMedicamento()
        {
            List<Medicamento> lista = new List<Medicamento>();
            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "medicamento_all";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int idMedicamento = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    string descripcion = dr.GetString(2).Trim();
                    float dosis = (float)dr.GetDouble(3);
                    int estado = (int)dr.GetInt32(4);
                    Medicamento medicamento = new Medicamento(idMedicamento, nombre, descripcion, dosis, estado);
                    if(estado == 1)
                    {
                        lista.Add(medicamento);
                    }
                }

                dr.Close();
                conn.Close();
            }
            return lista;
        }

        public bool addMedicamento(Medicamento medicamento)
        {
            bool res = false;
            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "medicamento_add";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", medicamento.nombre);
                cmd.Parameters.AddWithValue("@Descripcion", medicamento.descripcion);
                cmd.Parameters.AddWithValue("@Dosis", medicamento.dosis);
                cmd.Parameters.AddWithValue("@Estado", 1);

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

        public bool updateMedicamento(int id, Medicamento medicamento)
        {
            bool res = false;
            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "medicamento_update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdMedicamento", id);
                cmd.Parameters.AddWithValue("@Nombre", medicamento.nombre);
                cmd.Parameters.AddWithValue("@Descripcion", medicamento.descripcion);
                cmd.Parameters.AddWithValue("@Dosis", medicamento.dosis);
                cmd.Parameters.AddWithValue("@Estado", 1);

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

        public bool estadoMedicamento(int id, int estado)
        {
            bool res = false;
            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "medicamento_estado";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdMedicamento", id);
                cmd.Parameters.AddWithValue("@Estado", estado);

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

        public bool deleteMedicamento(int id)
        {
            bool res = false;
            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "medicamento_delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdMedicamento", id);

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