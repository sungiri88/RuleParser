using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleParser
{

    /*
    JSON Format

    All the column Names will be displayed for each table.
    For Tranche Performance, They have to set 7 times.
    "Rules" : {"Name": "RuleTypeAFormat", "Type":"A", "DataType": "string", "DataFormat":"" "ColumnOccurence": "2", 
                                               "Hirarchy": [{"Name": "K5", "Occurence": "1"},
                                                            {"Name": "K6", "Occurence": "1"}
                                                           ] 
              }
     
   
    */
    /// <summary>
    /// RuleModel Class stores the CSV Data in a structured way. 
    /// Basically, we need Field Count and Field Data. Field Info is mapped to Keyword. 
    /// Keyword is nothing but the first column value.
    /// </summary>
    public class RuleModel
    {
        public List<FieldInfo> CSVDataList { get; set; }
        public RuleModel()
        {
            CSVDataList = new List<FieldInfo>();
        }
        public void AddToCSVDataList(FieldInfo fieldInfo)
        {
            CSVDataList.Add(fieldInfo);
        }
    }
    /// <summary>
    /// FieldInfo stores the details pertaining to each row in CSV file.
    /// </summary>
    public class FieldInfo
    {
        public int LineNumber { get; set; }
        public int FieldCount { get; set; }
        public string Keyword { get; set; }
        public string[] FieldData { get; set; }
    }
    public class Header
    {
        public string Path { get; set; }
        public string Occurence { get; set; }
    }

    public class RootObject
    {
        public string CustomFieldName { get; set; }
        public List<Header> Headers { get; set; }
        public string RowName { get; set; }
        public string ColumnName { get; set; }
        public string ColOccurrence { get; set; }
        public string Format { get; set; }
    }
    public class RuleArray
    {
        public RootObject RootObject{ get;set;}
    }

}
