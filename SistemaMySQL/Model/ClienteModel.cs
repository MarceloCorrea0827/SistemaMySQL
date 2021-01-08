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

        public void Salvar(Clientes dado)
        {
            try
            {
                dao.Salvar(dado);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
