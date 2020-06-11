using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ThanksCardClient.Views
{
    /// <summary>
    /// PdfView.xaml の相互作用ロジック
    /// </summary>
    public partial class PdfView : Window
    {
        public PdfView()
        {
            InitializeComponent();
            string dirpath = Directory.GetCurrentDirectory();
            dirpath += @"\Image\manual.pdf";
            System.Windows.Forms.MessageBox.Show("PDF画面を表示します。", "表示", MessageBoxButtons.OK);
            System.Diagnostics.Process.Start(dirpath);
        }
    }
}
