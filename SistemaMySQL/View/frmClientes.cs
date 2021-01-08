using System;
using System.Windows.Forms;
using SistemaMySQL.Model;
using SistemaMySQL.Entidades;

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
                MessageBox.Show("Erro ao listar os dados " + ex.Message);
            }
        }

        public void HabilitarCampos()
        {
            txtNome.Enabled = true;
            cmbSexo.Enabled = true;
            dtNascimento.Enabled = true;
        }

        public void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            cmbSexo.Enabled = false;
            dtNascimento.Enabled = false;
        }

        public void LimparCampos()
        {
            txtNome.Text = "";
            cmbSexo.Text = "";
            txtId.Text = "";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            LimparCampos();
        }

        public void Salvar(Clientes dado)
        {
            try
            {
                dado.Nome = txtNome.Text;
                dado.Sexo = cmbSexo.Text;
                dado.Nascimento = dtNascimento.Value;

                model.Salvar(dado);
                MessageBox.Show("Cliente salvo com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os dados do cliente " + ex.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Clientes dado = new Clientes();
            Salvar(dado);
            Listar();
        }
    }
}
