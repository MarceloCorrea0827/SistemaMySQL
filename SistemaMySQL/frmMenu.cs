using System;
using System.Windows.Forms;
using SistemaMySQL.View;

namespace SistemaMySQL
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes form = new frmClientes();
            form.Show();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            frmVendas vendasForm = new frmVendas();
            vendasForm.Show();
        }
    }
}
