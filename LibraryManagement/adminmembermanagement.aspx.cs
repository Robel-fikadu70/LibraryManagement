using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //go_btn
        protected void LinkButton0_Click(object sender, EventArgs e)
        {
            getMemberById();
        }

        //delete btn
        protected void button4_Click(object sender, EventArgs e)
        {
            deleteMemberById();

        }

        //active btn
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            // Set the account status to "Active"
            updateAccountStatus("Active");
        }

        //pending btn
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            // Set the account status to "Pending"
            updateAccountStatus("Pending");
        }

        //suspended btn
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            // Set the account status to "Suspended"
            updateAccountStatus("Suspended");
        }


        


        //user defind function 
        

        protected void textbox1_TextChanged(object sender, EventArgs e)
        {
            // Your logic here when the TextBox value changes
        }

        protected void textbox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void textbox7_TextChanged(object sender, EventArgs e)
        {

        }

        protected void textbox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void textbox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void textbox6_TextChanged(object sender, EventArgs e)
        {

        }

        

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }





        void getMemberById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from Member_Table where Member_ID='" + textbox1.Text.Trim() + "'", con);


                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        textbox2.Text = dr.GetValue(0).ToString(); //member full name
                        textbox7.Text = dr.GetValue(4).ToString(); //acc status
                        textbox4.Text = dr.GetValue(1).ToString(); //Address
                        textbox5.Text = dr.GetValue(2).ToString();//contact no
                        textbox6.Text = dr.GetValue(3).ToString();//email

                    }

                }
                else
                {
                    Response.Write("<script>alert('no member with this id');</script>");


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void updateAccountStatus(string newStatus)
        {
            
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    
                    con.Open();
                }
                
                SqlCommand cmd = new SqlCommand("UPDATE Member_Table SET Acc_Status = @status WHERE Member_ID = @member_id", con);

                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@member_id", textbox1.Text.Trim()); // Using the Member ID to update the status
                


                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    // If update is successful, show success message

                    Response.Write("<script>alert('Account status updated successfully!');</script>");
                    getMemberById();  // Re-fetch the member details to reflect the updated status
                    GridView1.DataBind();
                    
                }
                else
                {
                    Response.Write("<script>alert('Failed to update account status.');</script>");
                }
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }

        }
        void deleteMemberById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM Member_Table WHERE Member_ID = '" + textbox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('User Deleted');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch { }
        }

        void clearForm()
        {
            textbox1.Text = "";
            textbox2.Text = "";
            textbox4.Text = "";
            textbox5.Text = "";
            textbox6.Text = "";
            textbox7.Text = "";
        }

    }
}