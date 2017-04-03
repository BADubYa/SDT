using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using System.Web;
/*
    private void button1_Click(object sender, EventArgs e)
    {
      DataSet ds = new DataSet();

      // ds = ConvertToExcel.ExcelImport.ImportExcelXLS("SDT.xls", true);
        
    }
 */
namespace ConvertToExcel {
    public class ExcelImport {

          public static DataSet ImportExcelXLS(string FileName, bool hasHeaders) {
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=1\"";

            DataSet output = new DataSet();

            using (OleDbConnection conn = new OleDbConnection(strConn)) {
                conn.Open();

                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow row in dt.Rows) {
                    string sheet = row["TABLE_NAME"].ToString();

                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                    cmd.CommandType = CommandType.Text;

                    DataTable outputTable = new DataTable(sheet);
                    output.Tables.Add(outputTable);
                    new OleDbDataAdapter(cmd).Fill(outputTable);
                }
            }
            return output;
        } // end of ImportExcelXLS




        // https://social.msdn.microsoft.com/Forums/en-US/f11b2df9-fd0a-4528-987f-f95dfdccee0a/microsoftaceoledb120-provider-is-not-registered-on-the-local-machine-error?forum=adodotnetdataproviders
        // download and install this: http://www.microsoft.com/download/en/confirmation.aspx?id=23734

        /*public static DataSet ImportExcelXLSX(string FileName, bool hasHeaders) {
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=1\"";
            //string strConn = "Provider=Microsoft.ACE.OLEDB.14.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=1\"";

            DataSet output = new DataSet();

            using (OleDbConnection conn = new OleDbConnection(strConn)) {
                conn.Open();

                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow row in dt.Rows) {
                    string sheet = row["TABLE_NAME"].ToString();

                    OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT FROM [" + sheet + "]", conn);
                    cmd.CommandType = CommandType.Text;

                    DataTable outputTable = new DataTable(sheet);
                    output.Tables.Add(outputTable);
                    new OleDbDataAdapter(cmd).Fill(outputTable);
                }
            }
            return output;
        } // end of ImportExcelXLSX*/

      /*struct ColumnType {
            public Type type;
            private string name;
            public ColumnType(Type type) { this.type = type; this.name = type.ToString().ToLower(); }
            public object ParseString(string input) {
                if (String.IsNullOrEmpty(input))
                    return DBNull.Value;
                switch (type.ToString()) {
                    case "system.datetime":
                        return DateTime.Parse(input);
                    case "system.decimal":
                        return decimal.Parse(input);
                    case "system.boolean":
                        return bool.Parse(input);
                    default:
                        return input;
                }
            }
        }*/
  
    } // end of ExcelIMport
} // end of namespace
