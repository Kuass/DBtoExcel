using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DBtoExcel
{
    public partial class Form1 : Form
    {
        public static string OpenDirectory;
        public static string SaveDirectory;

        protected static Form1 mClass = null;

        public static Form1 GetClass()
        {
            return mClass;
        }

        public Form1()
        {
            InitializeComponent();
            exportoptionpanel.Controls.Clear();
            mClass = this;
            ConsoleText("프로그램 준비됨");
        }

        private void OptionAlgorith()
        {
            if (OpenDirectory != null && SaveDirectory != null)
            {
                RadioButton rbtn = new RadioButton();
                rbtn.Click += new EventHandler(ButtonEvent);
                rbtn.Location = new Point(10, 10);
                rbtn.Size = new Size(300, 35);
                rbtn.Font = new Font("Arial", 15, FontStyle.Bold);
                rbtn.Text = "모든 테이블";
                exportoptionpanel.Controls.Add(rbtn);
            }
            else
            {
                exportoptionpanel.Controls.Clear();
                return;
            }
        }

        public void END()
        {
            exportoptionpanel.Controls.Clear();
        }

        private void ButtonEvent(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            if(btn.Text == "모든 테이블")
            {
                SQLiteM.getSQLiteM().ExportMain(1);
            }
            else
            {
                ConsoleText("`E01` 옵션을 불러오는대 문제가 발생하였습니다.");
                return;
            }
        }
        
        private void Importsetbrowse_Click(object sender, EventArgs e)
        {
            ShowFileOpenDialog();
        }

        public void ShowFileOpenDialog()
        {
            openFileDialog1.Filter = "SQLite 파일|*.db;*.sqlite;*.sqlite3;*.db3";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                importbrowse.Controls.Clear();
                OpenDirectory = openFileDialog1.FileName;
                this.importbrowse.Text = OpenDirectory;
                ConsoleText("해당 파일로 대기 " + OpenDirectory);
            }
            OptionAlgorith();
        }

        private void Exportsetbrowse_Click(object sender, EventArgs e)
        {
            SaveFileSelectDialog();
        }

        public void SaveFileSelectDialog()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveDirectory = folderBrowserDialog1.SelectedPath;
                this.exportbrowse.Text = SaveDirectory;
                ConsoleText("저장대상폴더 설정 " + SaveDirectory);
            }
            OptionAlgorith();
        }

        public void ConsoleText(string content)
        {
            textBox1.Text += content + Environment.NewLine;
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }
    }
}
