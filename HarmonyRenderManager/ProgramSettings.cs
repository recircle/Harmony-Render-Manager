using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HarmonyRenderManager
{
    public partial class ProgramSettings : Form
    {
        private string harmonyPath;

        public ProgramSettings()
        {
            InitializeComponent();            
        }

        private void ProgramSettings_Load(object sender, EventArgs e)
        {
            harmonyPathTextBox.Text = Properties.Settings.Default.HarmonyPath;

            videoExport.SelectedIndex = 0;

            exportPrefix1.Text = Properties.Settings.Default.ExportPrefix1;
            exportPrefix2.Text = Properties.Settings.Default.ExportPrefix2;
            exportFileName.Value = Properties.Settings.Default.ExportNameDecimal;
        }

        private void HarmonyPathTextBox_TextChanged(object sender, EventArgs e)
        {
            //Properties.Settings.Default["HarmonyPath"] = "Some Value";
            //Properties.Settings.Default.Save();
        }

        private void browseHarmonyButton_Click(object sender, EventArgs e)
        {
            string defaultPath = @"C:\Program Files (x86)\Toon Boom Animation";

            using (OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Select Toon Boom Harmony Executable",
                Filter = "Harmony Executable (Harmony*.exe)|Harmony*.exe|All Executables (*.exe)|*.exe",
                InitialDirectory = System.IO.Directory.Exists(defaultPath) ? defaultPath : @"C:\",
                RestoreDirectory = true
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // 1. Update the local variable and UI
                    harmonyPath = ofd.FileName;
                    harmonyPathTextBox.Text = harmonyPath;

                    // 2. Save to Settings so it remembers next time
                    // (Make sure 'HarmonyPath' is created in Project Properties > Settings)
                    Properties.Settings.Default.HarmonyPath = harmonyPath;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void ComputerSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void ProgramSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Properties.Settings.Default.Save();

            if (MessageBox.Show("Do you want to save changes?", "Settings", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //e.Cancel = true;
                Properties.Settings.Default.ExportPrefix1 = exportPrefix1.Text;
                Properties.Settings.Default.ExportPrefix2 = exportPrefix2.Text;
                Properties.Settings.Default.ExportNameDecimal = (int)exportFileName.Value;
                Properties.Settings.Default.HarmonyPath = harmonyPath;
                Properties.Settings.Default.Save();
            }

            Console.WriteLine("SETTINGS CLOSING");
        }

        private void ProgramSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("SETTINGS CLOSED");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
