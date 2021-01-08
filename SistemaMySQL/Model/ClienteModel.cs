using SistemaMySQL.DAO;
using System.Data;
using SistemaMySQL.Entidades;

namespace SistemaMySQL.Model
{
    class ClienteModel
    {
        ClienteDAO dao = new ClienteDAO();

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

        public void Salvar(Clientes dados)
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
        
        public void Editar(Clientes dados)
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

        public void Excluir(Clientes dados)
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

        public DataTable Buscar(Clientes dados)
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
