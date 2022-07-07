using System.Text.RegularExpressions;

namespace NVM_Switcher
{
    public partial class SwitcherLog : Form
    {
        private string[] versions;
        private ContextMenuStrip cms;

        public SwitcherLog()
        {
            InitializeComponent();
        }

        private void SwitcherLogLoad(object sender, EventArgs e)
        {
            createNotifyIcon();
            setupNVMList();
        }

        private void setupNVMList()
        {
            System.Diagnostics.ProcessStartInfo proc = new System.Diagnostics.ProcessStartInfo();
            proc.FileName = "cmd.exe";
            proc.Arguments = "/c nvm list";
            proc.CreateNoWindow = true;
            proc.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            proc.RedirectStandardOutput = true;
            var process = System.Diagnostics.Process.Start(proc);
            string q = process.StandardOutput.ReadToEnd();
            Regex rx = new Regex(@"\d{1,2}\.\d{1,2}\.\d{1,3}");
            MatchCollection matches = rx.Matches(q);
            versions = matches.Cast<Match>().Select(m => m.Value).ToArray();
            foreach (string version in versions)
            {
                var tsi = cms.Items.Add(version);
                tsi.Click += OnVersionClicked(version);
            }
        }

        private EventHandler OnVersionClicked(string version)
        {
            return (object sender, EventArgs e) =>
            {
                switchVersion(version);
            };
        }

        private void switchVersion(string version)
        {
            System.Diagnostics.ProcessStartInfo proc = new System.Diagnostics.ProcessStartInfo();
            proc.FileName = "cmd.exe";
            proc.Arguments = $"/c nvm use {version}";
            proc.CreateNoWindow = true;
            proc.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            proc.RedirectStandardOutput = true;
            var process = System.Diagnostics.Process.Start(proc);
            string q = process.StandardOutput.ReadToEnd();
            logEntries.AppendText(
                DateTime.Now.ToString(System.Globalization.CultureInfo.InvariantCulture) + " - "
            );
            logEntries.AppendText(q);
            logEntries.AppendText(Environment.NewLine);
        }

        private void createNotifyIcon()
        {
            cms = new System.Windows.Forms.ContextMenuStrip();
            notificationIcon.ContextMenuStrip = cms;
        }

        private void notificationIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
        }

        private void SwitcherLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void SwitcherLog_Shown(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
