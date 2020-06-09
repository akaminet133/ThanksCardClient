using System.Windows;
using System.Windows.Forms;

namespace ThanksCardClient.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Forms.MessageBox.Show("ログイン画面を表示します。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
