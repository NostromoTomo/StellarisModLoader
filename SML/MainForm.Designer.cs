namespace SML
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainModPanel = new System.Windows.Forms.Panel();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ImportListButton = new System.Windows.Forms.Button();
            this.ExportListButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Title = new System.Windows.Forms.Label();
            this.Subtitle = new System.Windows.Forms.Label();
            this.SelectDirectoryButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // MainModPanel
            // 
            this.MainModPanel.AutoScroll = true;
            this.MainModPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainModPanel.Location = new System.Drawing.Point(12, 187);
            this.MainModPanel.Name = "MainModPanel";
            this.MainModPanel.Size = new System.Drawing.Size(800, 600);
            this.MainModPanel.TabIndex = 1;
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.Location = new System.Drawing.Point(819, 443);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(149, 39);
            this.MoveDownButton.TabIndex = 2;
            this.MoveDownButton.Text = "Move Down";
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(818, 232);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(149, 39);
            this.ResetButton.TabIndex = 3;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.Location = new System.Drawing.Point(819, 398);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(149, 39);
            this.MoveUpButton.TabIndex = 4;
            this.MoveUpButton.Text = "Move Up";
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(818, 703);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(149, 39);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(818, 748);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(149, 39);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ImportListButton
            // 
            this.ImportListButton.Location = new System.Drawing.Point(818, 613);
            this.ImportListButton.Name = "ImportListButton";
            this.ImportListButton.Size = new System.Drawing.Size(149, 39);
            this.ImportListButton.TabIndex = 7;
            this.ImportListButton.Text = "Import Order List";
            this.ImportListButton.UseVisualStyleBackColor = true;
            this.ImportListButton.Click += new System.EventHandler(this.ImportListButton_Click);
            // 
            // ExportListButton
            // 
            this.ExportListButton.Location = new System.Drawing.Point(818, 658);
            this.ExportListButton.Name = "ExportListButton";
            this.ExportListButton.Size = new System.Drawing.Size(149, 39);
            this.ExportListButton.TabIndex = 8;
            this.ExportListButton.Text = "Export Order List";
            this.ExportListButton.UseVisualStyleBackColor = true;
            this.ExportListButton.Click += new System.EventHandler(this.ExportListButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Malgun Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(380, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(256, 45);
            this.Title.TabIndex = 9;
            this.Title.Text = "S T E L L A R I S";
            // 
            // Subtitle
            // 
            this.Subtitle.AutoSize = true;
            this.Subtitle.BackColor = System.Drawing.Color.Transparent;
            this.Subtitle.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subtitle.ForeColor = System.Drawing.Color.White;
            this.Subtitle.Location = new System.Drawing.Point(415, 54);
            this.Subtitle.Name = "Subtitle";
            this.Subtitle.Size = new System.Drawing.Size(168, 30);
            this.Subtitle.TabIndex = 10;
            this.Subtitle.Text = "Mod List Loader";
            // 
            // SelectDirectoryButton
            // 
            this.SelectDirectoryButton.Location = new System.Drawing.Point(818, 187);
            this.SelectDirectoryButton.Name = "SelectDirectoryButton";
            this.SelectDirectoryButton.Size = new System.Drawing.Size(149, 39);
            this.SelectDirectoryButton.TabIndex = 11;
            this.SelectDirectoryButton.Text = "Select Directory";
            this.SelectDirectoryButton.UseVisualStyleBackColor = true;
            this.SelectDirectoryButton.Click += new System.EventHandler(this.SelectDirectoryButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(980, 800);
            this.Controls.Add(this.SelectDirectoryButton);
            this.Controls.Add(this.Subtitle);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.ExportListButton);
            this.Controls.Add(this.ImportListButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.MoveUpButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.MoveDownButton);
            this.Controls.Add(this.MainModPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel MainModPanel;
        private System.Windows.Forms.Button MoveDownButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button MoveUpButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ImportListButton;
        private System.Windows.Forms.Button ExportListButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Subtitle;
        private System.Windows.Forms.Button SelectDirectoryButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

