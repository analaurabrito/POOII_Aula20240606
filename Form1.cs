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
    public partial class Form1 : Form
    {
        public SqlConnection conexao;
        public List<Contato> listacontatos;

        public Form1()
        {
            InitializeComponent();
            conexao = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Aula20240606; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            listacontatos = new List<Contato>();

            try
            {
                conexao.Open();
                var selectCmd = conexao.CreateCommand();
                selectCmd.CommandText = "SELECT * FROM Contato";

                SqlDataReader leitorDados = selectCmd.ExecuteReader();

                while (leitorDados.Read())
                {
                    //leitorDados["Nome"]
                    //Console.WriteLine("Nome: " + leitorDados["Nome"] + " Sobrenome: " + leitorDados["Sobrenome"]);
                }
            }
            
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        private void dgvContatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {

        }
    }
}
