using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Runtime.InteropServices;
using SQL = System.Data;
using Microsoft.Office.Interop.Excel;

namespace CloudTemple.Excel
{
    public class ExcelPrinter
    {

        public ExcelPrinter()
        {

        }
        public void GenrateExcel()
        {
            SQLiteConnection con;
            con = new SQLiteConnection("Data Source = C:\\SqLiteDb.sqlite; Version=3;");
            con.Open();
            string sql = "SELECT * FROM ProductTaxes";
            SQLiteCommand command = new SQLiteCommand(sql, con);
            SQLiteDataReader reader = command.ExecuteReader();
            
            Application application;
            Workbook workBook;
            Worksheet workSheet;

            application = new Application();
            application.Visible = true;

            workBook = (Workbook)(application.Workbooks.Add(Missing.Value));
            workSheet = (Worksheet)workBook.ActiveSheet;

            try
            {
                workSheet.Name = "dataBase";
                workSheet.Cells[1, "A"] = "ProductName";
                workSheet.Cells[1, "B"] = "Amount";

                    int row = 2;
                while (reader.Read())
                {
                   

                    workSheet.Cells[row, "A"] = reader["ProductName"];
                    workSheet.Cells[row, "B"] = reader["Amount"];

                    row += 1;
                    application.Visible = false;
                    application.UserControl = false;

                    
                }
                workBook.SaveAs(@"C:\Users\Miro\Documents\GitHub\Databases-Teamwork-2015\Reports\Excel_Reports\ExcelReportNumer");
                workSheet.Columns[1].AutoFit();
                workSheet.Columns[2].AutoFit();
                ((Range)workSheet.Columns[1]).AutoFit();
                ((Range)workSheet.Columns[2]).AutoFit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Marshal.ReleaseComObject(workBook);
            }

            con.Close();
        }
    }
}

