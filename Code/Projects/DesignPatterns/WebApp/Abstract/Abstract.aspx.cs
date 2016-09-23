using DesignPatternsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Abstract : System.Web.UI.Page
    {
        StringBuilder sb = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeeBase baseEmployee = new PermanentEmployee();
            EmployeeBase baseCEmployee = new ContractEmployee();
            ContractEmployee contractEmployee = new ContractEmployee();
            PermanentEmployee permanentEmployee = new PermanentEmployee();

            Append("EmployeeBase as permanentEmployee.GetSalary() : " + baseEmployee.GetSalary());
            Append("EmployeeBase as contractEmployee.GetSalary() : " + baseCEmployee.GetSalary());
            Append("permanentEmployee.GetSalary() : " + permanentEmployee.GetSalary());
            Append("contractEmployee.GetSalary() : " + contractEmployee.GetSalary());

            Append("overridden message in contractEmployee : " + contractEmployee.Message());
            Append("base message in contractEmployee : " + contractEmployee.BaseMessage());

            Append("//The override modifier can be added before or after public.");
            Append("//The virtual modifier can be added before or after public.");


            ShowMessage(sb);
        }

        private void ShowMessage(StringBuilder sb)
        {
            label1.Text = sb.ToString();
        }

        private void Append(string msg)
        {
           sb.AppendLine(msg + " <br/>");
        }
    }
}