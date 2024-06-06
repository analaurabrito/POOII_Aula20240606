using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aula20240606
{
    public partial class Form2 : Form
    {
        Form1 origem;
        public Form2(Form1 origem)
        {
            InitializeComponent();
            origem = this.origem;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int proxID = origem.listacontatos.Count + 1;

            if (txbNome.Text.Equals(' ') || txbTelefone.Text.Equals(' '))
            {
                MessageBox.Show("Campo vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Contato aux = new Contato(proxID, txbNome.Text, txbTelefone.Text);
                origem.listacontatos.Add(aux);

                var insertCmd = origem.conexao.CreateCommand();
                insertCmd.CommandText = "INSERT INTO Exemplo (Nome, Telefone) " +
                    "VALUES (@nome, @telefone);";

                var paramNome = new SqlParameter("nome", aux.nome);
                var paramTelefone = new SqlParameter("telefone", aux.telefone);

                insertCmd.Parameters.Add(paramNome);
                insertCmd.Parameters.Add(paramTelefone);

                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Linha inserida!");

                origem.dgvContatos.DataSource = null;
                origem.dgvContatos.DataSource = origem.listacontatos;
                origem.dgvContatos.Refresh();

                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txbNome.Clear();
            txbTelefone.Clear();
            this.Close();
        }
    }
}
