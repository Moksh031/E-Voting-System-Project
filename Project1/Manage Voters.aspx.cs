using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            TextBox2.TextMode = TextBoxMode.Password;
            using (SqlConnection sqlCon = new SqlConnection("Trusted_Connection = Yes;database = moksh; server =MOKSH"))
            {
                if (!IsPostBack)
                {

                    GridView1.Visible = false;

                    TextBox5.Text = "Not Voted";
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
        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Trusted_Connection = Yes;database = moksh; server =MOKSH"))
            {


                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM voters WHERE username='" + TextBox1.Text + "' ", sqlCon);


                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["username"] = TextBox1.Text.Trim();
                    Label7.Text = "User Already Exists";


                }
                else if (TextBox1.Text==""|| TextBox2.Text == "" || TextBox3.Text == "")
                {
                    Label7.Text = "Please Fill All Details";
                }
                else { 

                    SqlCommand cmd1 = new SqlCommand("sp_insertvoters", sqlCon);

                    TextBox5.Text = "Not Voted";

                    cmd1.CommandType = CommandType.StoredProcedure;


                    cmd1.Parameters.AddWithValue("@username", TextBox1.Text);
                    cmd1.Parameters.AddWithValue("@password", TextBox2.Text);
                    cmd1.Parameters.AddWithValue("@fullname", TextBox3.Text);
                    cmd1.Parameters.AddWithValue("@Address", DropDownList1.SelectedValue);
                    cmd1.Parameters.AddWithValue("@vote", TextBox5.Text);
                    int i = cmd1.ExecuteNonQuery();
                    Label7.Text = "" + TextBox1.Text + " Inserted Sucessfully";
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            TextBox2.TextMode = TextBoxMode.SingleLine;
            SqlConnection con = new SqlConnection("uid=sa;password=123;database=moksh;server=Moksh");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from voters where username='" + TextBox1.Text + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                TextBox2.Text = ds.Tables[0].Rows[0][1].ToString();
                TextBox3.Text = ds.Tables[0].Rows[0][2].ToString();
              
                DropDownList1.SelectedValue = ds.Tables[0].Rows[0][3].ToString();
                TextBox5.Text = ds.Tables[0].Rows[0][4].ToString();
               
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("uid=sa;password=123;database=moksh;server=Moksh");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM voters WHERE username='" + TextBox1.Text + "' ", con);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "")
            {
                Label7.Text = "Please Fill All Details";
            }
            else if (count == 1)
            {




                TextBox5.Text = "Not Voted";

                SqlCommand cmd1 = new SqlCommand("Update voters set password='" + TextBox2.Text + "',fullname='" + TextBox3.Text + "',Addrees='" + DropDownList1.SelectedValue + "',vote='" + TextBox5.Text + "' where username='" + TextBox1.Text + "' ", con);
                int i = cmd1.ExecuteNonQuery();
                Label7.Text = "Updated " + TextBox1.Text + " Sucessfully";

                TextBox2.Text = "";
                TextBox3.Text = "";


            }
            else
            {
                Label7.Text = "User Not Exists";
            }


        }

        protected void Button3_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection("uid=sa;password=123;database=moksh;server=Moksh");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM voters WHERE username='" + TextBox1.Text + "' ", con);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 1)
            {
               

                SqlCommand cmd1 = new SqlCommand("Delete from voters where username='" + TextBox1.Text + "' ", con);
                int i = cmd1.ExecuteNonQuery();
                Label7.Text = "Deleted " + TextBox1.Text + " Sucessfully";
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
            }
            else
            { Label7.Text = "Not Exists"; }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

            GridView1.Visible = true;
            SqlConnection con = new SqlConnection("uid=sa;password=123;database=moksh;server=Moksh");
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from voters ", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            adapter.Fill(ds1);
            GridView1.DataSource = ds1.Tables[0];
            GridView1.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {

            Label7.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            GridView1.Visible=false;


        }
    }
    }
