using System;
using System.Windows.Controls;
using ThanksCardClient.Models;

namespace ThanksCardClient.Views
{
    /// <summary>
    /// Interaction logic for ThanksCardCreate
    /// </summary>
    public partial class ThanksCardCreate : UserControl
    {
        public ThanksCardCreate()
        {
            InitializeComponent();
        }

        // [テキストを追記する]ボタンクリック時の処理
        private void btnAddSmile_Click(object sender, EventArgs e)
        {
            // ★★★現在のTextBoxの末尾にテキストを追記する★★★
            ThanksCardBody.AppendText("😊");
        }
        private void btnAddOjigi_Click(object sender, EventArgs e)
        {
            // ★★★現在のTextBoxの末尾にテキストを追記する★★★
            ThanksCardBody.AppendText("m(__)m");
        }
        private void btnAddGood_Click(object sender, EventArgs e)
        {
            // ★★★現在のTextBoxの末尾にテキストを追記する★★★
            ThanksCardBody.AppendText("👍");
        }
        private void btnAddArigatou_Click(object sender, EventArgs e)
        {
            // ★★★現在のTextBoxの末尾にテキストを追記する★★★
            ThanksCardBody.AppendText("ありがとう！");
        }
        private void btnAddKansha_Click(object sender, EventArgs e)
        {
            // ★★★現在のTextBoxの末尾にテキストを追記する★★★
            ThanksCardBody.AppendText("感謝です。");
        }
        private void btnAddThanks_Click(object sender, EventArgs e)
        {
            // ★★★現在のTextBoxの末尾にテキストを追記する★★★
            ThanksCardBody.AppendText("Thank you!");
        }

    }
}
