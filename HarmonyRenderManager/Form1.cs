using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace HarmonyRenderManager
{
    public partial class Form1 : Form
    {
        private string harmonyPath;
        private string episodePath;
        private LogWindow _logWindow = new LogWindow();

        private int renderProres = 0;
        private string renderExportPath = "";
        private string episodePrefix;

        public Form1()
        {
            InitializeComponent();
            SetupUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // auto open log window
            //OpenLog();

        }

        private void SetupUI()
        {
            this.Text = "Harmony Render Menager";
            this.Size = new System.Drawing.Size(1200, 900);

            videoCodec.SelectedItem = "proresHQ";

            getFiles.Click += async (s, e) => await LoadDataAsync();
            setExportFolder.Click += setExportFolder_Click;
            //renderListToolStripMenuItem.Click += (s, e) => ExportToXml();
            //importListToolStripMenuItem.Click += (s, e) => ImportFromXml();

            dataGridView.AllowDrop = true;
            dataGridView.DragEnter += DataGridView_DragEnter;
            dataGridView.DragDrop += DataGridView_DragDrop;
            dataGridView.CellMouseDown += dataGridView_CellMouseDown;
            dataGridView.CellMouseEnter += dataGridView_CellMouseEnter;

            //dataGridView.CellClick += DgvCompare_CellClick;

            dataGridView.CellContentClick += DataGridView_CellContentClick;

            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = dataGridView.BackgroundColor;
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = dataGridView.BackgroundColor;

            // auto fill Harmony default location
            if (string.IsNullOrEmpty(Properties.Settings.Default.HarmonyPath))
            {
                Properties.Settings.Default.HarmonyPath = @"C:\Program Files (x86)\Toon Boom Animation\Toon Boom Harmony 24.1 Premium\win64\bin\HarmonyPremium.exe";
                Properties.Settings.Default.Save();
            }

            harmonyPath = Properties.Settings.Default.HarmonyPath;
        }

        private void OpenLog()
        {
            if (_logWindow == null || _logWindow.IsDisposed)
                _logWindow = new LogWindow();

            _logWindow.StartPosition = FormStartPosition.Manual;
            _logWindow.Left = this.Left + this.Width;
            _logWindow.Top = this.Top;
            _logWindow.Show();
            _logWindow.BringToFront();
        }

        private async Task LoadDataAsync()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                string savedPath = Properties.Settings.Default.LastPath;

                if (!string.IsNullOrEmpty(savedPath) && Directory.Exists(savedPath))
                {
                    fbd.SelectedPath = savedPath;
                }

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.LastPath = fbd.SelectedPath;
                    Properties.Settings.Default.Save();

                    episodePath = fbd.SelectedPath;
                    string folderName = Path.GetFileName(episodePath);
                    episodePrefix = folderName.Length >= 4 ? folderName.Substring(0, 4) : folderName;

                    rederingTextOutput.Text = "START PROCESSING";

                    await Task.Run(() => ProcessDirectories(episodePath));

                    rederingTextOutput.Text = "PROCESSING COMPLETE";
                }
            }
        }

        private void ProcessDirectories(string rootPath)
        {
            // 1. GET .XSTAGE FILES
            var primaryFiles = Directory.GetDirectories(rootPath)
                .Where(d => !Path.GetFileName(d).Equals("ANIMATORS", StringComparison.OrdinalIgnoreCase))
                .SelectMany(d => Directory.GetFiles(d, "*.xstage", SearchOption.TopDirectoryOnly))
                .Where(f => !Path.GetFileName(f).Contains("_render"))
                .Select(f => new
                {
                    Name = Path.GetFileNameWithoutExtension(f),
                    FullPath = f
                })
                .ToList();

            // 2. FIND EXPORT DIR 
            DirectoryInfo di = new DirectoryInfo(rootPath);
            string renderFolder = Path.Combine(di.Parent?.Parent?.FullName ?? "", "05RENDER");

            if (Directory.Exists(renderFolder))
            {
                string prefix = di.Name.Substring(0, Math.Min(4, di.Name.Length));
                var match = new DirectoryInfo(renderFolder)
                    .GetDirectories()
                    .FirstOrDefault(d => d.Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase));

                if (match != null)
                {
                    renderExportPath = match.FullName;
                }
            }

            this.Invoke(new Action(() =>
            {
                SetupDataGridViewColumns();
                //dataGridView.Rows.Clear();

                foreach (var primary in primaryFiles)
                {
                    AddSceneToGrid(primary.FullPath, renderExportPath);
                }
            }));
        }

        private void AddSceneToGrid(string xstagePath, string renderExportPath)
        {
            // Gather the data for the row
            string sceneName = Path.GetFileNameWithoutExtension(xstagePath);
            string exportName = sceneName.Replace("-", "");
            string frames = getFileFrameNumber(xstagePath);

            // Ensure we update the UI on the correct thread
            this.Invoke(new Action(() =>
            {
                if (dataGridView.Columns.Count == 0)
                {
                    SetupDataGridViewColumns();
                }

                int rowIndex = dataGridView.Rows.Add();
                var row = dataGridView.Rows[rowIndex];

                row.Cells["Select"].Value = false;
                row.Cells["Name"].Value = sceneName;
                row.Cells["ExportName"].Value = exportName;
                row.Cells["ExportPath"].Value = renderExportPath;
                row.Cells["Frames"].Value = frames;
                row.Cells["Status"].Value = Properties.Resources.STATUS_EMPTY; // Default icon

                row.Tag = xstagePath; // Store path for later use
            }));
        }

        private void SetupDataGridViewColumns()
        {
            //if (dataGridView.Columns.Count > 0) return;
            if (dataGridView.Columns.Contains("Name")) return;

            dataGridView.Columns.Clear();

            // Setup Columns
            dataGridView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Select", HeaderText = "Merge", Width = 30, FlatStyle = FlatStyle.Flat });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Name", Width = 100 });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "ExportName", HeaderText = "Export Name", Width = 200 });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "ExportPath", HeaderText = "Export Path", Width = 400 });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Frames", HeaderText = "Frames", ReadOnly = true, Width = 40 });

            // Buttons & Status
            dataGridView.Columns.Add(new DataGridViewImageColumn { Name = "Render", HeaderText = "Render", Image = Properties.Resources.RENDER_FILE, ImageLayout = DataGridViewImageCellLayout.Zoom, Width = 50 });
            dataGridView.Columns.Add(new DataGridViewImageColumn { Name = "Remove", HeaderText = "Remove", Image = Properties.Resources.STATUS_ERROR, ImageLayout = DataGridViewImageCellLayout.Zoom, Width = 50 });
            dataGridView.Columns.Add(new DataGridViewImageColumn { Name = "Status", HeaderText = "Status", Image = Properties.Resources.STATUS_EMPTY, ImageLayout = DataGridViewImageCellLayout.Zoom, Width = 50 });

            Console.WriteLine("TABLE CONSTRUCTED");
        }

        private void RunHarmonyBatch(string appPath, string sceneFile, int rowIndex)
        {
            using (Process p = new Process())
            {
                p.StartInfo.FileName = appPath;
                p.StartInfo.Arguments = $" -user usabatch -batch \"{sceneFile}\"";
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;

                var watchdog = new System.Timers.Timer(60000);
                watchdog.AutoReset = false;
                watchdog.Elapsed += (s, e) =>
                {
                    if (!p.HasExited)
                    {
                        UpdateLog("!!! RENDER STALLED: Killing process.");
                        p.Kill();
                    }
                };

                DataReceivedEventHandler outputHandler = (s, e) =>
                {
                    if (string.IsNullOrEmpty(e.Data)) return;

                    UpdateLog(e.Data);

                    // Regex for "frame 10" or "Frame: 10"
                    var match = System.Text.RegularExpressions.Regex.Match(e.Data, @"frame\s+(\d+)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        watchdog.Stop();
                        watchdog.Start();

                        if (int.TryParse(match.Groups[1].Value, out int currentFrame))
                        {
                            this.BeginInvoke(new Action(() =>
                            {
                                if (currentFrame >= progressBar.Minimum && currentFrame <= progressBar.Maximum)
                                    progressBar.Value = currentFrame;
                            }));
                        }
                    }
                };

                p.OutputDataReceived += outputHandler;
                p.ErrorDataReceived += outputHandler;

                UpdateLog($"STARTING BATCH: {Path.GetFileName(sceneFile)}");

                watchdog.Start();
                p.Start();

                p.BeginOutputReadLine();
                p.BeginErrorReadLine();

                p.WaitForExit();
                watchdog.Stop();

                this.Invoke(new Action(() =>
                {
                    dataGridView.Rows[rowIndex].Cells["Status"].Value =
                        (p.ExitCode == 0) ? Properties.Resources.STATUS_DONE : Properties.Resources.STATUS_ERROR;
                }));
            }
        }

        private void UpdateLog(string message)
        {
            _logWindow.BeginInvoke(new Action(() => _logWindow.AppendLog(message)));
        }

        #region XML

        public string parseAndSaveXMLfile(string filePath, string movieName, int renderPreset)
        {
            string directory = Path.GetDirectoryName(filePath);
            string fileNameNoExt = Path.GetFileNameWithoutExtension(filePath);
            string newFilePath = Path.Combine(directory, $"{fileNameNoExt}_render.xstage");

            XDocument document = XDocument.Load(filePath);

            var attrs = document.XPathSelectElement("//scenes/scene[@name='Top']//module[@name='Write']/attrs");
            attrs?.Remove();

            var writeNode = document.XPathSelectElement("//scenes/scene[@name='Top']//module[@name='Write']");

            if (writeNode != null)
            {
                XElement newAttrs;
                switch (renderPreset)
                {
                    case 0:
                        newAttrs = GetProresExportAttrs(movieName, "prores422HQ", 0);
                        break;
                    case 1:
                        newAttrs = GetProresExportAttrs(movieName, "prores422LT", 0);
                        break;
                    case 2:
                        newAttrs = GetProresExportAttrs(movieName, "prores4444", 0);
                        break;
                    case 3:
                        newAttrs = GetProresExportAttrs(movieName, "prores4444", 1);
                        break;
                    default:
                        newAttrs = GetProresExportAttrs(movieName, "prores422HQ", 0);
                        break;
                }

                writeNode.Add(newAttrs);

                document.Save(newFilePath);
                return newFilePath;
            }

            return null;
        }

        XElement GetProresExportAttrs(string movieName, string codec, int alpha)
        {
            // Construct the complex string using string interpolation
            string videoAudioVal = $"com.toonboom.prores.mov.1.0:enableSound(1)com.toonboom.prores.mov.1.0:sampleRate(22050)com.toonboom.prores.mov.1.0:nChannels(2)com.toonboom.prores.mov.1.0:videoCodec({codec})com.toonboom.prores.mov.1.0:alpha({alpha})";

            return new XElement("attrs",
                new XElement("exportToMovie", new XAttribute("val", "true")),
                new XElement("drawingName", new XAttribute("val", "frames/final-")),
                new XElement("moviePath", new XAttribute("val", movieName)),
                new XElement("movieFormat", new XAttribute("val", "com.toonboom.prores.mov.1.0")),
                new XElement("movieAudio"),
                new XElement("movieVideo"),
                new XElement("movieVideoaudio", new XAttribute("val", videoAudioVal)),
                new XElement("leadingZeros", new XAttribute("val", "3")),
                new XElement("start", new XAttribute("val", "1")),
                new XElement("drawingType", new XAttribute("val", "TGA")),
                new XElement("enabling",
                    new XElement("filter", new XAttribute("val", "ALWAYS")),
                    new XElement("filterName"),
                    new XElement("filterResX", new XAttribute("val", "720")),
                    new XElement("filterResY", new XAttribute("val", "540"))
                ),
                new XElement("scriptMovie", new XAttribute("val", "false")),
                new XElement("scriptEditor", new XAttribute("val", "")),
                new XElement("colorSpace"),
                new XElement("compositePartitioning", new XAttribute("val", "NoCompositePartitioning")),
                new XElement("zPartitionRange", new XAttribute("val", "1"), new XAttribute("defaultValue", "1")),
                new XElement("cleanUpPartitionFolders", new XAttribute("val", "true"))
            );
        }

        #endregion

        #region DATAGRID
        private void DataGridView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // Show the [+] cursor
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void DataGridView_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string path in paths)
            {

                if (Directory.Exists(path))
                {
                    rederingTextOutput.Text = $"LOADING FOLDER: {Path.GetFileName(path)}";
                    ProcessDirectories(path);
                }

                else if (File.Exists(path))
                {
                    if (Path.GetExtension(path).Equals(".xstage", StringComparison.OrdinalIgnoreCase))
                    {
                        string fallbackExportPath = Path.GetDirectoryName(path);
                        AddSceneToGrid(path, renderExportPath ?? fallbackExportPath);
                    }
                    else
                    {
                        MessageBox.Show($"Skipping: {Path.GetFileName(path)}. Only .xstage files are supported.");
                    }
                }
            }
        }

        private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowIndex >= 0)
            {
                var cell = dataGridView.Rows[e.RowIndex].Cells["Select"];
                cell.Value = !Convert.ToBoolean(cell.Value);
            }
        }

        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.Left && e.RowIndex >= 0)
            {
                var cell = dataGridView.Rows[e.RowIndex].Cells["Select"];
                cell.Value = !Convert.ToBoolean(cell.Value);
                dataGridView.InvalidateCell(cell);
            }
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore header clicks (RowIndex will be -1)
            if (e.RowIndex < 0) return;

            string columnName = dataGridView.Columns[e.ColumnIndex].Name;

            switch (columnName)
            {
                case "Render":
                    DgvCompare_CellClick(sender, e);
                    break;

                case "Remove":
                    dataGridView.Rows.RemoveAt(e.RowIndex);
                    break;

                case "Merge":
                    //HandleMergeAction(e.RowIndex);
                    break;
            }
        }

        #endregion

        #region BUTTONS
        private async void DgvCompare_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (string.IsNullOrWhiteSpace(renderExportPath))
            {
                MessageBox.Show("Please select an Export Path first",
                                "Missing Export Path",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string columnName = dataGridView.Columns[e.ColumnIndex].Name;

            if (columnName == "Render")
            {
                var row = dataGridView.Rows[e.RowIndex];
                string originalPath = row.Tag?.ToString();
                string movieName = row.Cells["ExportName"].Value?.ToString();
                string exportFolder = row.Cells["ExportPath"].Value?.ToString();
                string frameValue = row.Cells["Frames"].Value?.ToString();

                if (string.IsNullOrEmpty(originalPath) || string.IsNullOrEmpty(movieName)) return;

                rederingTextOutput.Text = "INITIALIZING...";
                progressBar.Value = 0;

                if (int.TryParse(frameValue, out int totalFrames) && totalFrames > 0)
                {
                    progressBar.Maximum = totalFrames;
                }
                else
                {
                    progressBar.Maximum = 100;
                }

                string finalMoviePath = Path.Combine(exportFolder, movieName);

                await Task.Run(() =>
                {
                    try
                    {
                        this.Invoke(new Action(() => rederingTextOutput.Text = "STARTING RENDER: "));

                        string renderXstagePath = parseAndSaveXMLfile(originalPath, finalMoviePath, renderProres);

                        if (!string.IsNullOrEmpty(renderXstagePath))
                        {
                            this.Invoke(new Action(() => rederingTextOutput.Text = $"RENDERING: {movieName} "));
                            RunHarmonyBatch(harmonyPath, renderXstagePath, e.RowIndex);
                            // File.Delete(renderXstagePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new Action(() =>
                        {
                            rederingTextOutput.Text = $"ERROR: {ex.Message}";
                            progressBar.Value = 0;
                        }));
                    }
                });

                rederingTextOutput.Text = $"RENDER COMPLETE: {movieName}";
                progressBar.Value = 0;
            }
        }

        private void setExportFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = Properties.Settings.Default.LastExportPath;
                fbd.Description = "Select the Export Folder";

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    renderExportPath = fbd.SelectedPath;
                    Properties.Settings.Default.LastExportPath = renderExportPath;
                    Properties.Settings.Default.Save(); // Persist to disk

                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            row.Cells["ExportPath"].Value = renderExportPath;
                        }
                    }

                    Console.WriteLine($"Global Export Path updated to: {renderExportPath}");
                }
            }
        }

        private void importListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "XML Files (*.xml)|*.xml", Multiselect = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    SetupDataGridViewColumns();

                    foreach (string fileName in ofd.FileNames)
                    {
                        DataSet ds = new DataSet();
                        ds.ReadXml(fileName);
                        if (ds.Tables.Count == 0) continue;

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            int rowIndex = dataGridView.Rows.Add();
                            var row = dataGridView.Rows[rowIndex];

                            row.Cells["Select"].Value = false;
                            row.Cells["Name"].Value = dr["Name"];
                            row.Cells["ExportName"].Value = dr["ExportName"];
                            row.Cells["ExportPath"].Value = dr["ExportPath"];
                            row.Cells["Frames"].Value = dr["Frames"];
                            row.Tag = dr["SourcePath"]; // Restore the FullPath
                            row.Cells["Status"].Value = Properties.Resources.STATUS_EMPTY;
                        }
                    }
                }
            }
        }

        private void renderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(renderExportPath))
            {
                MessageBox.Show("Please select an Export Path first",
                                "Missing Export Path",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "XML Files (*.xml)|*.xml";
                sfd.Title = "Export Render List";
                sfd.FileName = episodePrefix + ".xml";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    DataTable dt = new DataTable("RenderList");

                    dt.Columns.Add("Name");
                    dt.Columns.Add("ExportName");
                    dt.Columns.Add("ExportPath");
                    dt.Columns.Add("Frames");
                    dt.Columns.Add("SourcePath");

                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.IsNewRow) continue;

                        DataRow dr = dt.NewRow();

                        dr["Name"] = row.Cells["Name"].Value?.ToString() ?? "";
                        dr["ExportName"] = row.Cells["ExportName"].Value?.ToString() ?? "";
                        dr["ExportPath"] = row.Cells["ExportPath"].Value?.ToString() ?? "";
                        dr["Frames"] = row.Cells["Frames"].Value?.ToString() ?? "0";

                        dr["SourcePath"] = row.Tag?.ToString() ?? "";

                        dt.Rows.Add(dr);
                    }

                    dt.WriteXml(sfd.FileName, XmlWriteMode.WriteSchema);

                    //MessageBox.Show($"Render list exported: {Path.GetFileName(sfd.FileName)}", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramSettings ps = new ProgramSettings();
            ps.ShowDialog();
        }

        private async void buttRenderAll_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to process all selected files?",
                "Confirm Batch Render",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            if (string.IsNullOrWhiteSpace(renderExportPath))
            {
                MessageBox.Show("Please select an Export Path first",
                                "Missing Export Path",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            buttRenderAll.Enabled = false;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                //bool isChecked = Convert.ToBoolean(row.Cells["Select"].Value);
                //if (row.IsNewRow || row.Tag == null || !isChecked) continue;

                dataGridView.ClearSelection();
                row.Selected = true;
                int rowIndex = row.Index;

                string originalPath = row.Tag.ToString();
                string movieName = row.Cells["ExportName"].Value?.ToString();
                string exportFolder = row.Cells["ExportPath"].Value?.ToString();
                string finalMoviePath = Path.Combine(exportFolder, movieName);

                row.Cells["Status"].Value = Properties.Resources.STATUS_EMPTY;
                if (int.TryParse(row.Cells["Frames"].Value?.ToString(), out int totalFrames))
                    progressBar.Maximum = totalFrames;
                else
                    progressBar.Maximum = 100;

                progressBar.Value = 0;

                await Task.Run(() =>
                {
                    try
                    {
                        this.Invoke(new Action(() => rederingTextOutput.Text = $"PREPARING {movieName}..."));

                        string renderXstagePath = parseAndSaveXMLfile(originalPath, finalMoviePath, renderProres);

                        if (!string.IsNullOrEmpty(renderXstagePath))
                        {
                            this.Invoke(new Action(() => rederingTextOutput.Text = $" RENDERING {movieName}..."));

                            RunHarmonyBatch(harmonyPath, renderXstagePath, rowIndex);
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new Action(() =>
                        {
                            rederingTextOutput.Text = $"ERROR ON ROW {rowIndex + 1}: {ex.Message}";
                            row.Cells["Status"].Value = Properties.Resources.STATUS_ERROR;
                        }));
                    }
                });
            }

            rederingTextOutput.Text = "RENDER COMPLETE!";
            buttRenderAll.Enabled = true;
            progressBar.Value = progressBar.Maximum;
        }

        private void buttDelSelected_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Remove selected files from the list?",
                                 "Confirm Removal",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            for (int i = dataGridView.Rows.Count - 1; i >= 0; i--)
            {
                var row = dataGridView.Rows[i];
                bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);

                if (isSelected)
                {
                    dataGridView.Rows.RemoveAt(i);
                }
            }

            rederingTextOutput.Text = "SELECTED ROWS REMOVED.";
        }

        private void buttAddFile_Click(object sender, EventArgs e)
        {

        }

        private void logWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLog();
        }

        private void videoCodec_SelectedIndexChanged(object sender, EventArgs e)
        {
            renderProres = videoCodec.SelectedIndex;
        }

        #endregion

        public static string getFileFrameNumber(string filePath)
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(filePath);

                XmlNode scene = document.SelectSingleNode("//scenes/scene[@name='Top']");

                if (scene != null && scene.Attributes["nbframes"] != null)
                {
                    return scene.Attributes["nbframes"].Value;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading frames from {filePath}: {ex.Message}");
                return "Error";
            }

            return "0"; // Fallback if node not found
        }

    }
}

