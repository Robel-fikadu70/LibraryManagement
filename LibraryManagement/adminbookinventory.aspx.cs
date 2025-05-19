using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;


        protected void Page_Load(object sender, EventArgs e)
        {
            author_publisher_fetch();
            GridView1.DataBind();
        }

        //go button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            getBookByID();

        }
        //delete button
        protected void button4_Click(object sender, EventArgs e)
        {
            DeleteBookByID();
            ClearFormFields();
        }

        //update btn
        protected void button1_Click(object sender, EventArgs e)
        {
            updateByID();
            ClearFormFields();
        }
        //add btn
        protected void button2_Click(object sender, EventArgs e)
        {
            if (Checkbook())
            {
                Response.Write("<script>alert('book already exist'); </script>");
            }
            else
            {
                Add_Book();
                ClearFormFields();
            }

        }
        //for publisherfetch
        void author_publisher_fetch()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name from author;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                cmd = new SqlCommand("SELECT Publisher_Name from Publisher;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "Publisher_Name";
                DropDownList2.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }


        }

        bool Checkbook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Book WHERE Book_ID='" + textbox1.Text.Trim() + "' " +
                    "OR Book_Name='" + textbox2.Text.Trim() + "';", con);
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

        void Add_Book()
        {
            try
            {

                string genre = "";
                foreach(int i in ListBox1.GetSelectedIndices())
                {
                    genre = genre + ListBox1.Items[i] + ",";
                }
                genre = genre.Remove(genre.Length - 1);

                string filepath = "book_inv/";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("book_inv/" + filename));
                filepath = "book_inv/" + filename;

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO bOOK(Book_ID,Book_Name,Genre,Author_Name,Publisher_Name,Publish_Date,B_Language,Edition," +
                    "Book_Cost,No_Of_Pages,Book_Description,Actual_Stock,Current_Stock,Book_Img_Link) " +
                    "VALUES(@Book_ID,@Book_Name,@Genre,@Author_Name,@Publisher_Name,@Publish_Date,@B_Language,@Edition," +
                    "@Book_Cost,@No_Of_Pages,@Book_Description,@Actual_Stock,@Current_Stock,@Book_Img_Link)", con);

                cmd.Parameters.AddWithValue("@Book_ID", textbox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Book_Name", textbox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@Author_Name", DropDownList3.Text.Trim());
                cmd.Parameters.AddWithValue("@Publisher_Name", DropDownList2.Text.Trim());
                cmd.Parameters.AddWithValue("@Publish_Date", textbox3.Text.Trim());
                cmd.Parameters.AddWithValue("@B_Language", DropDownList1.Text.Trim());
                cmd.Parameters.AddWithValue("@Edition", textbox8.Text.Trim());
                cmd.Parameters.AddWithValue("@Book_Cost", textbox9.Text.Trim());
                cmd.Parameters.AddWithValue("@No_Of_Pages", textbox10.Text.Trim());
                cmd.Parameters.AddWithValue("@Book_Description", textbox11.Text.Trim());
                cmd.Parameters.AddWithValue("@Actual_Stock", textbox4.Text.Trim());
                cmd.Parameters.AddWithValue("@Current_Stock", textbox4.Text.Trim());
                cmd.Parameters.AddWithValue("@Book_Img_Link", filepath );

                cmd.ExecuteNonQuery();
                ClearFormFields();

                con.Close();
                Response.Write("<script>alert('book added successfully');</script>");
                GridView1.DataBind();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");

            }
        }

        void getBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from Book WHERE Book_ID = '"+textbox1.Text.Trim()+"' ;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 0) 
                {
                    textbox2.Text = dt.Rows[0]["Book_Name"].ToString();
                    textbox8.Text = dt.Rows[0]["Edition"].ToString();
                    textbox9.Text = dt.Rows[0]["Book_Cost"].ToString().Trim();
                    textbox10.Text = dt.Rows[0]["No_Of_Pages"].ToString().Trim();
                    textbox11.Text = dt.Rows[0]["Book_Description"].ToString();
                    textbox4.Text = dt.Rows[0]["Actual_Stock"].ToString().Trim();
                    textbox5.Text = dt.Rows[0]["Current_Stock"].ToString().Trim();
                    DropDownList1.SelectedValue = dt.Rows[0]["B_Language"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["Author_Name"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["Publisher_Name"].ToString().Trim();
                    textbox3.Text = dt.Rows[0]["Publish_Date"].ToString();
                    ListBox1.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(','); 
                    for(int i = 0; i<genre.Length; i++)
                    {
                        for(int j = 0; j<ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                        }
                    }
                    
                    
                    textbox6.Text = ""+ (Convert.ToInt32(dt.Rows[0]["Actual_Stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["Current_Stock"].ToString()));


                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["Actual_Stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["Current_Stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["Book_img_Link"].ToString();


                }
                else 
                {
                    Response.Write("<script>alert('Invalid book ID'); </script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }

        void DeleteBookByID()
        {
            if (Checkbook())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("DELETE FROM Book WHERE Book_ID = '" + textbox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Deleted');</script>");
                    
                    GridView1.DataBind();
                }
                catch(Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid BookID');</script>");

            }
        }
        void updateByID()
        {
            if (Checkbook())
            {
                try
                {

                    int actual_stock = Convert.ToInt32(textbox4.Text.Trim());
                    int current_stock = Convert.ToInt32(textbox6.Text.Trim());

                    if (global_actual_stock == actual_stock) { 

                    
                    }
                    else
                    {
                        if(actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('actual value can not be less than issued book');</script>");
                            return;
                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            textbox6.Text = "" + current_stock;
                        }
                    }

                    string genre = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genre = genre + ListBox1.Items[i] + ",";
                    }
                    genre = genre.Remove(genre.Length - 1);


                    string filepath = "book_inv/stack-of-books.png";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if(filename =="" || filename == null)
                    {
                        filepath = global_filepath;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inv/" + filename));
                        filepath = " book_inv/" + filename;
                    }

                   

                    SqlConnection conn = new SqlConnection(strcon);
                    if(conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE Books SET" +
                        "Book_Name=@Book_Name,Genre = @Genre, Author_Name=@Author_Name," +
                        "Publisher_Name = @Publisher_Name, Publish_Date=@Publish_Date,B_Language = @B_Language," +
                        "Edition = @Edition,Book_Cost=@Book_Cost,No_Of_Pages = @No_Of_Pages, Book_Description = @Book_Description," +
                        "Actual_Stock = @Actual_Stock,Current_Stock = @Current_Stock,Book_Img_Link = @Book_Img_Link, WHERE Book_ID='" + textbox1.Text.Trim() + "'", conn);

                    cmd.Parameters.AddWithValue("@Book_Name", textbox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genre);
                    cmd.Parameters.AddWithValue("@Author_Name", DropDownList3.Text.Trim());
                    cmd.Parameters.AddWithValue("@Publisher_Name", DropDownList2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Publish_Date", textbox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@B_Language", DropDownList1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Edition", textbox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@Book_Cost", textbox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@No_Of_Pages", textbox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@Book_Description", textbox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@Actual_Stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@Current_Stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@Book_Img_Link", filepath);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('book updated successfully');</script>");
                }
                catch(Exception ex)
                {
                    //Response.Write("<script>alert('"+ex.Message+"');</script>");
                }
            }

            else
            {
                Response.Write("<script>alert('Invalid book_ID');</script>");

            }
        }

        void ClearFormFields()
        {
            // Clear textboxes
            textbox1.Text = "";
            textbox2.Text = "";
            textbox3.Text = "";
            textbox4.Text = "";
            textbox8.Text = "";
            textbox9.Text = "";
            textbox10.Text = "";
            textbox11.Text = "";

            // Reset dropdowns to their first item (or set a specific default)
            DropDownList1.SelectedIndex = 0;
            DropDownList2.SelectedIndex = 0;
            DropDownList3.SelectedIndex = 0;

            // Clear selected items in ListBox
            ListBox1.ClearSelection();

            // Optionally reset the FileUpload control (cannot set the value due to security restrictions)
            // FileUpload1.FileName is read-only, so no need to reset it manually.
        }
    }
}
