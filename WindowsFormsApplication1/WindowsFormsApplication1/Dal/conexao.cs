using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Dal
{
    class conexao
    {
    
            private string connectionString =@"Data Source=localhost\MACONDA;Initial Catalog=TransportadoraDB; Integrated Security=True";
          

            public SqlConnection ObterConexao()
            {
                return new SqlConnection(connectionString);
            }
        



    }
}
