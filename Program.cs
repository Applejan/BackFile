using System;
using System.IO;
using System.Windows.Forms;

namespace 工作文件备份助手
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
            
        }
    }
    public class DiskPath
    {
        public string DiskName { set; get; }
        public string Path { set; get; }
    }
    public class SavePaths
    {
        public DiskPath HomeDisk { get; set; }
        public DiskPath CompanyDisk { set; get; }
        public DiskPath RemoveableDisk { set; get; }
    }
}
