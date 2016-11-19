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
        
        class A
        {
            public virtual string show()
            {
                return "Hello: Base Class!";
            }
        }

        class B : A
        {
            public override string show()
            {
                return "Hello: Derived Class!";
            }
        }

        class C : B
        {
            public new string show()
            {
                return "Am Here!";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            A a1 = new A();
            Append(a1.show());
            
            B b1 = new B();
            Append(b1.show());

            C c1 = new C();
            Append(c1.show());

            A a2 = new B();
            Append(a2.show());

            A a3 = new C();
            Append(a3.show());

            B b3 = new C();
            Append(b3.show());



            EmployeeBase baseEmployee = new PermanentEmployee();
            EmployeeBase baseCEmployee = new ContractEmployee();
            ContractEmployee contractEmployee = new ContractEmployee();
            PermanentEmployee permanentEmployee = new PermanentEmployee();

            Append("EmployeeBase as permanentEmployee.GetSalary() : " + baseEmployee.GetSalary());
            Append("EmployeeBase as contractEmployee.GetSalary() : " + baseCEmployee.GetSalary());
            Append("permanentEmployee.GetSalary() : " + permanentEmployee.GetSalary());
            Append("contractEmployee.GetSalary() : " + contractEmployee.GetSalary());
            Append();
            Append("overridden message in contractEmployee : " + contractEmployee.Message());
            Append("baseCEmployee's new Message via EmployeeBase :" + baseCEmployee.Message());
            Append();
            Append("base message in contractEmployee : " + contractEmployee.BaseMessage());
            Append();
            Append("baseCEmployee's OverrideTest  :" + baseCEmployee.OverrideTest());
            Append("contractEmployee's OverrideTest :" + contractEmployee.OverrideTest());
            Append();
            Append("//The override modifier can be added before or after public.");
            Append("//The virtual modifier can be added before or after public.");
            Append("//: no suitable method found to override - When we write override in abstract class");
            Append("//Warning - hides inherited member 'OverrideTest()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.");

            ContractEmployee b = new DummyEmployee();
            Append(b.GetSalary().ToString());
            Append(b.Message());
            Append(b.OverrideTest());

            /*
             * Both base and derived contain method with 'new': 
             *      If we create base obj = new derived(). 
             *      This will call base.new method
            */

            ShowMessage(sb);
        }

        private void ShowMessage(StringBuilder sb)
        {
            label1.Text = sb.ToString();
        }

        private void Append(string msg="")
        {
           sb.AppendLine(msg + " <br/>");
        }
    }
}