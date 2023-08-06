using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;

namespace Project1
{
    public partial class Voters_Panel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                    if (Request.Cookies["username"] != null)
                    {
                        TextBox1.Text="Welcome Back "+(Request.Cookies["username"].Value.ToString());
                    }
            using (SqlConnection sqlCon = new SqlConnection("Trusted_Connection = Yes;database = moksh; server =MOKSH"))
            {
                if (!IsPostBack)
            {
                

                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("Select * from electionsname ", sqlCon);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    adapter.Fill(ds);


                    DropDownList1.DataTextField = ds.Tables[0].Columns["name"].ToString();
                    DropDownList1.DataValueField = ds.Tables[0].Columns["name"].ToString();
                    DropDownList1.DataSource = ds.Tables[0];
                    DropDownList1.DataBind();
                }

            }
            }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("uid=sa;password=123;database=moksh;server=Moksh");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from voters where username='" + TextBox1.Text + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //textBox1.Text = ds.Tables[0].Rows[0][0].ToString();
                TextBox2.Text = ds.Tables[0].Rows[0][2].ToString();
                DropDownList1.SelectedValue = ds.Tables[0].Rows[0][3].ToString();
                TextBox4.Text = ds.Tables[0].Rows[0][4].ToString();
                
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("uid=sa;password=123;database=moksh;server=Moksh");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update voters set fullname='" + TextBox2.Text + "',Addrees='" + DropDownList1.SelectedValue + "' where username='"+TextBox1.Text+"' ", con);
            int i = cmd.ExecuteNonQuery();
            Label6.Text = "Updated " + TextBox1.Text + " Sucessfully";

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Change Password.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home Page.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Voters In Elections.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }
    }
}