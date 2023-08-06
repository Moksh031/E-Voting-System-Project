using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Security.Cryptography;

namespace Project1
{
    public partial class Voters_In_Elections : System.Web.UI.Page
    {
        static string name = "";
        static string electionsnames = "", add = "";
        static string vote_decide = "Voted";
        static int count, c;
        static int x = 0;
        static string Winner = "", Winner1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["username"] != null)
            {
                TextBox1.Text = (Request.Cookies["username"].Value.ToString());
            }
            SqlConnection con = new SqlConnection("uid=sa;password=123;database=moksh;server=Moksh");
            con.Open();
            GridView1.Visible = true;

            SqlCommand cmd = new SqlCommand("select vote from voters where username='" + TextBox1.Text + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                name = ds.Tables[0].Rows[0][0].ToString();
            }

            SqlCommand cmd2 = new SqlCommand("select Addrees from voters where username ='" + TextBox1.Text + "' ", con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                add = ds2.Tables[0].Rows[0][0].ToString();
            }

            if (!IsPostBack)
            {
                SqlCommand cmd1 = new SqlCommand("Select Name from candidate where electionsname='" + add + "' ", con);
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();

                adapter1.Fill(ds1);
                DropDownList1.DataTextField = ds1.Tables[0].Columns["Name"].ToString();
                DropDownList1.DataValueField = ds1.Tables[0].Columns["Name"].ToString();
                DropDownList1.DataSource = ds1.Tables[0];
                DropDownList1.DataBind();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (name == "Not Voted")
            {
                Label3.Text = "Not Voted";
            }
            else
            {
                Label3.Text = "Voted";
            }
            GridView1.Visible=false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("uid=sa;password=123;database=moksh;server=Moksh");
            con.Open();
            GridView1.Visible = true;
            SqlCommand cmd = new SqlCommand("select * from electionsname  ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            Label3.Text = "";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            DateTime start = new DateTime(2023, 8, 6, 22, 08, 0); //10 o'clock
                                                                  //12 o'clock
            DateTime now = DateTime.Now;
            if (start <= now)
            {
                GridView1.Visible = true;
                SqlConnection con = new SqlConnection("uid=sa;password=123;database=moksh;server=Moksh");
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select Name from candidate where votes_count=(select max(votes_count) from candidate) ", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                try
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        Winner = ds1.Tables[0].Rows[0][0].ToString();
                        Winner1 = ds1.Tables[0].Rows[1][0].ToString();
                        GridView1.DataSource = ds1.Tables[0];
                        GridView1.DataBind();
                        Label3.Text = "Winner Of The Election in " + add + " is " + Winner + " " + Winner1 + "";

                    }
                }
                catch
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        Winner = ds1.Tables[0].Rows[0][0].ToString();

                        GridView1.DataSource = ds1.Tables[0];
                        GridView1.DataBind();
                        Label3.Text = "Winner Of The Election in " + add + " is " + Winner + " ";
                    }

                }



               

            }
            else
            {
                Label3.Text = "Winner will be announce at 10:08";
                GridView1.Visible = false;
            } }

        protected void Button3_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection("uid=sa;password=123;database=moksh;server=Moksh");
            con.Open();
            GridView1.Visible = true;
            SqlCommand cmd = new SqlCommand("select addrees from voters where username ='"+TextBox1.Text +"' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                electionsnames= ds.Tables[0].Rows[0][0].ToString();
            }

            SqlCommand cmd1 = new SqlCommand("select * from candidate where electionsname='"+electionsnames+"' ", con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            GridView1.DataSource = ds1.Tables[0];
            GridView1.DataBind();
            electionsnames = "";
            Label3.Text = "";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("uid=sa;password=123;database=moksh;server=Moksh");
                        con.Open();
            GridView1.Visible = false;
            SqlCommand cmd = new SqlCommand("select votes_count from candidate where Name ='" +DropDownList1.SelectedValue + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                 c= (int)ds.Tables[0].Rows[0][0];
            }
            if (x == 0 && name=="Not Voted")
            {
                count = c + 1;
            

                SqlCommand cmd1 = new SqlCommand("update candidate set votes_count=" + count + " where Name='" + DropDownList1.SelectedValue + "' ", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);

                Label3.Text = "" + DropDownList1.SelectedValue + " Voted Sucessdfulyy";
                x++;
                SqlCommand cmd2 = new SqlCommand("update voters set vote='"+ vote_decide + "' where username='" + TextBox1.Text+ "' ", con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);

                        }
            else
            {
                Label3.Text = "Already Voted";
            }
        }
    }
    
}