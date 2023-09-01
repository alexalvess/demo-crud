using DemoCRUD.Controller.Services;
using DemoCRUD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCRUD.View
{
    public partial class Home : Form
    {
        private ClienteService service;

        private List<Cliente> clientes;

        private bool inserir;
        private bool alterar;

        public Home()
        {
            InitializeComponent();

            service = new ClienteService();

            inserir = false;
            alterar = false;

            StatusCampoBotao();
            StatusCampoTexto(false);

            CarregarListView();
        }

        #region Funcionalidades
        private void CarregarListView()
        {
            clientes = service.RecuperarTodos();
            dataGridView1.DataSource = clientes;

            var delete_btn = new DataGridViewButtonColumn();
            delete_btn.Name = "Remover";
            delete_btn.Text = "❌";
            delete_btn.UseColumnTextForButtonValue = true;

            var detalhe_btn = new DataGridViewButtonColumn();
            detalhe_btn.Name = "Detalhar";
            detalhe_btn.Text = "📃";
            detalhe_btn.UseColumnTextForButtonValue = true;

            if (dataGridView1.Columns["Remover"] is null)
                dataGridView1.Columns.Add(delete_btn);

            if (dataGridView1.Columns["Detalhar"] is null)
                dataGridView1.Columns.Add(detalhe_btn);

            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["DataRegistro"].ReadOnly = true;
        }
        #endregion

        #region Funcionalidades base
        private void LimparCampoTexto()
        {
            txtNome.Clear();
            mtxCpf.Clear();
            mtxDataNascimento.Clear();
        }

        private void StatusCampoTexto(bool flag)
        {
            txtNome.Enabled = flag;
            mtxCpf.Enabled = flag;
            mtxDataNascimento.Enabled = flag;
        }

        private void StatusCampoBotao()
        {
            btnNovo.Enabled = !inserir && !alterar;
            btnSalvar.Enabled = inserir || alterar;
            btnCancelar.Enabled = inserir || alterar;
        }

        private void AcaoComum()
        {
            alterar = false;
            inserir = false;

            StatusCampoBotao();
            StatusCampoTexto(false);
        }
        #endregion

        #region Ações - botão
        private void btnNovo_Click(object sender, EventArgs e)
        {
            inserir = true;

            StatusCampoBotao();
            StatusCampoTexto(true);
            LimparCampoTexto();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            service.Inserir(new Cliente
            {
                DataNascimento = DateTime.ParseExact(mtxDataNascimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Cpf = mtxCpf.Text,
                Nome = txtNome.Text
            });

            AcaoComum();
            CarregarListView();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
            => AcaoComum();
        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridView1.Columns["Remover"].Index)
                excluirCliente((int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

            else if (e.ColumnIndex == dataGridView1.Columns["Detalhar"].Index)
                detalharCliente((int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            => alterarCliente((int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || txtNome.Text.Length < 3)
                return ExibirAlerta("É obrigatório informar o nome do cliente.");
            else if (txtNome.Text.Length < 3)
                return ExibirAlerta("O nome do cliente deve conter mais do que 2 caracteres.");
            else if (string.IsNullOrWhiteSpace(mtxCpf.Text))
                return ExibirAlerta("O CPF do cliente deve ser informado.");
            else if (mtxCpf.Text.Length != 14)
                return ExibirAlerta("O CPF do cliente está incompleto");
            else if (string.IsNullOrWhiteSpace(mtxDataNascimento.Text))
                return ExibirAlerta("A data de nascimento do cliente deve ser informada");
            else if (!DateTime.TryParse(mtxDataNascimento.Text, out DateTime data))
                return ExibirAlerta("Informe uma data de nascimento válida.");

            return true;
        }

        private bool ExibirAlerta(string mensagem)
        {
            MessageBox.Show(mensagem, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void excluirCliente(int id)
        {
            service.Deletar(id);
            CarregarListView();
        }

        private void detalharCliente(int id)
        {
            AcaoComum();
            var detalhe = new Detalhe(clientes.First(x => x.Id == id));
            detalhe.ShowDialog();
        }

        private void alterarCliente(int id)
            => service.Alterar(clientes.First(c => c.Id == id));
    }
}
