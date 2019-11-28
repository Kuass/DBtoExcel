using System;
using System.Diagnostics;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DBtoExcel
{
    public class SQLiteM
    {
        protected SQLiteConnection sql_con;
        protected SQLiteDataReader sql_reader;
        protected SQLiteCommand sql_cmd;
        protected SQLiteDataAdapter sql_adapter;
        public static DataSet DS = new DataSet();
        public static DataTable DT = new DataTable();

        public static string Directory;

        protected static SQLiteM mSQLiteM = null;

        public static SQLiteM getSQLiteM()
        {
            if (mSQLiteM == null)
            {
                mSQLiteM = new SQLiteM();
            }
            return mSQLiteM;
        }

        public void ExportMain(int Sequence)
        {
            currenttable = null;
            tablecount = 0;
            columcount = 0;
            ColumList = new List<string>(){};
            Form1.GetClass().ConsoleText("시퀸스 "+ Sequence);
            Excel.Application excelApp = new Excel.Application();
            if (excelApp == null)
            {
                Form1.GetClass().ConsoleText("`E20` 엑셀이 설치되지 않았습니다.");
                return;
            }

            if (Sequence == 1)
            {
                AllTable();
            }
            else
            {
                Form1.GetClass().ConsoleText("알 수 없는 시퀸스 번호입니다.");
            }
        }

        protected string currenttable;
        protected int tablecount;
        protected int columcount;
        protected List<string> ColumList = new List<string>(){};
        private void AllTable()
        {
            Form1.GetClass().ConsoleText("데이터베이스에 연결하는 중... (1/4)");
            SetConnection();
            sql_con.Open();

            sql_adapter = new SQLiteDataAdapter("SELECT name FROM sqlite_master WHERE type='table';", sql_con);
            sql_adapter.Fill(DS);

            if (DS.Tables.Count == 0)
            {
                Form1.GetClass().ConsoleText("`40` 데이터베이스가 유효하지 않습니다.");
            }
            else
            {
                foreach (DataRow r in DS.Tables[0].Rows)
                {
                    currenttable = ObjToString(r["name"]);
                    Form1.GetClass().ConsoleText(currenttable);
                    tablecount++;
                }
            }
            Form1.GetClass().ConsoleText("총 " + tablecount + "개의 테이블을 불러왔습니다. (2/4)");

            sql_adapter = new SQLiteDataAdapter("PRAGMA table_info("+ currenttable + ");", sql_con);
            sql_adapter.Fill(DS);

            foreach (DataRow r in DS.Tables[0].Rows)
            {
                string Temp = ObjToString(r[0]);
                if (Temp == currenttable)
                {
                    continue;
                }
                else
                {
                    ColumList.Add(Temp);
                    Form1.GetClass().ConsoleText(Temp);
                    columcount++;
                }
            }
            Form1.GetClass().ConsoleText("총 " + columcount + "개의 컬럼을 불러왔습니다. (3/4)");
            
            Form1.GetClass().ConsoleText("테이블의 데이터를 불러왔습니다. (4/4)");


            Excel.Application excelApp = null;
            Excel.Workbook wb = null;
            Excel.Worksheet ws = null;
            
            try
            {
                Form1.GetClass().ConsoleText("엑셀을 불러오는 중...");
                excelApp = new Excel.Application();

                Form1.GetClass().ConsoleText("엑셀을 준비하는 중...");
                wb = excelApp.Workbooks.Add();
                ws = wb.Worksheets.get_Item(1) as Excel.Worksheet;

                Form1.GetClass().ConsoleText("데이터를 준비하는 중...");
                for (int i = 0; i < columcount; i++) // 컬럼단위
                {
                    int j = 2 - i;
                    Form1.GetClass().ConsoleText("데이터를 가공하는 중... ("+i+"/"+columcount+")");

                    ws.Cells[1, i + 1] = ColumList[i];
                    sql_cmd = new SQLiteCommand("SELECT " + ColumList[i] + " FROM " + currenttable, sql_con);
                    sql_reader = sql_cmd.ExecuteReader();
                    while (sql_reader.Read())
                    {
                        ws.Cells[i + j, i + 1] = sql_reader[ColumList[i]];
                        j++;
                    }
                }

                // 엑셀파일 저장
                Directory = Form1.SaveDirectory + "\\SQLiteToExcel-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                try
                {
                    wb.SaveAs(@Directory, Excel.XlFileFormat.xlWorkbookNormal);
                    wb.Close(true);
                    excelApp.Quit();
                }
                catch(Exception ex)
                {
                    Console.Write(ex);
                }
            }
            finally
            {
                // Clean up
                Form1.GetClass().ConsoleText("릴리즈 준비...");
                ReleaseExcelObject(ws);
                ReleaseExcelObject(wb);
                ReleaseExcelObject(excelApp);
                sql_con.Close();
            }
            DS = new DataSet();
            DT = new DataTable();
            Form1.GetClass().ConsoleText("절차완료 "+ Directory +" 에 저장됨");
            Form1.GetClass().END();
        }
        
        private static void ReleaseExcelObject(object obj)
        {
            Form1.GetClass().ConsoleText("릴리즈 " + obj);
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source=" + Form1.OpenDirectory + ";Version=3;New=false;Compress=True;");
        }

        private string ObjToString(object p)
        {
            string strRef = "";

            if (p == null)
            {
                strRef = "";
            }
            else
            {
                strRef = p.ToString();
            }

            return strRef;
        }
    }
}
