using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaMySQL.DAO
{
    class ClienteDAO
    {
        string conexao = "SERVER=localhost; "
                        + "DATABASE=sistema_clientes; "
                        + "UID=root; "
                        + "PWD=ZaXsCd098890";
        MySqlConnection conn = null;
        MySqlCommand sql;

        public DataTable BuscarDados()
        {
            try
            {
                conn = new MySqlConnection(conexao);
                sql = new MySqlCommand("select id,nome,sexo,nascimento from clientes", conn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = sql;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
