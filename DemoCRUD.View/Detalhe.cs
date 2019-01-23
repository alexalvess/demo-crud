using DemoCRUD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCRUD.View
{
    public partial class Detalhe : Form
    {
        private Cliente cliente;

        public Detalhe(Cliente cliente)
        {
            InitializeComponent();

            this.cliente = cliente;
        }

        private void Detalhe_Load(object sender, EventArgs e)
        {
            lblRegistro.Text = cliente.DataRegistro.ToString("dd/MM/yyyy HH:mm:ss");
            lblNome.Text = cliente.Nome;
            lblNascimento.Text = cliente.DataNascimento.ToString("dd/MM/yyyy");
            lblCpf.Text = cliente.Cpf;
        }
    }
}
