using SistemaMySQL.DAO;
using System.Data;
using SistemaMySQL.Entidades;

namespace SistemaMySQL.Model
{
    class VendasModel
    {
        VendasDAO dao = new VendasDAO();

        public DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dao.Listar();
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
                dao.Salvar(dados);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Editar(Vendas dados)
        {
            try
            {
                dao.Editar(dados);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(Vendas dados)
        {
            try
            {
                dao.Excluir(dados);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Buscar(Vendas dados)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dao.Buscar(dados);
                return dt;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
