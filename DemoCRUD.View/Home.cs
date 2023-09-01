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
        private Cliente cliente;

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

            InicializarDataDrid();
            CarregarListView();
        }

        private void InicializarDataDrid()
        {
        }

        #region Funcionalidades
        private void CarregarListView()
        {
            clientes = service.RecuperarTodos();
            dataGridView1.DataSource = clientes;

            var delete_btn = new DataGridViewButtonColumn();
            delete_btn.Name = "Delete";
            delete_btn.Text = "X";
            delete_btn.UseColumnTextForButtonValue = true;

            if (dataGridView1.Columns["Delete"] is null)
                dataGridView1.Columns.Add(delete_btn);

            dataGridView1.Columns["Id"].Visible = false;
        }
        #endregion

        #region Funcionalidades base
        private void LimparCampoTexto()
        {
            txtNome.Clear();
            txtCpf.Clear();
            txtNascimento.Clear();
        }

        private void StatusCampoTexto(bool flag)
        {
            txtNome.Enabled = flag;
            txtCpf.Enabled = flag;
            txtNascimento.Enabled = flag;
        }

        private void StatusCampoBotao()
        {
            btnNovo.Enabled = !inserir && !alterar;
            btnAlterar.Enabled = !inserir && !alterar;
            btnExibir.Enabled = !inserir && !alterar;
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            alterar = true;

            StatusCampoBotao();
            StatusCampoTexto(true);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (inserir)
            {
                service.Inserir(new Cliente
                {
                    DataNascimento = DateTime.ParseExact(txtNascimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Cpf = txtCpf.Text,
                    Nome = txtNome.Text
                });
            }
            else if (alterar)
            {
                cliente.Nome = txtNome.Text;
                cliente.Cpf = txtCpf.Text;
                cliente.DataNascimento = DateTime.ParseExact(txtNascimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                service.Alterar(cliente);
            }

            AcaoComum();

            CarregarListView();
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            AcaoComum();

            var detalhe = new Detalhe(cliente);
            detalhe.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AcaoComum();
        }
        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
                excluirCliente((int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
        }

        private void excluirCliente(int id)
        {
            service.Deletar(id);

            AcaoComum();

            CarregarListView();
        }
    }
}
