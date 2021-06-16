/*
 * Mason Holmes
 * 6/16/2021
 * This program provides a gui for navigating a database.
 * 
 * outputs: - txtTitle : TextBox, displays book title 
 *          - txtYearPublished : TextBox, displays year book was published
 *          - txtISBN : TextBox, displays book ISBN number
 *          - txtPublisherID TextBox, displays book publisher ID
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
using System.IO; // added for relitive pathing

namespace ChapterTwo
{
    public partial class frmTitles : Form
    {
        CurrencyManager titlesManager;
        public frmTitles()
        {
            InitializeComponent();
        }
        
        private void frmTitles_Load(object sender, EventArgs e)
        {
            
            // connect to the books database
            
            // full path 
            /*SqlConnection booksConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS; 
                            AttachDBFilename=C:\Users\mason\source\repos\Chapter 1\SQLBooksDB.mdf; 
                            Integrated Security=TRUE; Connect Timeout=30; User Instance=True");*/

            string dataBasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SQLBooksDB.mdf");

            // relitive path 
            SqlConnection booksConnection = new SqlConnection($@"Data Source=.\SQLEXPRESS; 
                            AttachDBFilename={dataBasePath}; 
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
            txtYearPublished.DataBindings.Add("Text", titlesTable, "Year_Published"); 
            txtISBN.DataBindings.Add("Text", titlesTable, "ISBN");
            txtPublisherID.DataBindings.Add("Text", titlesTable, "PubID"); 

            // establish currentcy manager 
            titlesManager = (CurrencyManager)BindingContext[titlesTable];

            // close the connection 
            booksConnection.Close(); 

            // dispose of the connection object
            booksConnection.Dispose();
            titlesCommand.Dispose();
            titlesAdapter.Dispose();
            titlesTable.Dispose();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            titlesManager.Position = 0;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            titlesManager.Position--; 
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            titlesManager.Position++;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            titlesManager.Position = titlesManager.Count - 1;
        }
    }
}
