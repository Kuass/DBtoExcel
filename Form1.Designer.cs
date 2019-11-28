namespace DBtoExcel
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.exportsetbrowse = new System.Windows.Forms.Button();
            this.exportstart = new System.Windows.Forms.Button();
            this.importsetbrowse = new System.Windows.Forms.Button();
            this.importlabel = new System.Windows.Forms.Label();
            this.exportlabel = new System.Windows.Forms.Label();
            this.importbrowse = new System.Windows.Forms.Label();
            this.exportbrowse = new System.Windows.Forms.Label();
            this.ExportProgressbar = new System.Windows.Forms.ProgressBar();
            this.exportoptionpanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // exportsetbrowse
            // 
            this.exportsetbrowse.Location = new System.Drawing.Point(83, 41);
            this.exportsetbrowse.Name = "exportsetbrowse";
            this.exportsetbrowse.Size = new System.Drawing.Size(75, 23);
            this.exportsetbrowse.TabIndex = 0;
            this.exportsetbrowse.Text = "경로";
            this.exportsetbrowse.UseVisualStyleBackColor = true;
            this.exportsetbrowse.Click += new System.EventHandler(this.Exportsetbrowse_Click);
            // 
            // exportstart
            // 
            this.exportstart.Enabled = false;
            this.exportstart.Location = new System.Drawing.Point(12, 315);
            this.exportstart.Name = "exportstart";
            this.exportstart.Size = new System.Drawing.Size(435, 23);
            this.exportstart.TabIndex = 1;
            this.exportstart.Text = "ExportStart";
            this.exportstart.UseVisualStyleBackColor = true;
            // 
            // importsetbrowse
            // 
            this.importsetbrowse.Location = new System.Drawing.Point(83, 12);
            this.importsetbrowse.Name = "importsetbrowse";
            this.importsetbrowse.Size = new System.Drawing.Size(75, 23);
            this.importsetbrowse.TabIndex = 2;
            this.importsetbrowse.Text = "경로";
            this.importsetbrowse.UseVisualStyleBackColor = true;
            this.importsetbrowse.Click += new System.EventHandler(this.Importsetbrowse_Click);
            // 
            // importlabel
            // 
            this.importlabel.AutoSize = true;
            this.importlabel.Location = new System.Drawing.Point(21, 17);
            this.importlabel.Name = "importlabel";
            this.importlabel.Size = new System.Drawing.Size(56, 12);
            this.importlabel.TabIndex = 3;
            this.importlabel.Text = "importfile";
            // 
            // exportlabel
            // 
            this.exportlabel.AutoSize = true;
            this.exportlabel.Location = new System.Drawing.Point(21, 46);
            this.exportlabel.Name = "exportlabel";
            this.exportlabel.Size = new System.Drawing.Size(56, 12);
            this.exportlabel.TabIndex = 4;
            this.exportlabel.Text = "exportfile";
            // 
            // importbrowse
            // 
            this.importbrowse.AutoSize = true;
            this.importbrowse.Location = new System.Drawing.Point(164, 17);
            this.importbrowse.Name = "importbrowse";
            this.importbrowse.Size = new System.Drawing.Size(82, 12);
            this.importbrowse.TabIndex = 5;
            this.importbrowse.Text = "importbrowse";
            // 
            // exportbrowse
            // 
            this.exportbrowse.AutoSize = true;
            this.exportbrowse.Location = new System.Drawing.Point(164, 46);
            this.exportbrowse.Name = "exportbrowse";
            this.exportbrowse.Size = new System.Drawing.Size(82, 12);
            this.exportbrowse.TabIndex = 6;
            this.exportbrowse.Text = "exportbrowse";
            // 
            // ExportProgressbar
            // 
            this.ExportProgressbar.Location = new System.Drawing.Point(13, 342);
            this.ExportProgressbar.Name = "ExportProgressbar";
            this.ExportProgressbar.Size = new System.Drawing.Size(434, 23);
            this.ExportProgressbar.TabIndex = 7;
            // 
            // exportoptionpanel
            // 
            this.exportoptionpanel.Location = new System.Drawing.Point(13, 70);
            this.exportoptionpanel.Name = "exportoptionpanel";
            this.exportoptionpanel.Size = new System.Drawing.Size(434, 239);
            this.exportoptionpanel.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(454, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(470, 353);
            this.textBox1.TabIndex = 9;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "SQLite 파일|*.db";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 373);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.exportoptionpanel);
            this.Controls.Add(this.ExportProgressbar);
            this.Controls.Add(this.exportbrowse);
            this.Controls.Add(this.importbrowse);
            this.Controls.Add(this.exportlabel);
            this.Controls.Add(this.importlabel);
            this.Controls.Add(this.importsetbrowse);
            this.Controls.Add(this.exportstart);
            this.Controls.Add(this.exportsetbrowse);
            this.Name = "Form1";
            this.Text = "DB to Excel (SQLite)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exportsetbrowse;
        private System.Windows.Forms.Button exportstart;
        private System.Windows.Forms.Button importsetbrowse;
        private System.Windows.Forms.Label importlabel;
        private System.Windows.Forms.Label exportlabel;
        private System.Windows.Forms.Label importbrowse;
        private System.Windows.Forms.Label exportbrowse;
        private System.Windows.Forms.ProgressBar ExportProgressbar;
        private System.Windows.Forms.Panel exportoptionpanel;
        private System.Windows.Forms.TextBox textBox1;
        protected System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

