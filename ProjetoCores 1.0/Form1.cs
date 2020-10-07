using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ProjetoCores_1._0
{
    enum telas
    {
        home,
        adicionar,
        procurar
    }
    public partial class Form1 : Form
    {
        private AddForm addform;
        private Home home;
        private Procurar procurar;
        public Form1()
        {
            InitializeComponent();
        }
        public void AbrirForm(object Newform)
        {
            if (panelCentral.Controls.Count > 0)
                panelCentral.Controls.RemoveAt(0);

            Form fh = Newform as Form;

            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelCentral.Controls.Add(fh);
            this.panelCentral.Tag = fh;
            fh.Show();


        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
           /* btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            Screen tela = Screen.FromPoint(this.Location);
            this.Size = tela.WorkingArea.Size;
            this.Location = Point.Empty;*/
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            /*Screen tela = Screen.FromPoint(this.Location);           
            this.Size = new Size(1300, 650);
            this.Location = Point.Add(new Point(150,150),new Size(10,10));
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;*/
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }       

        private void Form1_Load(object sender, EventArgs e)
        {
            AtualizarTela(telas.home);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AtualizarTela(telas.adicionar);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AtualizarTela(telas.home);
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
           
            addform.Novocad();
            if (addform.cadOk)
            {
                AtualizarTela(telas.home);
            } 
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AtualizarTela(telas.procurar);

        }

        private void AtualizarTela(telas tela)
        {
            ActiveDesativeBtns(btnConfirmar, btnCancelar, false);
            ActiveDesativeBtns(btnProcurar, btnRemover, false);
            ActiveDesativeBtns(btnAdicionar, false);
            switch (tela)
            {
                case telas.home:
                    home = new Home();
                    AbrirForm(home);
                    labelTitle.Text = "Home";
                    ActiveDesativeBtns(btnProcurar, btnAdicionar, true);
                    break;
                case telas.adicionar:
                    addform = new AddForm();
                    AbrirForm(addform);
                    labelTitle.Text = "Adicionar";                    
                    ActiveDesativeBtns(btnConfirmar,btnCancelar, true);
                    break;
                case telas.procurar:
                    procurar = new Procurar();
                    AbrirForm(procurar);
                    labelTitle.Text = "Procurar";
                    ActiveDesativeBtns(btnRemover, btnCancelar, true);



                    break;
                default:
                    break;
            }
        }
        private void ActiveDesativeBtns(Button btn1,Button btn2, bool b)
        {
            btn1.Enabled = b;
            btn1.Visible = b;
            btn2.Enabled = b;
            btn2.Visible = b;
        }
        private void ActiveDesativeBtns(Button btn1, bool b)
        {
            btn1.Enabled = b;
            btn1.Visible = b;           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AtualizarTela(telas.home);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            procurar.RemoveCad();
        }
        

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AtualizarTela(telas.adicionar);
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            AtualizarTela(telas.procurar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AtualizarTela(telas.home);
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
