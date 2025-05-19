using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LibraryManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["role"] == null || Session["role"].ToString().Equals(""))
                {
                    LinkButton1.Visible = true; // user login link button
                    LinkButton2.Visible = true; //signup

                    LinkButton3.Visible = false; //logout
                    LinkButton7.Visible = false; //hello


                    LinkButton6.Visible = true; //admin login
                    LinkButton11.Visible = false; // author
                    LinkButton12.Visible = false; //publisher
                    LinkButton8.Visible = false; //book inventory
                    LinkButton9.Visible = false; //book issuing
                    LinkButton10.Visible = false; //member management
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; //signup

                    LinkButton3.Visible = true; //logout
                    LinkButton5.Visible = true; //user icon
                    LinkButton7.Visible = true; //hello
                    LinkButton7.Text = Session["fullname"].ToString();


                    LinkButton6.Visible = true; //admin login
                    LinkButton11.Visible = false; // author
                    LinkButton12.Visible = false; //publisher
                    LinkButton8.Visible = false; //book inventory
                    LinkButton9.Visible = false; //book issuing
                    LinkButton10.Visible = false; //member management
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; //signup

                    LinkButton3.Visible = true; //logout
                    LinkButton13.Visible = true; //admin icon

                    LinkButton7.Visible = true; //hello
                    LinkButton7.Text = Session["username"].ToString();


                    LinkButton6.Visible = false; //admin login
                    LinkButton11.Visible = true; // author
                    LinkButton12.Visible = true; //publisher
                    LinkButton8.Visible = true; //book inventory
                    LinkButton9.Visible = true; //book issuing
                    LinkButton10.Visible = true; //member management
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }


        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");

        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthorManagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookIssuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton1.Visible = true; // user login link button
            LinkButton2.Visible = true; //signup

            LinkButton3.Visible = false; //logout
            LinkButton7.Visible = false; //hello
            LinkButton5.Visible = false; //userprofile


            LinkButton6.Visible = true; //admin login
            LinkButton11.Visible = false; // author
            LinkButton12.Visible = false; //publisher
            LinkButton8.Visible = false; //book inventory
            LinkButton9.Visible = false; //book issuing
            LinkButton10.Visible = false; //member management
            Response.Redirect("homepage.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}