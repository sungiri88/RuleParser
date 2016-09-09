using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Data;
using System.IO;

namespace RuleParser
{
    public class App
    {
        /// <summary>
        /// Reads the First Column of CSV Delimited data from CSV File path. Removes duplicate and creates 
        /// DataTable with ColumnHeaderID
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public bool UpdateKeywordListFromCSV(string FilePath)
        {
            bool status = false;
            try
            {
                List<string> keywordList = new List<string>();
                DataTable KeywordTable = new DataTable();
                DataColumn KeywordColumn = new DataColumn("Keyword");
                DataColumn ColumnHeaderID = new DataColumn("ColumnHeaderID");
                KeywordTable.Columns.Add(KeywordColumn);
                KeywordTable.Columns.Add(ColumnHeaderID);
                ColumnHeaderID.DefaultValue = 1;
                using (var streamReader = new StreamReader(FilePath))
                {
                    var csvReader = new CsvReader(streamReader);
                    csvReader.Configuration.TrimFields = true;
                    var csvParser = new CsvParser(streamReader);
                    string[] LineDataArray = csvParser.Read();
                    while (csvReader.Read())
                    {
                        
                        string keyword = csvReader.GetField(0);
                        if (keyword != string.Empty & !keywordList.Contains(keyword))
                        {
                            DataRow dr = KeywordTable.NewRow();
                            keywordList.Add(keyword);
                            dr[KeywordColumn] = keyword;
                            KeywordTable.Rows.Add(dr);
                        }
                    }
                }
                DBManager dbManager = new DBManager();
                status = dbManager.InsertKeywordList(KeywordTable);
            }
            catch(Exception Ex)
            {

            }
            return status;
        }
        /// <summary>
        /// Reads the CSV File and converts it into Rule Model class. 
        /// We use the rule model class to iterate CSV data.
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public List<FieldInfo> GetCSVData(string FilePath)
        {
            RuleModel ruleModel = new RuleModel();
            using (var streamReader = new StreamReader(FilePath))
            {
                var csvParser = new CsvParser(streamReader);
                csvParser.Configuration.TrimFields = true;
                int lineNumber = 0;
                while (true)
                {
                    var row = csvParser.Read();
                    if (row == null)
                        break;
                    else
                    {
                        row = row.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        lineNumber = lineNumber + 1;
                        if (row[0].ToString() != string.Empty && row.Count() != 0)
                        {
                            FieldInfo fieldInfo = new FieldInfo();
                            fieldInfo.LineNumber = lineNumber;
                            fieldInfo.FieldCount = row.Count();
                            fieldInfo.FieldData = row;
                            fieldInfo.Keyword = row[0].ToString();
                            ruleModel.AddToCSVDataList(fieldInfo);
                        }

                    }
                }
            }
            return ruleModel.CSVDataList;
        }
    }
}
