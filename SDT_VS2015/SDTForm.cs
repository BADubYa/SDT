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
        }

        public static DataSet ImportExcelXLS(string FileName, bool hasHeaders, string Selected, string colname)
        {
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=1\"";

            DataSet output = new DataSet();

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow row in dt.Rows)
                {
                    string sheet = row["TABLE_NAME"].ToString();

                    //string comboBox1Selected = comboBox1.SelectedItem;
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "] WHERE " + colname + "  = '" + Selected + " ' ", conn);
                    cmd.CommandType = CommandType.Text;

                    DataTable outputTable = new DataTable(sheet);
                    output.Tables.Add(outputTable);
                    new OleDbDataAdapter(cmd).Fill(outputTable);
                }

            }
            return output;

        }

        private void Index_click(object sender, EventArgs e) // Populates the index dropdown when user clicks on the field
        {
            DataSet ds = new DataSet();
            ds = ConvertToExcel.ExcelImport.ImportExcelXLS("SDT.xls", true);
            comboBox1.Items.Clear();

            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {

                int value = 0;
                var val = ds.Tables[0].Rows[intCount][value].ToString();

                //check if it already exists
                if (!comboBox1.Items.Contains(val))
                {
                    comboBox1.Items.Add(val);
                }
            }
            comboBox1.ValueMember = "Index";
            comboBox1.DisplayMember = "Index";
        }

        private void Index2_click(object sender, EventArgs e) // Populates the index dropdown when user clicks on the field
        {
            DataSet ds = new DataSet();
            ds = ConvertToExcel.ExcelImport.ImportExcelXLS("SDT.xls", true);
            comboBox3.Items.Clear();

            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {

                int value = 0;
                var val = ds.Tables[0].Rows[intCount][value].ToString();

                //check if it already exists
                if (!comboBox3.Items.Contains(val))
                {
                    comboBox3.Items.Add(val);
                }
            }
            comboBox3.ValueMember = "Index";
            comboBox3.DisplayMember = "Index";
        }

        private void Index_SelectionChanged(object sender, EventArgs e)
        {
            string colname = "Index";
            string Selected = comboBox1.SelectedItem.ToString();
            DataSet ds = new DataSet();
            ds = ImportExcelXLS("SDT.xls", true, Selected, colname);
            DataTable table = ds.Tables[0];

            //string q = comboBox1.SelectedValue.ToString();
            //DataRow[] row = table.Select("Index = 'q'");

            //foreach (DataRow dr in row)

            comboBox2.DataSource = null;

            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                int value = 3;
                var val = ds.Tables[0].Rows[intCount][value].ToString();
                {

                    if (!comboBox2.Items.Contains(val))
                    {
                        comboBox2.Items.Add(val);
                    }
                }
            }

            comboBox2.ValueMember = "ColumnName";
            comboBox2.DisplayMember = "ColumnName";
        }

        private void Index2_SelectionChanged(object sender, EventArgs e)
        {
            string colname = "Index";
            string Selected = comboBox3.SelectedItem.ToString();
            DataSet ds = new DataSet();
            ds = ImportExcelXLS("SDT.xls", true, Selected, colname);
            DataTable table = ds.Tables[0];

            comboBox4.DataSource = null;

            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
            {
                int value = 3;
                var val = ds.Tables[0].Rows[intCount][value].ToString();
                {

                    if (!comboBox4.Items.Contains(val))
                    {
                        comboBox4.Items.Add(val);
                    }
                }
            }

            comboBox4.ValueMember = "ColumnName";
            comboBox4.DisplayMember = "ColumnName";
        }


        private void SelectPField(object sender, EventArgs e) //This populates the Datagrid once user selects a column name.
        {
            string colname = "ColumnName";
            string Selected = comboBox2.SelectedItem.ToString();
            DataSet ds = new DataSet();
            ds = ImportExcelXLS("SDT.xls", true, Selected, colname);
            dataGridView1.DataSource = ds.Tables[0];

            string[] colNames = { "Index", "Count", "ColumnName" };

            foreach (string colName in colNames)
            {
                dataGridView1.Columns[colName].Visible = false;
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView1.AutoResizeRows();
            dataGridView1.AutoResizeColumns();

        }

        private void SelectSField(object sender, EventArgs e) //This populates the Datagrid once user selects a column name.
        {
            string colname = "ColumnName";
            string Selected = comboBox4.SelectedItem.ToString();
            DataSet ds = new DataSet();
            ds = ImportExcelXLS("SDT.xls", true, Selected, colname);
            dataGridView2.DataSource = ds.Tables[0];

            string[] colNames = { "Index", "Count", "ColumnName" };

            foreach (string colName in colNames)
            {
                dataGridView2.Columns[colName].Visible = false;
            }

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView2.AutoResizeRows();
            dataGridView2.AutoResizeColumns();
        }

        private void getDuplicates(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                
               for (int j = 2; j < dataGridView1.Columns.Count; j++)
               {
                    if ((dataGridView1.Rows[i].Cells[j].Value.ToString()) == (dataGridView2.Rows[i].Cells[j].Value.ToString()))
                        {
                            dataGridView2.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                            //dataGridView1.CurrentCell.Style.BackColor = Color.LightYellow;
                        }
                        else
                        {
                            dataGridView2.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                        }
                    //}
                }
            }


        }
    }
}


        