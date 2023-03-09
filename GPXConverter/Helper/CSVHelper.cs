using System.Data;
namespace GPXConverter.Helper
{
    public static class CSVHelper
    {
        public static DataTable Convert(string filePath)
        {
            // Create the DataTable
            DataTable dataTable = new DataTable();

            // Read the CSV file
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Read the header line
                string headerLine = reader.ReadLine();

                // Split the header line into columns
                string[] columns = headerLine.Split(',');

                // Add the columns to the DataTable
                foreach (string column in columns)
                {
                    dataTable.Columns.Add(column);
                }

                // Read the data lines and add them to the DataTable
                while (!reader.EndOfStream)
                {
                    string dataLine = reader.ReadLine();
                    string[] data = dataLine.Split(',');
                    DataRow row = dataTable.NewRow();
                    for (int i = 0; i < columns.Length; i++)
                    {
                        row[i] = data[i];
                    }
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }

    }
}
