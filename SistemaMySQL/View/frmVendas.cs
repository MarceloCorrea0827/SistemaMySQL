using System;
using System.Windows.Forms;
using SistemaMySQL.Model;
using SistemaMySQL.Entidades;

namespace SistemaMySQL.View
{
    public partial class frmVendas : Form
    {
        ClienteModel clienteModel = new ClienteModel();
        VendasModel vendasModel = new VendasModel();

        public bool tmpCarga = true;

        public frmVendas()
        {
            InitializeComponent();
        }

        public void HabilitarCampos()
        {
            txtValor.Enabled = true;
            cmbCliente.Enabled = true;
            dtVenda.Enabled = true;
        }

        public void DesabilitarCampos()
        {
            txtValor.Enabled = false;
            cmbCliente.Enabled = false;
            dtVenda.Enabled = false;
        }

        public void LimparCampos()
        {
            txtId.Text = "";
            txtValor.Text = "";
            cmbCliente.Text = "";
            dtVenda.Text = "";
        }

        private void frmVendas_Load(object sender, EventArgs e)
        {
            cmbCliente.DataSource = clienteModel.Listar();
            cmbCliente.ValueMember = "Id";
            cmbCliente.DisplayMember = "Nome";

            cmbPesquisa.DataSource = clienteModel.Listar();
            cmbPesquisa.ValueMember = "Id";
            cmbPesquisa.DisplayMember = "Nome";
            tmpCarga = false;

            Listar();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            LimparCampos();
        }

        public void AtualizaCampos()
        {
            if (gridVendas.CurrentRow != null)
            {
                txtId.Text = gridVendas.CurrentRow.Cells[0].Value.ToString();
                txtValor.Text = gridVendas.CurrentRow.Cells[1].Value.ToString();
                cmbCliente.SelectedValue = gridVendas.CurrentRow.Cells[2].Value.ToString();
                dtVenda.Text = gridVendas.CurrentRow.Cells[3].Value.ToString();
            }
        }

        public void Salvar(Vendas dado)
        {
            try
            {
                dado.Valor = decimal.Parse(txtValor.Text);
                dado.Id_cliente = int.Parse(cmbCliente.SelectedValue.ToString());
                dado.Dt_venda = dtVenda.Value;

                vendasModel.Salvar(dado);
                MessageBox.Show("Venda salva com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os dados da venda " + ex.Message);
            }
        }

        public void Listar()
        {
            try
            {
                gridVendas.DataSource = vendasModel.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar os dados " + ex.Message);
            }
        }

        public void Excluir(Vendas dado)
        {
            try
            {
                dado.Id = int.Parse(txtId.Text);

                vendasModel.Excluir(dado);
                MessageBox.Show("Venda Excluída com sucesso!");
                DesabilitarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir os dados da venda " + ex.Message);
            }
        }

        public void Editar(Vendas dado)
        {
            try
            {
                dado.Id = int.Parse(txtId.Text);
                dado.Valor = decimal.Parse(txtValor.Text);
                dado.Id_cliente = int.Parse(cmbCliente.SelectedValue.ToString());
                dado.Dt_venda = dtVenda.Value;

                vendasModel.Editar(dado);
                MessageBox.Show("Venda editada com sucesso!");
                DesabilitarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar os dados da venda " + ex.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Vendas dado = new Vendas();
            Salvar(dado);
            Listar();
            AtualizaCampos();
            DesabilitarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Vendas dado = new Vendas();
            Editar(dado);
            Listar();
            AtualizaCampos();
        }

        private void gridVendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtualizaCampos();
        }

        private void gridVendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            HabilitarCampos();
        }

        private void gridVendas_Enter(object sender, EventArgs e)
        {
            if (gridVendas.CurrentRow.Cells[0].Value.ToString() != "")
            {
                AtualizaCampos();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir o registro?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Vendas dado = new Vendas();
                Excluir(dado);
                Listar();
                AtualizaCampos();
            }

        }

        public void Buscar(Vendas dados)
        {
            try
            {
                dados.Id_cliente = int.Parse(cmbPesquisa.SelectedValue.ToString());
                gridVendas.DataSource = vendasModel.Buscar(dados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar os dados " + ex.Message);
            }
        }

        private void cmbPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!tmpCarga)
            {
                Vendas dado = new Vendas();
                Buscar(dado);
                AtualizaCampos();

                if (cmbPesquisa.Text == "")
                {
                    Listar();
                    return;
                }

            }
        }
    }
}
