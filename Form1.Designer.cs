namespace Fastboot_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Device_Selected = new System.Windows.Forms.ComboBox();
            this.Device_RefreshButton = new System.Windows.Forms.Button();
            this.flash_btn = new System.Windows.Forms.Button();
            this.flash_selectFileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.partition_selected = new System.Windows.Forms.ComboBox();
            this.partition_refresh = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dump_outfile = new System.Windows.Forms.Button();
            this.dump_dumpBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fastboot-GUI";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Device_Selected);
            this.groupBox1.Controls.Add(this.Device_RefreshButton);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(13, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 77);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device selection";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Device_Selected
            // 
            this.Device_Selected.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Device_Selected.FormattingEnabled = true;
            this.Device_Selected.Location = new System.Drawing.Point(7, 20);
            this.Device_Selected.Name = "Device_Selected";
            this.Device_Selected.Size = new System.Drawing.Size(149, 21);
            this.Device_Selected.TabIndex = 1;
            // 
            // Device_RefreshButton
            // 
            this.Device_RefreshButton.Location = new System.Drawing.Point(6, 47);
            this.Device_RefreshButton.Name = "Device_RefreshButton";
            this.Device_RefreshButton.Size = new System.Drawing.Size(150, 23);
            this.Device_RefreshButton.TabIndex = 0;
            this.Device_RefreshButton.Text = "Refresh";
            this.Device_RefreshButton.UseVisualStyleBackColor = true;
            this.Device_RefreshButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // flash_btn
            // 
            this.flash_btn.Location = new System.Drawing.Point(6, 35);
            this.flash_btn.Name = "flash_btn";
            this.flash_btn.Size = new System.Drawing.Size(153, 26);
            this.flash_btn.TabIndex = 3;
            this.flash_btn.Text = "FLASH";
            this.flash_btn.UseVisualStyleBackColor = true;
            this.flash_btn.Click += new System.EventHandler(this.flash_btn_Click);
            // 
            // flash_selectFileButton
            // 
            this.flash_selectFileButton.Location = new System.Drawing.Point(6, 6);
            this.flash_selectFileButton.Name = "flash_selectFileButton";
            this.flash_selectFileButton.Size = new System.Drawing.Size(756, 23);
            this.flash_selectFileButton.TabIndex = 0;
            this.flash_selectFileButton.Text = "Select File";
            this.flash_selectFileButton.UseVisualStyleBackColor = true;
            this.flash_selectFileButton.Click += new System.EventHandler(this.flash_selectFileButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.partition_selected);
            this.groupBox3.Controls.Add(this.partition_refresh);
            this.groupBox3.Location = new System.Drawing.Point(182, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 77);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Partition Selection";
            // 
            // partition_selected
            // 
            this.partition_selected.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partition_selected.FormattingEnabled = true;
            this.partition_selected.Location = new System.Drawing.Point(6, 19);
            this.partition_selected.Name = "partition_selected";
            this.partition_selected.Size = new System.Drawing.Size(187, 21);
            this.partition_selected.TabIndex = 1;
            // 
            // partition_refresh
            // 
            this.partition_refresh.Location = new System.Drawing.Point(6, 46);
            this.partition_refresh.Name = "partition_refresh";
            this.partition_refresh.Size = new System.Drawing.Size(187, 23);
            this.partition_refresh.TabIndex = 0;
            this.partition_refresh.Text = "Refresh";
            this.partition_refresh.UseVisualStyleBackColor = true;
            this.partition_refresh.Click += new System.EventHandler(this.partition_refresh_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 126);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 312);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flash_btn);
            this.tabPage1.Controls.Add(this.flash_selectFileButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Flashing";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dump_dumpBtn);
            this.tabPage2.Controls.Add(this.dump_outfile);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 286);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dumping";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dump_outfile
            // 
            this.dump_outfile.Location = new System.Drawing.Point(7, 7);
            this.dump_outfile.Name = "dump_outfile";
            this.dump_outfile.Size = new System.Drawing.Size(755, 23);
            this.dump_outfile.TabIndex = 0;
            this.dump_outfile.Text = "Select output file (*.img)";
            this.dump_outfile.UseVisualStyleBackColor = true;
            this.dump_outfile.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dump_dumpBtn
            // 
            this.dump_dumpBtn.Location = new System.Drawing.Point(7, 37);
            this.dump_dumpBtn.Name = "dump_dumpBtn";
            this.dump_dumpBtn.Size = new System.Drawing.Size(152, 23);
            this.dump_dumpBtn.TabIndex = 1;
            this.dump_dumpBtn.Text = "Dump";
            this.dump_dumpBtn.UseVisualStyleBackColor = true;
            this.dump_dumpBtn.Click += new System.EventHandler(this.dump_dumpBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Fastboot-GUI";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Device_RefreshButton;
        private System.Windows.Forms.ComboBox Device_Selected;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button flash_selectFileButton;
        private System.Windows.Forms.Button flash_btn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox partition_selected;
        private System.Windows.Forms.Button partition_refresh;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button dump_outfile;
        private System.Windows.Forms.Button dump_dumpBtn;
    }
}

