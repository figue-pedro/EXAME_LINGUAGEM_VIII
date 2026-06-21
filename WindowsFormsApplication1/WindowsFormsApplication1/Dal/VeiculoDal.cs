using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Dal
{
    class VeiculoDal
    {
         conexao conexao = new conexao();

        public void Inserir(VeiculoModel v)
        {
            using (SqlConnection cn = conexao.ObterConexao())
            {
                cn.Open();

                string sql =
                @"INSERT INTO Veiculo
                (Matricula,Tipo,Capacidade,Consumo,Estado)
                VALUES
                (@Matricula,@Tipo,@Capacidade,@Consumo,@Estado)";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Matricula", v.Matricula);
                cmd.Parameters.AddWithValue("@Tipo", v.Tipo);
                cmd.Parameters.AddWithValue("@Capacidade", v.Capacidade);
                cmd.Parameters.AddWithValue("@Consumo", v.Consumo);
                cmd.Parameters.AddWithValue("@Estado", v.Estado);

                cmd.ExecuteNonQuery();
            }
        }

        public List<VeiculoModel> Listar()
        {
            List<VeiculoModel> lista = new List<VeiculoModel>();

            using (SqlConnection cn = conexao.ObterConexao())
            {
                cn.Open();

                string sql = "SELECT * FROM Veiculo";

                SqlCommand cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new VeiculoModel()
                    {
                        IdVeiculo = (int)dr["IdVeiculo"],
                        Matricula = dr["Matricula"].ToString(),
                        Tipo = dr["Tipo"].ToString(),
                        Capacidade = (double)dr["Capacidade"],
                        Consumo = (double)dr["Consumo"],
                        Estado = dr["Estado"].ToString()
                    });
                }
            }

            return lista;
        }

        public void Actualizar(VeiculoModel v)
        {
            using (SqlConnection cn = conexao.ObterConexao())
            {
                cn.Open();

                string sql =
                @"UPDATE Veiculo
                  SET Matricula=@Matricula,
                      Tipo=@Tipo,
                      Capacidade=@Capacidade,
                      Consumo=@Consumo,
                      Estado=@Estado
                  WHERE IdVeiculo=@Id";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Id", v.IdVeiculo);
                cmd.Parameters.AddWithValue("@Matricula", v.Matricula);
                cmd.Parameters.AddWithValue("@Tipo", v.Tipo);
                cmd.Parameters.AddWithValue("@Capacidade", v.Capacidade);
                cmd.Parameters.AddWithValue("@Consumo", v.Consumo);
                cmd.Parameters.AddWithValue("@Estado", v.Estado);

                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection cn = conexao.ObterConexao())
            {
                cn.Open();

                string sql =
                "DELETE FROM Veiculo WHERE IdVeiculo=@Id";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
    
}
