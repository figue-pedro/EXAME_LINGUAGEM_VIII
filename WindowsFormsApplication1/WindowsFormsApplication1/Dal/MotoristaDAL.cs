using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using WindowsFormsApplication1.Model;


namespace WindowsFormsApplication1.Dal
{
    class MotoristaDAL
    {
        conexao Conexao = new conexao();
         public void Inserir(Motorista m)
        {
            using (SqlConnection cn = Conexao.ObterConexao())
            {
                cn.Open();

                string sql = @"INSERT INTO Motorista
                             (Nome,CartaConducao,Habilitacoes,Estado)
                             VALUES
                             (@Nome,@Carta,@Hab,@Estado)";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Nome", m.Nome);
                cmd.Parameters.AddWithValue("@Carta", m.CartaConducao);
                cmd.Parameters.AddWithValue("@Hab", m.Habilitacoes);
                cmd.Parameters.AddWithValue("@Estado", m.Estado);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Motorista> Listar()
        {
            List<Motorista> lista = new List<Motorista>();

            using (SqlConnection cn = Conexao.ObterConexao())
            {
                cn.Open();

                SqlCommand cmd =
                    new SqlCommand("SELECT * FROM Motorista", cn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Motorista m = new Motorista();

                    m.IdMotorista = (int)dr["IdMotorista"];
                    m.Nome = dr["Nome"].ToString();
                    m.CartaConducao = dr["CartaConducao"].ToString();
                    m.Habilitacoes = dr["Habilitacoes"].ToString();
                    m.Estado = dr["Estado"].ToString();

                    lista.Add(m);
                }
            }

            return lista;
        }

        public void Actualizar(Motorista m)
        {
            using (SqlConnection cn = Conexao.ObterConexao())
            {
                cn.Open();

                string sql = @"UPDATE Motorista
                              SET Nome=@Nome,
                                  CartaConducao=@Carta,
                                  Habilitacoes=@Hab,
                                  Estado=@Estado
                              WHERE IdMotorista=@Id";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Id", m.IdMotorista);
                cmd.Parameters.AddWithValue("@Nome", m.Nome);
                cmd.Parameters.AddWithValue("@Carta", m.CartaConducao);
                cmd.Parameters.AddWithValue("@Hab", m.Habilitacoes);
                cmd.Parameters.AddWithValue("@Estado", m.Estado);

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
                    "DELETE FROM Motorista WHERE IdMotorista=@Id", cn);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
    
}
