using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Project1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        static string x="" ;
        protected void Page_Load(object sender, EventArgs e)
        { if (!IsPostBack)
            {



                using (SqlConnection sqlCon = new SqlConnection("Trusted_Connection = Yes;database = moksh; server =MOKSH"))
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
                    x = DropDownList1.SelectedItem.ToString();
                    Label3.Text = "";
                    GridView1.Visible = false;
                }
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection("Trusted_Connection = Yes;database = moksh; server =MOKSH"))
                {


                    if (TextBox1.Text != "")
                    {
                        sqlCon.Open();


                        SqlCommand cmd = new SqlCommand("Insert into electionsname values ('" + TextBox1.Text + "' )", sqlCon);

                        Label3.Text = "" + TextBox1.Text + " Inserted Sucessfully";
                        int i = cmd.ExecuteNonQuery();
                        DropDownList1.Items.Add(TextBox1.Text);
                        SqlCommand cmd3 = new SqlCommand("Select * from electionsname ", sqlCon);
                        SqlDataAdapter adapter1 = new SqlDataAdapter(cmd3);
                        DataSet ds1 = new DataSet();
                        adapter1.Fill(ds1);
                        GridView1.DataSource = ds1.Tables[0];
                        GridView1.DataBind();

                    }



                    else
                    {
                        Label3.Text = "Election Name can not be empty";
                    }
                }
            }
            catch
            {
                Label3.Text = "Election Name Already Exists";
            }
                }
            
        

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Trusted_Connection = Yes;database = moksh; server =MOKSH"))
            {
                if (TextBox1.Text == DropDownList1.Text)
                {
                    Label3.Text = "Previous And New Name Are Same";
                }
                else if (TextBox1.Text != "" )
                {
                    sqlCon.Open();
                    x = DropDownList1.SelectedValue;
                    Label3.Visible = true;
                    SqlCommand cmd = new SqlCommand("Update electionsname set name ='" + TextBox1.Text + "' where name = '" + DropDownList1.SelectedItem + "'", sqlCon);
                    Label3.Text = "" + x + " is updated to " + TextBox1.Text + " sucessfully";
                    int i = cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand("Select * from electionsname ", sqlCon);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                    DataSet ds = new DataSet();

                    adapter.Fill(ds);
                    DropDownList1.DataTextField = ds.Tables[0].Columns["name"].ToString();
                    DropDownList1.DataValueField = ds.Tables[0].Columns["name"].ToString();
                    DropDownList1.DataSource = ds.Tables[0];
                    DropDownList1.DataBind();

                    SqlCommand cmd3 = new SqlCommand("Select * from electionsname ", sqlCon);
                    SqlDataAdapter adapter1 = new SqlDataAdapter(cmd3);
                    DataSet ds1 = new DataSet();
                    adapter1.Fill(ds1);
                    GridView1.DataSource = ds1.Tables[0];
                    GridView1.DataBind();
                }
               

                else
                { Label3.Text = "Give new Election Name!It Can not be empty"; }

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Trusted_Connection = Yes;database = moksh; server =MOKSH"))
            {


                if (TextBox1.Text != "")
                {
                    sqlCon.Open();
                    Label3.Visible = true;
                    SqlCommand cmd = new SqlCommand("Delete From electionsname where name = '" + TextBox1.Text + "' ", sqlCon);
                    Label3.Text = "Deleted " + TextBox1.Text + " sucessfully";
                    int i = cmd.ExecuteNonQuery();
                }
                else if(TextBox1.Text ==String.Empty)
                {
                    sqlCon.Open();
                    Label3.Visible = true;
                    SqlCommand cmd = new SqlCommand("Delete From electionsname where name ='" + DropDownList1.SelectedValue +"'", sqlCon);
                    Label3.Text = "Deleted " + DropDownList1.SelectedValue + " sucessfully";
                    int i = cmd.ExecuteNonQuery();
                }
                SqlCommand cmd1 = new SqlCommand("Select * from electionsname ", sqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                DataSet ds = new DataSet();

                adapter.Fill(ds);
                DropDownList1.DataTextField = ds.Tables[0].Columns["name"].ToString();
                DropDownList1.DataValueField = ds.Tables[0].Columns["name"].ToString();
                DropDownList1.DataSource = ds.Tables[0];
                DropDownList1.DataBind();

                SqlCommand cmd3 = new SqlCommand("Select * from electionsname ", sqlCon);
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd3);
                DataSet ds1 = new DataSet();
                adapter1.Fill(ds1);
                GridView1.DataSource = ds1.Tables[0];
                GridView1.DataBind();

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Trusted_Connection = Yes;database = moksh; server =MOKSH"))
            {
                GridView1.Visible=true;
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select * from electionsname ", sqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();


            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            Label3.Text= string.Empty;
            GridView1.Visible = false;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adminpanel.aspx");
        }
    }
}