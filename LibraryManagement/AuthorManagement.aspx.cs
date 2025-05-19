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
    public partial class AuthorManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //go btn
        protected void Go_btn_Click(object sender, EventArgs e)
        {
            getMemberById();
        }

        //Add btn
        protected void Add_btn_Click(object sender, EventArgs e)
        {
            
            AddAuthor(); 
        }

        //update btn
        protected void update_btn_Click(object sender, EventArgs e)
        {
            UpdateAuthor();
        }

        //delete btn
        protected void delete_btn_Click(object sender, EventArgs e)
        {
            DeleteAuthor();
        }


        bool CheckAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM author WHERE author_ID='" + author_Id_tbx.Text.Trim() + "';", con);
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
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
                return false;
            }
        }

        void AddAuthor()
        {
            if (CheckAuthor())
            {
                Response.Write("<script>alert('Author already exist!');</script>");

            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO author (author_ID,author_name) values (@author_ID,@author_Name)", con);



                    cmd.Parameters.AddWithValue("@author_ID", author_Id_tbx.Text.Trim());
                    cmd.Parameters.AddWithValue("@author_Name", Author_Name_tbx.Text.Trim());

                    cmd.ExecuteNonQuery();

                    con.Close();
                    Response.Write("<script>alert('author added succesfully ');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

                GridView1.DataBind();

            }
        }

        void UpdateAuthor()
        {
            if (CheckAuthor())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE author SET author_name=@author_name WHERE author_ID='" + author_Id_tbx.Text.Trim() + "';", con);



                    cmd.Parameters.AddWithValue("@author_name", Author_Name_tbx.Text.Trim());

                    cmd.ExecuteNonQuery();

                    con.Close();
                    Response.Write("<script>alert('author updated succesfully ');</script>");
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }

            else
            {
          
                Response.Write("<script>alert('Author Doesn't exist'); </script>");
                
            }

        }

        void DeleteAuthor()
        {
            if (CheckAuthor()) 
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM author WHERE author_ID=@author_ID;", con);


                    cmd.Parameters.AddWithValue("@author_ID", author_Id_tbx.Text.Trim());
                    cmd.Parameters.AddWithValue("@author_name", Author_Name_tbx.Text.Trim());

                    cmd.ExecuteNonQuery();

                    con.Close();
                    Response.Write("<script>alert('author deleted succesfully ');</script>");
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Author doesn't exist'); </script>");
            }



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

                SqlCommand cmd = new SqlCommand("select * from author where author_ID='" + author_Id_tbx.Text.Trim() + "'", con);


                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        Author_Name_tbx.Text = dr.GetValue(1).ToString(); //author name
                        

                    }

                }
                else
                {
                    Response.Write("<script>alert('no author with this id');</script>");


                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}