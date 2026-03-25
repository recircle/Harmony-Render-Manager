
namespace HarmonyRenderManager
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Render = new System.Windows.Forms.DataGridViewImageColumn();
            this.exportPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exportNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.framesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.framesDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exportNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exportPathDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tBfilesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttDelSelected = new System.Windows.Forms.Button();
            this.PanelForBar = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.rederingTextOutput = new System.Windows.Forms.TextBox();
            this.getFiles = new System.Windows.Forms.Button();
            this.buttAddDir = new System.Windows.Forms.Button();
            this.buttAddFile = new System.Windows.Forms.Button();
            this.buttRenderAll = new System.Windows.Forms.Button();
            this.setExportFolder = new System.Windows.Forms.Button();
            this.buttOpenFIles = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.videoCodec = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBfilesBindingSource)).BeginInit();
            this.PanelForBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowDrop = true;
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Render});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView.Location = new System.Drawing.Point(12, 88);
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
            this.dataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1165, 705);
            this.dataGridView.TabIndex = 1;
            // 
            // Render
            // 
            this.Render.HeaderText = "Render";
            this.Render.Name = "Render";
            this.Render.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Render.ToolTipText = "Render this file";
            this.Render.Width = 60;
            // 
            // exportPathDataGridViewTextBoxColumn
            // 
            this.exportPathDataGridViewTextBoxColumn.DataPropertyName = "ExportPath";
            this.exportPathDataGridViewTextBoxColumn.HeaderText = "ExportPath";
            this.exportPathDataGridViewTextBoxColumn.Name = "exportPathDataGridViewTextBoxColumn";
            // 
            // exportNameDataGridViewTextBoxColumn
            // 
            this.exportNameDataGridViewTextBoxColumn.DataPropertyName = "ExportName";
            this.exportNameDataGridViewTextBoxColumn.HeaderText = "ExportName";
            this.exportNameDataGridViewTextBoxColumn.Name = "exportNameDataGridViewTextBoxColumn";
            // 
            // framesDataGridViewTextBoxColumn
            // 
            this.framesDataGridViewTextBoxColumn.DataPropertyName = "Frames";
            this.framesDataGridViewTextBoxColumn.HeaderText = "Frames";
            this.framesDataGridViewTextBoxColumn.Name = "framesDataGridViewTextBoxColumn";
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            // 
            // pathDataGridViewTextBoxColumn1
            // 
            this.pathDataGridViewTextBoxColumn1.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn1.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn1.Name = "pathDataGridViewTextBoxColumn1";
            // 
            // framesDataGridViewTextBoxColumn1
            // 
            this.framesDataGridViewTextBoxColumn1.DataPropertyName = "Frames";
            this.framesDataGridViewTextBoxColumn1.HeaderText = "Frames";
            this.framesDataGridViewTextBoxColumn1.Name = "framesDataGridViewTextBoxColumn1";
            // 
            // exportNameDataGridViewTextBoxColumn1
            // 
            this.exportNameDataGridViewTextBoxColumn1.DataPropertyName = "ExportName";
            this.exportNameDataGridViewTextBoxColumn1.HeaderText = "ExportName";
            this.exportNameDataGridViewTextBoxColumn1.Name = "exportNameDataGridViewTextBoxColumn1";
            // 
            // exportPathDataGridViewTextBoxColumn1
            // 
            this.exportPathDataGridViewTextBoxColumn1.DataPropertyName = "ExportPath";
            this.exportPathDataGridViewTextBoxColumn1.HeaderText = "ExportPath";
            this.exportPathDataGridViewTextBoxColumn1.Name = "exportPathDataGridViewTextBoxColumn1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1202, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.logWindowToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // logWindowToolStripMenuItem
            // 
            this.logWindowToolStripMenuItem.Name = "logWindowToolStripMenuItem";
            this.logWindowToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.logWindowToolStripMenuItem.Text = "Log Window";
            this.logWindowToolStripMenuItem.Click += new System.EventHandler(this.logWindowToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renderListToolStripMenuItem,
            this.importListToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // renderListToolStripMenuItem
            // 
            this.renderListToolStripMenuItem.Name = "renderListToolStripMenuItem";
            this.renderListToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.renderListToolStripMenuItem.Text = "Export xml list";
            this.renderListToolStripMenuItem.Click += new System.EventHandler(this.renderListToolStripMenuItem_Click);
            // 
            // importListToolStripMenuItem
            // 
            this.importListToolStripMenuItem.Name = "importListToolStripMenuItem";
            this.importListToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.importListToolStripMenuItem.Text = "Import xml list";
            this.importListToolStripMenuItem.Click += new System.EventHandler(this.importListToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Render";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.ToolTipText = "Render this file";
            this.dataGridViewImageColumn1.Width = 60;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DividerWidth = 10;
            this.dataGridViewImageColumn2.FillWeight = 90F;
            this.dataGridViewImageColumn2.HeaderText = "Remove";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.ToolTipText = "Remove this file";
            this.dataGridViewImageColumn2.Width = 60;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "Status";
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Width = 60;
            // 
            // buttDelSelected
            // 
            this.buttDelSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttDelSelected.FlatAppearance.BorderSize = 0;
            this.buttDelSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttDelSelected.Image = global::HarmonyRenderManager.Properties.Resources.REMOVE_FILE;
            this.buttDelSelected.Location = new System.Drawing.Point(49, 44);
            this.buttDelSelected.Margin = new System.Windows.Forms.Padding(0);
            this.buttDelSelected.MaximumSize = new System.Drawing.Size(30, 30);
            this.buttDelSelected.MinimumSize = new System.Drawing.Size(30, 30);
            this.buttDelSelected.Name = "buttDelSelected";
            this.buttDelSelected.Size = new System.Drawing.Size(30, 30);
            this.buttDelSelected.TabIndex = 19;
            this.buttDelSelected.UseVisualStyleBackColor = true;
            // 
            // PanelForBar
            // 
            this.PanelForBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelForBar.Controls.Add(this.progressBar);
            this.PanelForBar.Location = new System.Drawing.Point(568, 64);
            this.PanelForBar.MaximumSize = new System.Drawing.Size(600, 6);
            this.PanelForBar.MinimumSize = new System.Drawing.Size(600, 6);
            this.PanelForBar.Name = "PanelForBar";
            this.PanelForBar.Size = new System.Drawing.Size(600, 6);
            this.PanelForBar.TabIndex = 18;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.progressBar.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.progressBar.Location = new System.Drawing.Point(-1, -1);
            this.progressBar.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar.MaximumSize = new System.Drawing.Size(602, 8);
            this.progressBar.MinimumSize = new System.Drawing.Size(602, 8);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(602, 8);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 9;
            // 
            // rederingTextOutput
            // 
            this.rederingTextOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rederingTextOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rederingTextOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rederingTextOutput.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.rederingTextOutput.Location = new System.Drawing.Point(568, 47);
            this.rederingTextOutput.Name = "rederingTextOutput";
            this.rederingTextOutput.Size = new System.Drawing.Size(300, 13);
            this.rederingTextOutput.TabIndex = 17;
            // 
            // getFiles
            // 
            this.getFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getFiles.ForeColor = System.Drawing.Color.Silver;
            this.getFiles.Location = new System.Drawing.Point(170, 48);
            this.getFiles.Name = "getFiles";
            this.getFiles.Size = new System.Drawing.Size(85, 23);
            this.getFiles.TabIndex = 16;
            this.getFiles.Text = "GET FILES";
            this.getFiles.UseVisualStyleBackColor = true;
            // 
            // buttAddDir
            // 
            this.buttAddDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttAddDir.FlatAppearance.BorderSize = 0;
            this.buttAddDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttAddDir.Image = global::HarmonyRenderManager.Properties.Resources.ADD_FOLDER;
            this.buttAddDir.Location = new System.Drawing.Point(86, 44);
            this.buttAddDir.Margin = new System.Windows.Forms.Padding(0);
            this.buttAddDir.MaximumSize = new System.Drawing.Size(30, 30);
            this.buttAddDir.Name = "buttAddDir";
            this.buttAddDir.Size = new System.Drawing.Size(30, 30);
            this.buttAddDir.TabIndex = 15;
            this.buttAddDir.UseVisualStyleBackColor = true;
            // 
            // buttAddFile
            // 
            this.buttAddFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttAddFile.FlatAppearance.BorderSize = 0;
            this.buttAddFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttAddFile.Image = global::HarmonyRenderManager.Properties.Resources.ADD_FILE;
            this.buttAddFile.Location = new System.Drawing.Point(13, 44);
            this.buttAddFile.Margin = new System.Windows.Forms.Padding(0);
            this.buttAddFile.Name = "buttAddFile";
            this.buttAddFile.Size = new System.Drawing.Size(30, 30);
            this.buttAddFile.TabIndex = 14;
            this.buttAddFile.UseVisualStyleBackColor = true;
            // 
            // buttRenderAll
            // 
            this.buttRenderAll.FlatAppearance.BorderSize = 0;
            this.buttRenderAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttRenderAll.Image = global::HarmonyRenderManager.Properties.Resources.RENDER_ALL;
            this.buttRenderAll.Location = new System.Drawing.Point(122, 44);
            this.buttRenderAll.Margin = new System.Windows.Forms.Padding(0);
            this.buttRenderAll.Name = "buttRenderAll";
            this.buttRenderAll.Size = new System.Drawing.Size(30, 30);
            this.buttRenderAll.TabIndex = 13;
            this.buttRenderAll.UseVisualStyleBackColor = true;
            this.buttRenderAll.Click += new System.EventHandler(this.buttRenderAll_Click);
            // 
            // setExportFolder
            // 
            this.setExportFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setExportFolder.ForeColor = System.Drawing.Color.Silver;
            this.setExportFolder.Location = new System.Drawing.Point(275, 48);
            this.setExportFolder.Name = "setExportFolder";
            this.setExportFolder.Size = new System.Drawing.Size(110, 23);
            this.setExportFolder.TabIndex = 20;
            this.setExportFolder.Text = "EXPORT FOLDER";
            this.setExportFolder.UseVisualStyleBackColor = true;
            // 
            // buttOpenFIles
            // 
            this.buttOpenFIles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttOpenFIles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttOpenFIles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttOpenFIles.ForeColor = System.Drawing.Color.Silver;
            this.buttOpenFIles.Location = new System.Drawing.Point(360, 811);
            this.buttOpenFIles.Margin = new System.Windows.Forms.Padding(0);
            this.buttOpenFIles.MaximumSize = new System.Drawing.Size(90, 30);
            this.buttOpenFIles.MinimumSize = new System.Drawing.Size(30, 30);
            this.buttOpenFIles.Name = "buttOpenFIles";
            this.buttOpenFIles.Size = new System.Drawing.Size(89, 30);
            this.buttOpenFIles.TabIndex = 25;
            this.buttOpenFIles.Text = "OPEN FILES";
            this.buttOpenFIles.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(18, 816);
            this.label5.MaximumSize = new System.Drawing.Size(120, 15);
            this.label5.MinimumSize = new System.Drawing.Size(120, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "Export settings";
            // 
            // videoCodec
            // 
            this.videoCodec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.videoCodec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoCodec.FormattingEnabled = true;
            this.videoCodec.Items.AddRange(new object[] {
            "proresHQ",
            "proresLT",
            "prores444",
            "prores4444Alpha"});
            this.videoCodec.Location = new System.Drawing.Point(135, 814);
            this.videoCodec.Name = "videoCodec";
            this.videoCodec.Size = new System.Drawing.Size(207, 21);
            this.videoCodec.TabIndex = 23;
            this.videoCodec.SelectedIndexChanged += new System.EventHandler(this.videoCodec_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1202, 861);
            this.Controls.Add(this.buttOpenFIles);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.videoCodec);
            this.Controls.Add(this.setExportFolder);
            this.Controls.Add(this.buttDelSelected);
            this.Controls.Add(this.PanelForBar);
            this.Controls.Add(this.rederingTextOutput);
            this.Controls.Add(this.getFiles);
            this.Controls.Add(this.buttAddDir);
            this.Controls.Add(this.buttAddFile);
            this.Controls.Add(this.buttRenderAll);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "HarmonyRender 22";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBfilesBindingSource)).EndInit();
            this.PanelForBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn exportPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exportNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn framesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn framesDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn exportNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn exportPathDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource tBfilesBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importListToolStripMenuItem;
        private System.Windows.Forms.DataGridViewImageColumn Render;
        private System.Windows.Forms.ToolStripMenuItem logWindowToolStripMenuItem;
        private System.Windows.Forms.Button buttDelSelected;
        private System.Windows.Forms.Panel PanelForBar;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox rederingTextOutput;
        private System.Windows.Forms.Button getFiles;
        private System.Windows.Forms.Button buttAddDir;
        private System.Windows.Forms.Button buttAddFile;
        private System.Windows.Forms.Button buttRenderAll;
        private System.Windows.Forms.Button setExportFolder;
        private System.Windows.Forms.Button buttOpenFIles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox videoCodec;
    }
}

