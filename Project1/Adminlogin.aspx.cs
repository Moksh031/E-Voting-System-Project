using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }
        public string MyName
        {

            get { return TextBox1.Text; }
        }

    

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Trusted_Connection = Yes;database = moksh; server =MOKSH"))
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM loginadmin WHERE username='" + TextBox1.Text + "' AND password='" + TextBox2.Text + "' ", sqlCon);


                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    HttpCookie Cookies = new HttpCookie("username");
                    Cookies.Value = TextBox1.Text;
                    Cookies.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(Cookies);
                    Label4.Text = "Login Sucessfull";
                    Response.Redirect("Adminpanel.aspx");

                }
                else
                {
                    Label4.Text = "Incorrect Details";
                }
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}