using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoCores_1._0
{
    public partial class Procurar : Form
    {
        int codigolist = 0;
        private sqliteConn conn = new sqliteConn();
        public string nomeProcurar;
        public Procurar()
        {
            InitializeComponent();
        }

        private void Procurar_Load(object sender, EventArgs e)
        {
            conn.LoadData(listGrid);
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            nomeProcurar = textProcurar.Text;
            ProcurarNome();
        }
        private void ProcurarNome()
        {
            try
            {
                if (nomeProcurar == "" || nomeProcurar == " " || nomeProcurar == null)
                {
                    MessageBox.Show("Preencha um nome");
                }
                else
                {        
                    conn.LoadSelect(listGrid, nomeProcurar.ToUpper());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void RemoveCad()
        {
            try
            {
                if (codigolist != 0)
                {
                    if (MessageBox.Show("Tem certeza que deseja excluir esse cadastro?", "Excluir cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        string txtQuery = "DELETE FROM CLIENTES WHERE codigo='" + codigolist + "'";
                        conn.ExecuteQuery(txtQuery);
                        conn.LoadData(listGrid);
                        codigolist = 0;
                    }

                }
                else
                {
                    MessageBox.Show("Voce tem que clicar em uma linha da tabela para excluir", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(),"error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw;
            }
            
        }

        private void listGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listGrid.CurrentCell == null || listGrid.CurrentCell.Value == null || e.RowIndex < 0) return;
            codigolist = int.Parse(listGrid.SelectedRows[0].Cells[0].Value.ToString());
        }
    }
}
