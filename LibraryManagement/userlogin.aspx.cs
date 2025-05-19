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
    public partial class userlogin : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Member_Table where Email='" + TextBox1.Text.Trim() + "' AND PW='" + TextBox2.Text.Trim() + "'", con);


                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Panel2.Visible = true;
                        Panel1.Visible = false;

                        Session["email"] = dr.GetValue(3).ToString();
                        Session["fullname"] = dr.GetValue(0).ToString();
                        Session["role"] = "user";
                        Session["status"] = dr.GetValue(4).ToString();
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                "setTimeout(function() { window.location.href = 'homepage.aspx'; }, 2000);", true);
                }
                else
                {
                    Panel1.Visible = true;
                    Panel2.Visible = false;


                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        //user defined function
    }
}