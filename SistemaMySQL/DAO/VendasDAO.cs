using MySql.Data.MySqlClient;
using System.Data;
using SistemaMySQL.Entidades;
using System.Windows.Forms;

namespace SistemaMySQL.DAO
{
    class VendasDAO
    {
        MySqlCommand sql;
        Conexao conn = new Conexao();

        public DataTable Listar()
        {
            try
            {
                conn.AbrirConexao();
                sql = new MySqlCommand("select id,valor,id_cliente,dt_venda from vendas order by id desc", conn.conn);
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

        public void Salvar(Vendas dados)
        {
            try
            {
                conn.AbrirConexao();
                sql = new MySqlCommand("insert into vendas (valor, id_cliente, dt_venda) values (@valor, @id_cliente, @dt_venda)", conn.conn);
                sql.Parameters.AddWithValue("@valor", dados.Valor);
                sql.Parameters.AddWithValue("@id_cliente", dados.Id_cliente);
                sql.Parameters.AddWithValue("@dt_venda", dados.Dt_venda);
                sql.ExecuteNonQuery();
                conn.fecharConexao();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao salvar dados da venda " + ex.Message); ;
                conn.fecharConexao();
            }
        }

        public void Editar(Vendas dados)
        {
            try
            {
                conn.AbrirConexao();
                sql = new MySqlCommand("update vendas set valor = @valor, id_cliente = @id_cliente, dt_venda = @dt_venda where id = @id", conn.conn);
                sql.Parameters.AddWithValue("@id", dados.Id);
                sql.Parameters.AddWithValue("@valor", dados.Valor);
                sql.Parameters.AddWithValue("@id_cliente", dados.Id_cliente);
                sql.Parameters.AddWithValue("@dt_venda", dados.Dt_venda);
                sql.ExecuteNonQuery();
                conn.fecharConexao();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao editar dados da venda " + ex.Message); ;
                conn.fecharConexao();
            }
        }

        public void Excluir(Vendas dados)
        {
            try
            {
                conn.AbrirConexao();
                sql = new MySqlCommand("delete from vendas where id = @id", conn.conn);
                sql.Parameters.AddWithValue("@id", dados.Id);
                sql.ExecuteNonQuery();
                conn.fecharConexao();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erro ao excluir dados da venda " + ex.Message); ;
                conn.fecharConexao();
            }
        }

        public DataTable Buscar(Vendas dados)
        {
            try
            {
                conn.AbrirConexao();
                sql = new MySqlCommand("select id, valor, id_cliente, dt_venda from vendas where id_cliente = @id_cliente order by id desc", conn.conn);
                sql.Parameters.AddWithValue("@id_cliente", dados.Id_cliente);
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
    }
}
