/*
 * This exception occurs after the 30 second connection timeout
 * 
 * Exception Unhandled:
 * 
 * System.Data.SqlClient.SqlException: 'A network-related or instance-specific error occurred while 
 * establishing a connection to SQL Server. The server was not found or was not accessible. 
 * Verify that the instance name is correct and that SQL Server is configured to allow remote connections. 
 * (provider: SQL Network Interfaces, error: 26 - Error Locating Server/Instance Specified)'
 * 
 */

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

            // establish a command object 
            SqlCommand titlesCommand = new SqlCommand("Select * from Titles", booksConnection);

            // establish data adapter/data table 
            SqlDataAdapter titlesAdapter = new SqlDataAdapter();
            titlesAdapter.SelectCommand = titlesCommand;
            DataTable titlesTable = new DataTable();
            titlesAdapter.Fill(titlesTable);

            // bind controls to data table
            txtTitle.DataBindings.Add("Text", titlesTable, "Title");
            txtYearPublished.DataBindings.Add("Text", titlesTable, "Yeah_Published");
            txtISBN.DataBindings.Add("Text", titlesTable, "ISBN");
            txtPublisherID.DataBindings.Add("Text", titlesTable, "PublisherID");

            // establish currentcy manager 
            titlesManager = (CurrencyManager)BindingContext[titlesTable]; 

            // close the connection 
            booksConnection.Dispose();
            titlesCommand.Dispose();
            titlesAdapter.Dispose();
            titlesTable.Dispose();
        }
    }
}
