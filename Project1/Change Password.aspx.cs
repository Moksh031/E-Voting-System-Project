using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class Change_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["username"] != null)
            {
                TextBox1.Text = (Request.Cookies["username"].Value.ToString());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = "";
            SqlConnection con = new SqlConnection("uid=sa;password=123;database=moksh;server=Moksh");
            con.Open();
            SqlCommand cmd = new SqlCommand("select password from voters where username='" + TextBox1.Text + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                name = ds.Tables[0].Rows[0][0].ToString();
            }

            if (TextBox2.Text == name && TextBox3.Text==TextBox4.Text)
            {
                SqlCommand cmd1 = new SqlCommand("Update voters set password='" + TextBox3.Text + "' where username='" + TextBox1.Text + "' ", con);
                int i = cmd1.ExecuteNonQuery();
                Label10.Text = "Updated " + TextBox1.Text + " Sucessfully";
            }
            else if (TextBox2.Text != name)
            {
                Label10.Text = "Previous Password Is Wrong!. Try Again";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Voters Panel.aspx");
        }
    }
}