using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;


namespace ProjetoCores_1._0
{
    class sqliteConn
    {
        private SQLiteConnection conexao;
        private SQLiteCommand comando;
        private SQLiteDataAdapter dbadapter;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        public void SetConnection()
        {
            conexao = new SQLiteConnection("Data Source=dbcores.db;Version=3;New=False;Compress=True;");
        }
        public void LoadData(DataGridView datagrid)
        {
            SetConnection();
            conexao.Open();
            comando = conexao.CreateCommand();
            string comandtxt = "SELECT * FROM CLIENTES";
            dbadapter = new SQLiteDataAdapter(comandtxt, conexao);
            ds.Reset();
            dbadapter.Fill(ds);
            dt = ds.Tables[0];
            datagrid.DataSource = dt;
            conexao.Close();

        }
        public void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            conexao.Open();
            comando = conexao.CreateCommand();
            comando.CommandText = txtQuery;
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void LoadSelect(DataGridView datagrid, string nomeProcurar)
        {
            SetConnection();
            conexao.Open();
            comando = conexao.CreateCommand();
            string comandtxt = "SELECT * FROM CLIENTES WHERE NOME LIKE'" + nomeProcurar + "%'";
            dbadapter = new SQLiteDataAdapter(comandtxt, conexao);
            ds.Reset();
            dbadapter.Fill(ds);
            dt = ds.Tables[0];
            datagrid.DataSource = dt;
            conexao.Close();

        }

    }
}
