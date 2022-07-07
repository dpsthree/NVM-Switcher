using System.Text.RegularExpressions;

namespace NVM_Switcher
{
    public partial class Form1 : Form
    {
        private string[] versions;
        private ContextMenuStrip cms;

        public Form1()
        {
            InitializeComponent();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) { }

        private void Form1_Load(object sender, EventArgs e)
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
            textBox1.Text = q;
        }

        private void createNotifyIcon()
        {
            cms = new System.Windows.Forms.ContextMenuStrip();
            notifyIcon1.ContextMenuStrip = cms;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "Welcome to TutorialsPanel.com!!";
            notifyIcon1.BalloonTipTitle = "Welcome Message";
            notifyIcon1.ShowBalloonTip(2000);
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}
