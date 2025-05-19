using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["email"] == null)
                {
                    Response.Write("<script>alert('session expired login again'); </script>");
                    Response.Redirect("userlogin.aspx");

                }
                else 
                {
                    BookData();
                    if (!Page.IsPostBack)
                    {
                        GetUserData();
                    }
                }
            }
            catch(Exception ex) {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");


            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["fullname"].ToString() == "" || Session["fullname"] == null)
                {
                    Response.Write("<script>alert('session expired login again'); </script>");
                    Response.Redirect("userlogin.aspx");

                }
                else
                {
                   updatedata();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");


            }
        }

        void updatedata()
        {
            string password = "";
            if(TextBox5.Text.Trim() == "")
            {
                password = TextBox9.Text.Trim();
            }
            else
            {
                password = TextBox5.Text.Trim();
            }

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("UPDATE Member_Table SET Full_Name = @full_name, Address = @Address, " +
                    "Phone_No = @contact_no, Email = @email ,PW = @password, Acc_Status = @account_status " +
                    "WHERE Email = '"+Session["email"].ToString()+"' ", con);



                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());

                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "Pending");

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                { 
                    Response.Write("<script>alert('DETAIL UPDATED SUCCESSFULLY ');</script>");
                    GetUserData();
                }
                else
                {
                    Response.Write("<script>alert('DETAIL FAILED TO UPDATED ');</script>");
                }

            }
            catch (Exception ex) {
                Response.Write("<script>alert('"+ex.Message+" ');</script>");

            }

        }
        void GetUserData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Member_Table where Email='" + Session["email"].ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox1.Text = dt.Rows[0]["Full_Name"].ToString();
                TextBox2.Text = dt.Rows[0]["Full_Address"].ToString();
                TextBox3.Text = dt.Rows[0]["Phone_No"].ToString().Trim(); 
                TextBox4.Text = dt.Rows[0]["Email"].ToString();
                TextBox8.Text = dt.Rows[0]["Member_ID"].ToString();
                TextBox9.Text = dt.Rows[0]["PW"].ToString();
                Label1.Text = dt.Rows[0]["Acc_Status"].ToString().Trim();

                if (dt.Rows[0]["Acc_Status"].ToString().Trim() == "Active")
                {
                    //Label1.Attributes.Add("class", "badge badge-pill badge-success");
                    Label1.Attributes["class"] = "badge rounded-pill text-bg-success"; // Change to green

                }
                else if (dt.Rows[0]["Acc_Status"].ToString().Trim() == "Pending")
                {
                    //Label1.Attributes["class"] = "badge badge-pill badge-warning";
                    Label1.Attributes["class"] = "badge rounded-pill text-bg-warning"; // Change to yellow
                }
                else if (dt.Rows[0]["Acc_Status"].ToString().Trim() == "Suspended")
                {
                    Label1.Attributes["class"] = "badge rounded-pill text-bg-danger"; // Change to red
                }
                else
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-info");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }
        
        void BookData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Member_Table where Email='"
                + Session["email"].ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string Member_ID = null;


                if (dt.Rows.Count >= 1)
                {
                      Member_ID = dt.Rows[0]["Member_ID"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('NIGGGGGGGAAAAAAAAAA')</script>");
                }

                if (!string.IsNullOrEmpty(Member_ID)){
                    cmd = new SqlCommand("SELECT * FROM Book_Issue where Member_ID='"+ Member_ID + "'", con);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else {
                    Response.Write("<script>alert('NULL MEMBER ID')</script>");

                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }
    }
}