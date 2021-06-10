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

        private void Form1_Load(object sender, EventArgs e)
        {
            // 
            // changed this from the book
            // 
            SqlConnection booksConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS; 
                            AttachDBFilename=c\myPath; Integrated Security=TRUE; Connect Timeout=30; User Instance=True"); // TODO add file path
            // open the connection
            booksConnection.Open();
            // display state

            //
            // changed from the book
            //
            string state = booksConnection.State.ToString(); 
            MessageBox.Show(state);
            titlesCommand = new SqlCommand();
            
        }
    }
}
