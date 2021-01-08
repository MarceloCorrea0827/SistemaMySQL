using System;
using System.Windows.Forms;
using SistemaMySQL.Model;

namespace SistemaMySQL.View
{
    public partial class frmClientes : Form
    {
        ClienteModel model = new ClienteModel();

        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            try
            {
                gridClientes.DataSource = model.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar os dados" + ex.Message);
            }
        }
    }
}
