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
    public partial class AddForm : Form
    {
        private sqliteConn conn = new sqliteConn();

        public bool cadOk { get; set; }
        private string txtQuery;
        private cliente novoCliente;        
        
                
        public AddForm()
        {
            InitializeComponent();
            

        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            comboDia.Text = DateTime.Today.ToString("dd");
            comboMes.Text = DateTime.Today.ToString("MMMM");
            comboAno.Text = DateTime.Today.ToString("yyyy");
            cadOk = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Novocad();
        }

        public void Novocad()
        {
            try
            {

                string[] TextosParaValidar = new string[] { textNome.Text.ToUpper(), textCor.Text.ToUpper(), comboTamanho.Text.ToUpper(),
                comboBase.Text, comboTipo.Text, comboQualidade.Text, comboDia.Text, comboMes.Text, comboAno.Text };
                bool vali = ValidacaoInput(TextosParaValidar);
                if (vali)
                {
                    novoCliente = new cliente(TextosParaValidar, textQuantidade.Text.ToUpper(), textPreco.Text.ToUpper(), textObservacao.Text.ToUpper());
                    txtQuery = "INSERT into clientes(nome, cor, tamanho, base, tipo, qualidade,quantidade,preco,observacao,data) VALUES(" + novoCliente.ToString() + ")";
                    conn.ExecuteQuery(txtQuery);
                    cadOk = true;
                    MessageBox.Show("Cadastrado com sucesso", "Cadastrado",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    
                }
                else
                {
                    MessageBox.Show("Preencha todos campos com \"*\"", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private bool ValidacaoInput(string[] s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == "" || s[i] == " " || s[i] == null || s[i] == "Selecione"||s[i]== "Dia"|| s[i] == "Mês" || s[i] == "Ano") 
                {
                    return false;
                }
                
            }
            return true;
           
        }     
        
    }
}
