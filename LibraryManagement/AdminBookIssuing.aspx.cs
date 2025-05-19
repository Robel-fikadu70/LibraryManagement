using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class AdminBookIssuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Go_btn
        protected void button1_Click(object sender, EventArgs e)
        {
            GetName();
        }

        //Issue_btn
        protected void button2_Click(object sender, EventArgs e)
        {

            if (CheckBook() && Checkmember())
            {
                if (IssueCheck())
                {
                    Response.Write("<script>alert('MEMBER ALREADY GOT THIS BOOK')</script>");
                }
                else
                {
                    add();
                }
                
            }
            else
            {
                Response.Write("<script>alert('Wrong ID')</script>");
            }
        }

        //return_btn
        protected void button3_Click(object sender, EventArgs e)
        {
            if (CheckBook() && Checkmember())
            {
                if (IssueCheck())
                {
                    ReturnBook();
                }
                else
                {
                    Response.Write("<script>alert('DOESN'T EXIST')</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Wrong ID')</script>");
            }
        }

        void ReturnBook()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM Book_Issue WHERE Member_ID ='" + TextBox2.Text.Trim() + "' AND Book_ID ='" + textbox1.Text.Trim() + "' ", conn);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd = new SqlCommand("UPDATE Book SET Current_Stock = Current_Stock+1 WHERE Book_ID ='" + textbox1.Text.Trim() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("<script>alert('book returned succesfully ');</script>");
                    GridView1.DataBind();

                }
            }
            catch (Exception ex) { 
            
            }
        }

        void GetName()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == System.Data.ConnectionState.Closed) {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT Book_Name FROM Book WHERE Book_ID ='"+textbox1.Text.Trim()+"' ", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["Book_Name"].ToString();
                }
                else {
                    Response.Write("<script>alert('Wrong ID')</script>");
                }

                cmd = new SqlCommand("SELECT Full_Name FROM Member_Table WHERE Member_ID ='" + TextBox2.Text.Trim() + "' ", conn);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["Full_Name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong ID')</script>");
                }


            }
            catch (Exception ex) { 

            
            }

        }

        bool CheckBook()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Book WHERE Book_ID ='" + textbox1.Text.Trim() + "' AND Current_Stock > 0 ", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;                }
            }
            catch (Exception ex) {
                return false;
            }
            
            //return false;
        }

        bool Checkmember()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT Full_Name FROM Member_Table WHERE Member_ID ='" + TextBox2.Text.Trim() + "' ", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            //return false;
        }

        bool IssueCheck()
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Book_Issue WHERE Member_ID ='" + TextBox2.Text.Trim() + "' AND Book_ID ='" + textbox1.Text.Trim()+"' ", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            //return false;
        }

        void add()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
               
                SqlCommand cmd = new SqlCommand("INSERT INTO Book_Issue (Member_ID, Member_Name, Book_ID, Book_Name, Issue_Date, Due_Date) " +
                    "VALUES (@Member_ID, @Member_Name, @Book_ID, @Book_Name, @Issue_Date, @Due_Date)", con);
                
                cmd.Parameters.AddWithValue("@Member_ID", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Member_Name", TextBox3.Text.Trim()); 
                cmd.Parameters.AddWithValue("@Book_ID", textbox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Book_Name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@Issue_Date", textbox5.Text.Trim());
                cmd.Parameters.AddWithValue("@Due_Date", textbox6.Text.Trim());

                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("UPDATE Book SET Current_Stock = Current_Stock-1 WHERE Book_ID ='" + textbox1.Text.Trim() + "'",con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Issue added succesfully ');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


    }
}