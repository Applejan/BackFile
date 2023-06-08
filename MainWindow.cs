using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace 工作文件备份助手
{
    public partial class MainWindow : Form
    {
        string infoPath = Path.Combine(Directory.GetCurrentDirectory(), "info.xml");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = new FolderBrowserDialog();
            path.ShowDialog();
            textBox1.Text = path.SelectedPath;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            var path = new FolderBrowserDialog();
            path.ShowDialog();
            textBox2.Text = path.SelectedPath;

        }

        private void button6_Click(object sender, EventArgs e)
        {

            string qSource = textBox1.Text;
            var qTarget = textBox2.Text;
            string args = string.Join(" ", @"/mir", qSource, qTarget);

            var psinfo = new ProcessStartInfo("robocopy", args);
            psinfo.UseShellExecute = false;
            if (qSource != string.Empty && qTarget != string.Empty)
            {
                var p = new Process();
                p.StartInfo = psinfo;
                p.Start();
                p.WaitForExit();
                MessageBox.Show("文件镜像复制完成！");
            }
            else
            {
                MessageBox.Show("目录不得为空");
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            var currentPath = Path.GetPathRoot(Directory.GetCurrentDirectory());
            richTextBox1.Text ="SOURCE 为备份的目标目录，DESTINATION 为备份的位置，目录不得为空。";
            richTextBox1.AppendText($"{Environment.NewLine}软件所在驱动器编号为{currentPath}");
            
        }
    }
}
