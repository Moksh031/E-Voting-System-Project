using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using System.Configuration;
using System.Data.Common;
using System.Net.NetworkInformation;
using System.Web.Services.Description;
using System.Linq.Expressions;

namespace Project1
{
    public partial class Manage_Candidate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection sqlCon = new SqlConnection("Trusted_Connection = Yes;database = moksh; server =MOKSH"))
                {
                    Image1.Visible = false;
                    GridView1.Visible = false; 
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("Select * from electionsname ", sqlCon);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    
                    
                    adapter.Fill(ds);

                    

                    cmd.CommandType = CommandType.StoredProcedure;

                    DropDownList2.DataTextField = ds.Tables[0].Columns["name"].ToString();
                    DropDownList2.DataValueField = ds.Tables[0].Columns["name"].ToString();
                    DropDownList2.DataSource = ds.Tables[0];
                    DropDownList2.DataBind();

                    SqlCommand cmd1 = new SqlCommand("Select Name from candidate ", sqlCon);
                    SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                    DataSet ds1 = new DataSet();

                    adapter1.Fill(ds1);

                   
                            

                    

                    DropDownList1.DataTextField = ds1.Tables[0].Columns["Name"].ToString();
                    DropDownList1.DataValueField = ds1.Tables[0].Columns["Name"].ToString();
                    DropDownList1.DataSource = ds1.Tables[0];
                    DropDownList1.DataBind();

                }
            }
        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                string filename = Path.GetFileName(FileUpload2.PostedFile.FileName);
                string contentType = FileUpload2.PostedFile.ContentType;
                using (Stream fs = FileUpload2.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        SqlConnection con = new SqlConnection("uid=sa;password=123;database=moksh;server=Moksh");
                        con.Open();

                        SqlCommand cmd = new SqlCommand("sp_insert", con);
                        /*MessageBox.Show(cmd.CommandText);
                                */

                        cmd.CommandType = CommandType.StoredProcedure;

                        
                        cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@Party_Name", TextBox2.Text);
                        cmd.Parameters.AddWithValue("@Party_Sign", TextBox3.Text);
                        cmd.Parameters.AddWithValue("@electionsname", DropDownList2.SelectedValue);
                        cmd.Parameters.AddWithValue("@pic", bytes);
                        cmd.Parameters.AddWithValue("@votes_count", TextBox4.Text);

                        Label6.Text = ""+TextBox1.Text+"Inserted Sucessfully";


                        int i = cmd.ExecuteNonQuery();
                        DropDownList1.Items.Add(TextBox1.Text);

                    }

                }
            }
            catch {
                Label6.Text = "Candidate Exist Already";
            }


                
            } 

        protected void Button4_Click(object sender, EventArgs e)
        {
            Image1.Visible = true;
            string filename = Path.GetFileName(FileUpload2.PostedFile.FileName);
            string contentType = FileUpload2.PostedFile.ContentType;
            SqlConnection con = new SqlConnection("uid=sa;password=123;database=moksh;server=Moksh");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from candidate where Name='" + TextBox1.Text+"' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //textBox1.Text = ds.Tables[0].Rows[0][0].ToString();
                TextBox2.Text = ds.Tables[0].Rows[0][1].ToString();
                TextBox3.Text = ds.Tables[0].Rows[0][2].ToString();
                DropDownList2.Text = ds.Tables[0].Rows[0][3].ToString();
                byte[] data = (byte[])ds.Tables[0].Rows[0][4];
                TextBox3.Text = ds.Tables[0].Rows[0][5].ToString();

                MemoryStream ms = new MemoryStream(data);
                string base64String = Convert.ToBase64String(data, 0, data.Length);
                Image1.ImageUrl = "data:image/png;base64," + base64String;
               


            }
           

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            try
            {
                string filename = Path.GetFileName(FileUpload2.PostedFile.FileName);
                string contentType = FileUpload2.PostedFile.ContentType;
                using (Stream fs = FileUpload2.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        SqlConnection con = new SqlConnection("uid=sa;password=123;database=moksh;server=Moksh");
                        con.Open();

                        SqlCommand cmd = new SqlCommand("sp_update", con);
                        /*MessageBox.Show(cmd.CommandText);
                                */

                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@Party_Name", TextBox2.Text);
                        cmd.Parameters.AddWithValue("@Party_Sign", TextBox3.Text);
                        cmd.Parameters.AddWithValue("@electionsname", DropDownList2.SelectedValue);
                        cmd.Parameters.AddWithValue("@pic", bytes);
                        cmd.Parameters.AddWithValue("@votes_count", TextBox4.Text);
                        int i = cmd.ExecuteNonQuery();
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        Image1.ImageUrl = "data:image/png;base64," + base64String;

                        Label6.Text = "" + TextBox1.Text + "Updated Sucessfully";


                       

                    }

                }
            }
            catch
            {
                Label6.Text = "Candidate Exist Already";
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("uid=sa;password=123;database=moksh;server=Moksh");
            con.Open();
            if (TextBox1.Text != "")
            {
                Label3.Visible = true;
                SqlCommand cmd = new SqlCommand("Delete From candidate where Name = '" + TextBox1.Text + "' ", con);
                Label6.Text = "Deleted " + TextBox1.Text + " sucessfully";
                int i = cmd.ExecuteNonQuery();
                Image1.Visible = false;

                SqlCommand cmd1 = new SqlCommand("Select Name from candidate ", con);
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();

                adapter1.Fill(ds1);



                DropDownList1.DataTextField = ds1.Tables[0].Columns["Name"].ToString();
                DropDownList1.DataValueField = ds1.Tables[0].Columns["Name"].ToString();
                DropDownList1.DataSource = ds1.Tables[0];
                DropDownList1.DataBind();
                con.Close();
            }
            else
            {
                Label6.Text = "Enter Name to Delete";
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Label6.Text = "";
            Image1.Visible = false;
            GridView1.Visible = false;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            SqlConnection con = new SqlConnection("uid=sa;password=123;database=moksh;server=Moksh");
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from candidate ", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            adapter.Fill(ds1);
            GridView1.DataSource = ds1.Tables[0];
            GridView1.DataBind();

           




        }

        protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {

        }

        protected void FormView1_PageIndexChanging1(object sender, FormViewPageEventArgs e)
        {

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adminpanel.aspx");
        }
    }
        }
    
                    
              
            






