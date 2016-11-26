using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using lsp = DesignPatternsLibrary.LSP;

namespace WebApp.LSP
{
    public partial class LSP : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            lsp.CurrentAccount ca = new lsp.CurrentAccount();
            ca.WithdrawAmount = 10001;

            lsp.SavingsAccount sa = new lsp.SavingsAccount();

            Append("Current account min balance = "  + ca.Withdraw());
            Append("Savings account min balance = " + sa.Withdraw());

            lsp.SavingsAccount mca = new lsp.CurrentAccount();
            mca.WithdrawAmount = 1;
            
            //newsa.ZeroBalance = 1;
            //Append("Mod Savings account min balance = " + newsa.Withdraw());




            ShowMessage(sb);
        }

        private void ShowMessage(StringBuilder sb)
        {
            lblDisplay.Text = sb.ToString();
        }

        private void Append(string msg = "")
        {
            sb.AppendLine(msg + " <br/>");
        }
    }
}