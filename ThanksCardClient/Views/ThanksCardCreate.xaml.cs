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
        private void btnAddKiwii_Click(object sender, EventArgs e)
        {
            // ★★★現在のTextBoxの末尾にテキストを追記する★★★
            Textbox1.AppendText("🥝\n");
        }
        private void btnAddBanana_Click(object sender, EventArgs e)
        {
            // ★★★現在のTextBoxの末尾にテキストを追記する★★★
            Textbox1.AppendText("🍌\n");
        }
        private void btnAddCherry_Click(object sender, EventArgs e)
        {
            // ★★★現在のTextBoxの末尾にテキストを追記する★★★
            Textbox1.AppendText("🍒\n");
        }
        private void btnAddArigatou_Click(object sender, EventArgs e)
        {
            // ★★★現在のTextBoxの末尾にテキストを追記する★★★
            Textbox1.AppendText("ありがとう！\n");
        }
        private void btnAddKansha_Click(object sender, EventArgs e)
        {
            // ★★★現在のTextBoxの末尾にテキストを追記する★★★
            Textbox1.AppendText("感謝です\n");
        }
        private void btnAddThanks_Click(object sender, EventArgs e)
        {
            // ★★★現在のTextBoxの末尾にテキストを追記する★★★
            Textbox1.AppendText("Thank you!\n");
        }

    }
}
