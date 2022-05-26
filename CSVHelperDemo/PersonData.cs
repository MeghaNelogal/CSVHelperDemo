using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVHelperDemo
{
    public class PersonData
    {
        string IMPORT_FILEPATH = @"D:\practiceproblems\CSVHelperDemo\CSVHelperDemo\CSVHelperDemo\Address.csv";
        string EXPORT_FILEPATH = @"D:\practiceproblems\CSVHelperDemo\CSVHelperDemo\CSVHelperDemo\Export.csv";
        const string EXPORT_JSON_FILENAME = @"D:\practiceproblems\CSVHelperDemo\CSVHelperDemo\CSVHelperDemo\Export.json";
        public void ImplementationCsv()
        {
            using (var reader = new StreamReader(IMPORT_FILEPATH))
            {
                using (var Csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = Csv.GetRecords<Address>().ToList();
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.FirstName + " " + data.LastName + " " + data.Email + " " + data.Phone + " " + data.City + " " + data.State + " " + data.Country);
                    }
                    using (var writer = new StreamWriter(EXPORT_FILEPATH))
                    {
                        using (var CsvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            CsvExport.WriteRecords(records);

                        }
                    }
                }
            }
        }
        public void ImplementationJson()
        {
            using (var reader = new StreamReader(IMPORT_FILEPATH))
            {
                using (var Csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = Csv.GetRecords<Address>().ToList();
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.FirstName + " " + data.LastName + " " + data.Email + " " + data.Phone + " " + data.City + " " + data.State + " " + data.Country);
                    }
                    JsonSerializer serializer = new JsonSerializer();
                    using (var writer = new StreamWriter(EXPORT_JSON_FILENAME))
                    {
                        using (var jsonWriter = new JsonTextWriter(writer))
                        {
                            serializer.Serialize(writer, records);

                        }
                    }
                }
            }
        }
    }
}

