namespace MKLinkHelper_WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SelectFolders_bt = new Button();
            SelectFiles_fn = new OpenFileDialog();
            SelectFolders_fn = new FolderBrowserDialog();
            InputFolders = new TextBox();
            SelectFiles_bt = new Button();
            InputFiles = new TextBox();
            LOG_label = new Label();
            LogText = new TextBox();
            SelectOutputs_bt = new Button();
            OutputFolders = new TextBox();
            CreateFoldersSymlinks = new Button();
            CreateFolderJucntions = new Button();
            CreateFileSymlinks = new Button();
            CreateFileHardlinks = new Button();
            OutputLogToText = new Button();
            SuspendLayout();
            // 
            // SelectFolders_bt
            // 
            SelectFolders_bt.Location = new Point(12, 12);
            SelectFolders_bt.Name = "SelectFolders_bt";
            SelectFolders_bt.Size = new Size(94, 24);
            SelectFolders_bt.TabIndex = 0;
            SelectFolders_bt.Text = "Select Folders";
            SelectFolders_bt.UseVisualStyleBackColor = true;
            SelectFolders_bt.Click += SelectFolders_bt_Click;
            // 
            // InputFolders
            // 
            InputFolders.AllowDrop = true;
            InputFolders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            InputFolders.Location = new Point(112, 14);
            InputFolders.Name = "InputFolders";
            InputFolders.PlaceholderText = "Select Folders you want make Symlinks or Junctions of. You can drag and drop here";
            InputFolders.Size = new Size(580, 23);
            InputFolders.TabIndex = 3;
            // 
            // SelectFiles_bt
            // 
            SelectFiles_bt.Location = new Point(12, 41);
            SelectFiles_bt.Name = "SelectFiles_bt";
            SelectFiles_bt.Size = new Size(94, 23);
            SelectFiles_bt.TabIndex = 4;
            SelectFiles_bt.Text = "Select Files";
            SelectFiles_bt.UseVisualStyleBackColor = true;
            SelectFiles_bt.Click += SelectFiles_bt_Click;
            // 
            // InputFiles
            // 
            InputFiles.AllowDrop = true;
            InputFiles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            InputFiles.Location = new Point(112, 42);
            InputFiles.Name = "InputFiles";
            InputFiles.PlaceholderText = "Select Files you want make Symlinks or Hardlinks of. You can drag and drop here";
            InputFiles.Size = new Size(580, 23);
            InputFiles.TabIndex = 5;
            // 
            // LOG_label
            // 
            LOG_label.AutoSize = true;
            LOG_label.BorderStyle = BorderStyle.FixedSingle;
            LOG_label.Location = new Point(13, 70);
            LOG_label.Name = "LOG_label";
            LOG_label.Size = new Size(32, 17);
            LOG_label.TabIndex = 6;
            LOG_label.Text = "LOG";
            // 
            // LogText
            // 
            LogText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LogText.Location = new Point(12, 90);
            LogText.Multiline = true;
            LogText.Name = "LogText";
            LogText.ReadOnly = true;
            LogText.Size = new Size(680, 284);
            LogText.TabIndex = 7;
            LogText.WordWrap = false;
            // 
            // SelectOutputs_bt
            // 
            SelectOutputs_bt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SelectOutputs_bt.Location = new Point(13, 380);
            SelectOutputs_bt.Name = "SelectOutputs_bt";
            SelectOutputs_bt.Size = new Size(94, 23);
            SelectOutputs_bt.TabIndex = 8;
            SelectOutputs_bt.Text = "Select Outputs";
            SelectOutputs_bt.UseVisualStyleBackColor = true;
            // 
            // OutputFolders
            // 
            OutputFolders.AllowDrop = true;
            OutputFolders.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OutputFolders.Location = new Point(113, 381);
            OutputFolders.Name = "OutputFolders";
            OutputFolders.PlaceholderText = "Select Folders you want output to. You can drag and drop here";
            OutputFolders.Size = new Size(579, 23);
            OutputFolders.TabIndex = 9;
            // 
            // CreateFoldersSymlinks
            // 
            CreateFoldersSymlinks.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CreateFoldersSymlinks.Location = new Point(12, 409);
            CreateFoldersSymlinks.Name = "CreateFoldersSymlinks";
            CreateFoldersSymlinks.Size = new Size(144, 23);
            CreateFoldersSymlinks.TabIndex = 10;
            CreateFoldersSymlinks.Text = "Create Folder Symlinks";
            CreateFoldersSymlinks.UseVisualStyleBackColor = true;
            CreateFoldersSymlinks.Click += CreateFoldersSymlinks_Click;
            // 
            // CreateFolderJucntions
            // 
            CreateFolderJucntions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CreateFolderJucntions.Location = new Point(12, 438);
            CreateFolderJucntions.Name = "CreateFolderJucntions";
            CreateFolderJucntions.Size = new Size(144, 23);
            CreateFolderJucntions.TabIndex = 11;
            CreateFolderJucntions.Text = "Create Folder Junctions";
            CreateFolderJucntions.UseVisualStyleBackColor = true;
            CreateFolderJucntions.Click += CreateFolderJucntions_Click;
            // 
            // CreateFileSymlinks
            // 
            CreateFileSymlinks.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CreateFileSymlinks.Location = new Point(162, 410);
            CreateFileSymlinks.Name = "CreateFileSymlinks";
            CreateFileSymlinks.Size = new Size(144, 23);
            CreateFileSymlinks.TabIndex = 12;
            CreateFileSymlinks.Text = "Create File Symlinks";
            CreateFileSymlinks.UseVisualStyleBackColor = true;
            CreateFileSymlinks.Click += CreateFileSymlinks_Click;
            // 
            // CreateFileHardlinks
            // 
            CreateFileHardlinks.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CreateFileHardlinks.Location = new Point(162, 439);
            CreateFileHardlinks.Name = "CreateFileHardlinks";
            CreateFileHardlinks.Size = new Size(144, 23);
            CreateFileHardlinks.TabIndex = 13;
            CreateFileHardlinks.Text = "Create File Hardlinks";
            CreateFileHardlinks.UseVisualStyleBackColor = true;
            CreateFileHardlinks.Click += CreateFileHardlinks_Click;
            // 
            // OutputLogToText
            // 
            OutputLogToText.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            OutputLogToText.Location = new Point(548, 410);
            OutputLogToText.Name = "OutputLogToText";
            OutputLogToText.Size = new Size(144, 23);
            OutputLogToText.TabIndex = 14;
            OutputLogToText.Text = "Save LOG to text";
            OutputLogToText.UseVisualStyleBackColor = true;
            OutputLogToText.Click += OutputLogToText_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(704, 473);
            Controls.Add(OutputLogToText);
            Controls.Add(CreateFileHardlinks);
            Controls.Add(CreateFileSymlinks);
            Controls.Add(CreateFolderJucntions);
            Controls.Add(CreateFoldersSymlinks);
            Controls.Add(OutputFolders);
            Controls.Add(SelectOutputs_bt);
            Controls.Add(LogText);
            Controls.Add(LOG_label);
            Controls.Add(InputFiles);
            Controls.Add(SelectFiles_bt);
            Controls.Add(InputFolders);
            Controls.Add(SelectFolders_bt);
            MinimumSize = new Size(484, 270);
            Name = "Form1";
            Text = "MKLink Helper";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button SelectFolders_bt;
        private OpenFileDialog SelectFiles_fn;
        private FolderBrowserDialog SelectFolders_fn;
        private TextBox InputFolders;
        private Button SelectFiles_bt;
        private TextBox InputFiles;
        private Label LOG_label;
        private TextBox LogText;
        private Button SelectOutputs_bt;
        private TextBox OutputFolders;
        private Button CreateFoldersSymlinks;
        private Button CreateFolderJucntions;
        private Button CreateFileSymlinks;
        private Button CreateFileHardlinks;
        private Button OutputLogToText;
    }
}
