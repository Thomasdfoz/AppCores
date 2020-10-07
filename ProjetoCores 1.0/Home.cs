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
    public partial class Home : Form
    {
        
        private sqliteConn conn = new sqliteConn();
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            conn.LoadData(listGrid);
        }
    }
}
