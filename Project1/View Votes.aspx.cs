using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Trusted_Connection = Yes;database = moksh; server =MOKSH"))
            {
                GridView1.Visible = true;
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select * from electionsname ", sqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                Label2.Text = "Elections Data";

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Trusted_Connection = Yes;database = moksh; server =MOKSH"))
            {
                GridView1.Visible = true;
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select * from voters ", sqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                Label2.Text = "Voters Data";

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Trusted_Connection = Yes;database = moksh; server =MOKSH"))
            {
                GridView1.Visible = true;
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select * from candidate ", sqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                Label2.Text = "Candidate Data";


            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Label2.Text = "";
            GridView1.Visible = false;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Trusted_Connection = Yes;database = moksh; server =MOKSH"))
            {
                GridView1.Visible = true;
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select Name from candidate where votes_count=(select max(votes_count) from candidate); ", sqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //textBox1.Text = ds.Tables[0].Rows[0][0].ToString();
                    Label2.Text = "Winner is" + ds.Tables[0].Rows[0][0].ToString() + "";
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();



                }
            }
        }
    }
}