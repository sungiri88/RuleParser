using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Newtonsoft.Json;
using System.IO;
using CsvHelper;

namespace RuleParser
{
    public partial class RuleParser : Form
    {
        public RuleParser()
        {
            InitializeComponent();
        }

        private void btn_CSVPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Upload CSV File";
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";
            openFileDialog1.FileName = "";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                if(rtxtBox_JSON.Text != string.Empty)
                btn_ProcessRule.Visible = true;
            }
        }

        private void btn_ProcessRule_Click(object sender, EventArgs e)
        {
            string filePath = openFileDialog1.FileName;
            App app = new App();
            #region Import Keyword List
            //app.UpdateKeywordListFromCSV(FilePath);
            #endregion
            #region Process Rules
            List<FieldInfo> CSVDataList = app.GetCSVData(filePath);
            #region Process JSON Data
            string json = rtxtBox_JSON.Text;
            var ro = JsonConvert.DeserializeObject<List<RootObject>>(json);
            #endregion
            DataTable dt = new DataTable();
            dt.Columns.Add("Custom Field Name");
            dt.Columns.Add("Row Name");
            dt.Columns.Add("Column Name");
            dt.Columns.Add("Value");
            
            foreach (RootObject rootObject in ro)
            {
                try {
                    FieldInfo fieldInfo = new FieldInfo();
                    foreach (Header header in rootObject.Headers)
                    {
                        if (fieldInfo == null)
                        {
                            fieldInfo = CSVDataList.FindKeyword(header.Path, int.Parse(header.Occurence) - 1);
                        }
                        else
                        {
                            fieldInfo = CSVDataList.FindKeywordAfterSpecificLine(header.Path, fieldInfo.LineNumber, int.Parse(header.Occurence) - 1);
                        }
                    }
                    dt.Rows.Add(rootObject.CustomFieldName, rootObject.RowName, rootObject.ColumnName, fieldInfo.FieldData[int.Parse(rootObject.ColOccurrence)]);
                }
                catch(Exception)
                {
                    dt.Rows.Add(rootObject.CustomFieldName, rootObject.RowName, rootObject.ColumnName, "Error occured");
                }
                
                
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

            #endregion
        }
    }
}
