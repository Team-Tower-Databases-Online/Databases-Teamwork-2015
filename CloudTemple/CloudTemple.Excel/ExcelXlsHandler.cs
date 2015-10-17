namespace CloudTemple.Excel
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    public class ExcelXlsHandler
    {
        public void ReadInitialDataFile(string sheetName, Action<DataTableReader> actionForEachRow)
        {
            this.ReadExcelSheet(ExcelSettings.Default.ModelsDataFileLocation, sheetName, actionForEachRow);
        }

        public void ReadExcelSheet(string fileName, Action<DataTableReader> actionForEachRow)
        {
            this.ReadExcelSheet(fileName, null, actionForEachRow);
        }

        public void ReadExcelSheet(string fileName, string sheetName, Action<DataTableReader> actionForEachRow)
        {
            var connectionString = string.Format(ExcelSettings.Default.ExcelConnectionString, fileName);

            using (var excelConnection = new OleDbConnection(connectionString))
            {
                excelConnection.Open();

                if (sheetName == null)
                {
                    var excelSchema = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (excelSchema != null)
                    {
                        sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();
                    }
                }

                var excelDbCommand = new OleDbCommand(@"SELECT * FROM [" + sheetName + "]", excelConnection);

                using (var oleDbDataAdapter = new OleDbDataAdapter(excelDbCommand))
                {
                    var dataSet = new DataSet();
                    oleDbDataAdapter.Fill(dataSet);

                    using (var reader = dataSet.CreateDataReader())
                    {
                        while (reader.Read())
                        {
                            actionForEachRow(reader);
                        }
                    }
                }
            }
        }
    }
}