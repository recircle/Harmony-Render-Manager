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
    public partial class LogWindow : Form
    {
        public LogWindow()
        {
            InitializeComponent();
            this.Text = "Harmony Batch Output";
        }

        // Thread-safe method to append text
        public void AppendLog(string message)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() => AppendLog(message)));
                return;
            }
            txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();

        }

        private void LogWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
