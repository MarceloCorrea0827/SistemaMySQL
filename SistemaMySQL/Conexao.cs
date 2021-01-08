using MySql.Data.MySqlClient;

namespace SistemaMySQL
{
    class Conexao
    {
        string conexao = "SERVER=localhost; "
                + "DATABASE=sistema_cliente; "
                + "UID=root; "
                + "PWD=ZaXsCd098890";
        public MySqlConnection conn = null;

        public void AbrirConexao()
        {
            try
            {
                conn = new MySqlConnection(conexao);
                conn.Open();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void fecharConexao()
        {
            try
            {
                conn = new MySqlConnection(conexao);
                conn.Close();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
