using SistemaMySQL.DAO;
using System.Data;

namespace SistemaMySQL.Model
{
    class ClienteModel
    {
        ClienteDAO dao = new ClienteDAO();

        public  DataTable Listar()
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
    }
}
