using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Dal
{
    class RotaDAL
    {
        conexao Conexao = new conexao();
         public void Inserir(Rota r)
        {
             
            using (SqlConnection cn = Conexao.ObterConexao())
            {
                cn.Open();

                string sql = @"INSERT INTO Rota
                             (Origem,Destino,Distancia,TempoEstimado)
                             VALUES
                             (@Origem,@Destino,@Distancia,@Tempo)";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Origem", r.Origem);
                cmd.Parameters.AddWithValue("@Destino", r.Destino);
                cmd.Parameters.AddWithValue("@Distancia", r.Distancia);
                cmd.Parameters.AddWithValue("@Tempo", r.TempoEstimado);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Rota> Listar()
        {
            List<Rota> lista = new List<Rota>();

            using (SqlConnection cn = Conexao.ObterConexao())
            {
                cn.Open();

                SqlCommand cmd =
                    new SqlCommand("SELECT * FROM Rota", cn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Rota r = new Rota();

                    r.IdRota = (int)dr["IdRota"];
                    r.Origem = dr["Origem"].ToString();
                    r.Destino = dr["Destino"].ToString();
                    r.Distancia = Convert.ToDouble(dr["Distancia"]);
                    r.TempoEstimado = dr["TempoEstimado"].ToString();

                    lista.Add(r);
                }
            }

            return lista;
        }

        public void Actualizar(Rota r)
        {
            using (SqlConnection cn = Conexao.ObterConexao())
            {
                cn.Open();

                string sql = @"UPDATE Rota
                               SET Origem=@Origem,
                                   Destino=@Destino,
                                   Distancia=@Distancia,
                                   TempoEstimado=@Tempo
                               WHERE IdRota=@Id";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Id", r.IdRota);
                cmd.Parameters.AddWithValue("@Origem", r.Origem);
                cmd.Parameters.AddWithValue("@Destino", r.Destino);
                cmd.Parameters.AddWithValue("@Distancia", r.Distancia);
                cmd.Parameters.AddWithValue("@Tempo", r.TempoEstimado);

                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection cn = Conexao.ObterConexao())
            {
                cn.Open();

                SqlCommand cmd =
                    new SqlCommand(
                    "DELETE FROM Rota WHERE IdRota=@Id", cn);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
    
}
