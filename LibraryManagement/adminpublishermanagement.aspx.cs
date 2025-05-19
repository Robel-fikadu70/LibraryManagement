using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace LibraryManagement
{
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfpublisherexist())
            {
                Response.Write("<script>alert('the publisher you add is already existed '); </script>");
            }
            else
            {
                addnewpublisher();
                GridView1.DataBind();
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfpublisherexist())
            {
                updatepublisher();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('the publisher you try to update is not existed '); </script>");
            }
        }
        //delete button
        protected void Button4_Click(object sender, EventArgs e)
        {

            if (checkIfpublisherexist())
            {
                deletepublisher();
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('the publisher you try to delete is not existed '); </script>");
            }

        }
        //go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            gopublisher();
        }
        
        
        
        
        bool checkIfpublisherexist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Publisher where Publisher_ID='"
                + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                }
                return false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
                return false;
            }
        }
        
        void gopublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Publisher WHERE Publisher_ID='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Ivalid id'); </script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");

            }

        }
        void addnewpublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Publisher (Publisher_ID,Publisher_Name) values (@publisher_id,@publisher_name)", con);



                cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script>alert('publisher added succesfully ');</script>");
                clearform();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updatepublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE Publisher SET Publisher_Name = @publisher_name WHERE Publisher_ID = @publisher_id", con);
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());


                cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script>alert('publisher updated succesfully ');</script>");
                clearform();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void deletepublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE From Publisher WHERE Publisher_Name=@publisher_name AND Publisher_ID='" + TextBox1.Text.Trim() + "'", con);



                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script>alert('publisher deleted succesfully ');</script>");
                clearform();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        

        void clearform()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";


        }



        protected void Unnamed1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

    }
}