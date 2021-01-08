using MySql.Data.MySqlClient;
using System.Data;
using SistemaMySQL.Entidades;
using System.Windows.Forms;

namespace SistemaMySQL.DAO
{
    class ClienteDAO
    {
        MySqlCommand sql;
        Conexao conn = new Conexao();

        public DataTable Listar()
        {
            try
            {
                conn.AbrirConexao();
                sql = new MySqlCommand("select id,nome,sexo,nascimento from clientes order by id desc", conn.conn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = sql;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Salvar (Clientes dado)
        {
            try
            {
                conn.AbrirConexao();
                sql = new MySqlCommand("insert into clientes (nome, sexo, nascimento)  values (@nome, @sexo, @nascimento)", conn.conn);
                sql.Parameters.AddWithValue("@nome", dado.Nome);
                sql.Parameters.AddWithValue("@sexo", dado.Sexo);
                sql.Parameters.AddWithValue("@nascimento", dado.Nascimento);
                sql.ExecuteNonQuery();
                conn.fecharConexao();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao salvar dados do cliente " + ex.Message); ;
                conn.fecharConexao();
            }
        }

        public void Editar(Clientes dado)
        {
            try
            {
                conn.AbrirConexao();
                sql = new MySqlCommand("update clientes set nome = @nome, sexo = @sexo, nascimento = @nascimento where id = @id", conn.conn);
                sql.Parameters.AddWithValue("@id", dado.Id);
                sql.Parameters.AddWithValue("@nome", dado.Nome);
                sql.Parameters.AddWithValue("@sexo", dado.Sexo);
                sql.Parameters.AddWithValue("@nascimento", dado.Nascimento);
                sql.ExecuteNonQuery();
                conn.fecharConexao();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao editar dados do cliente " + ex.Message); ;
                conn.fecharConexao();
            }
        }

    }
}
