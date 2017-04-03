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


namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
        InitializeComponent();
        Parse();

        }

        public static DataSet Parse()
        {
            string connectionString = string.Format("provider=Microsoft.Jet.OLEDB.4.0; data source={0};Extended Properties=Excel 8.0;", "C:\\SDT\\SDT.xls");
            //string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.4.0;Data Source=C:\\SDT\\SDT.xls;Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\"");
            string query = string.Format("SELECT * FROM [{0}$]", "SDTDATA");

            DataSet data = new DataSet();
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                con.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
                adapter.Fill(data);
            }

            return data;
        }
    }
    /*private void ReadData()
    {
        string sSheetName = null;
        string sConnection = null;
        DataTable dtTablesList = default(DataTable);
        OleDbCommand oleExcelCommand = default(OleDbCommand);
        OleDbDataReader oleExcelReader = default(OleDbDataReader);
        OleDbConnection oleExcelConnection = default(OleDbConnection);

        sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\SDT\\SDT.xls;Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\"";

        oleExcelConnection = new OleDbConnection(sConnection);
        oleExcelConnection.Open();

        dtTablesList = oleExcelConnection.GetSchema("Tables");

        if (dtTablesList.Rows.Count > 0)
        {
            sSheetName = dtTablesList.Rows[0]["Table_Name"].ToString();               

        }

        dtTablesList.Clear();
        dtTablesList.Dispose();


        if (!string.IsNullOrEmpty(sSheetName))
        {
            oleExcelCommand = oleExcelConnection.CreateCommand();
            oleExcelCommand.CommandText = "Select * From [" + sSheetName + "]";
            oleExcelCommand.CommandType = CommandType.Text;
            oleExcelReader = oleExcelCommand.ExecuteReader();
            int nOutputRow = 0;

            while (oleExcelReader.Read())
            {


                //PFieldValue.Items.AddRange(sSheetName);
            }
            oleExcelReader.Close();
        }
        oleExcelConnection.Close();

    }*/
}




