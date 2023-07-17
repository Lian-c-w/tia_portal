using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
//using FunctionManager;



namespace FileManager
{
   
    public class ExcelManager
    {
        OpenFileDialog myExcelfile = new OpenFileDialog();
        
        DataSet ds= new DataSet();

        public DataSet myDS
        { get;set; }
        public DataTable myDT
        { get; set; }

        public void GetData(string ExcelPath)
        {
            //Moduletype md = new Moduletype();
            bool hasTitle = false;
            //OpenFileDialog myExcelfile = new OpenFileDialog();
            //myExcelfile.Filter = "*.xlsx|*.xlsx";
            //myExcelfile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Recent);
            //myExcelfile.ShowDialog();
            //var filePath = myExcelfile.FileName;
            string filePath = ExcelPath;
            string fileType = System.IO.Path.GetExtension(filePath);

            string strCom = "SELECT * FROM all_tables";

            string strCon = string.Format("Provider=Microsoft.ACE.OLEDB.{0}.0;" +
                        "Extended Properties=\"Excel {1}.0;HDR={2};IMEX=1;\";" +
                        "data source={3};",
                        (fileType == ".xls" ? 4 : 12), (fileType == ".xls" ? 8 : 12), (hasTitle ? "Yes" : "NO"), filePath);
            //string strCom = " SELECT * FROM all_tables";//[Sheet1$]";
            //string strCon = @"E:\OpennessUsageV15_1\Data\TotalStation.xlsx";

            try
            {
                //DataTable schemaTable = Conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                //获取Excel的第一个Sheet表名
                OleDbConnection myConn = new OleDbConnection(strCon);
                myConn.Open();
                DataTable schemaTable = myConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                for (int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    string tableName = schemaTable.Rows[i][2].ToString().Trim();                             
                    strCom = "select * from [" + tableName + "]";
                    OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
                    //myConn.Open();
                    myCommand.Fill(ds,tableName);
                }
                myDS = ds;
                myDT = ds.Tables[0];
                string aa = myDT.Rows[0][2].ToString();
                myConn.Close();
            }
            catch(Exception e)
            {
                ;
            }

            
        }
        public int CountMax(bool SubNet,bool PNIO,bool Topu)
        {
            int count = 0;
            try
            {
                for (int i = 0; i < myDS.Tables.Count; i++)
                {
                    for (int j = 1; j < myDS.Tables[i].Rows.Count; j++)
                    {
                        count++;
                    }
                }
                if (SubNet == true)
                {
                    for (int i = 0; i < myDS.Tables.Count; i++)
                    {
                        count++;
                    }
                }
                if (PNIO == true)
                {
                    for (int i = 0; i < myDS.Tables.Count; i++)
                    {
                        count++;
                    }
                }
                if (Topu == true)
                {
                    for (int i = 0; i < myDS.Tables.Count - 1; i++)
                    {
                        count++;
                    }
                }
                return count;
            }
            catch (Exception exp)
            {
                return 0;
            }
        }
    }
}
