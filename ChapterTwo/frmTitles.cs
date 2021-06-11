using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;



namespace ChapterTwo
{
    public partial class frmTitles : Form
    {
        CurrencyManager titlesManager;
        public frmTitles()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmTitles_Load(object sender, EventArgs e)
        {

            SqlConnection booksConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS; 
                            AttachDBFilename=C:\Users\mholmes022726\source\repos\ChapterTwo; 
                            Integrated Security=TRUE; Connect Timeout=30; User Instance=True"); 
            // open the connection
            booksConnection.Open();
            // display state

            string state = booksConnection.State.ToString();

            SqlCommand titlesCommand = new SqlCommand("Select * from Titles", booksConnection);
            // establish data adapter/data table 
            SqlDataAdapter titlesAdapter = new SqlDataAdapter();
            titlesAdapter.SelectCommand = titlesCommand;
            DataTable titlesTable = new DataTable();
            titlesAdapter.Fill(titlesTable);
            // close the connection 
            booksConnection.Dispose();
            titlesAdapter.Dispose();
            titlesTable.Dispose();


        }
    }
}
