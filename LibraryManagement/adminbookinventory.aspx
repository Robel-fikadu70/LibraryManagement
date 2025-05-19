<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookinventory.aspx.cs" Inherits="LibraryManagement.adminbookinventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });


        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $("#imgview").attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">

                <div class="card my-5 mx-2">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgview" src="book_inv/stack-of-books.png" width="100" />
                                </center>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:FileUpload onchange="readURL(this);" CssClass="form-control" ID="FileUpload1" runat="server" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="textbox1"
                                            runat="server" placeholder="Book ID"></asp:TextBox>
                                        <asp:Button class="btn btn-block btn-primary"  ID="Button3" runat="server" Text="GO" OnClick="Button3_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-9">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="textbox2"
                                        runat="server" placeholder="Book Name"></asp:TextBox>
                                </div>
                            </div>



                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Amharic" Value="Amharic"></asp:ListItem>
                                        <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                        <asp:ListItem Text="French" Value="French"></asp:ListItem>
                                        <asp:ListItem Text="Spanish" Value="Spanish"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server">

                                    </asp:DropDownList>
                                </div>

                                <label>Publisher Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="textbox3"
                                        runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>
                                </div>

                            </div>


                            <div class="col-md-4">
                                <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox ID="ListBox1" runat="server" CssClass="form-control" SelectionMode="Multiple">
                                        <asp:ListItem Text="ADVENTURE" Value="ADVENTURE"></asp:ListItem>
                                        <asp:ListItem Text="ART" Value="ART"></asp:ListItem>
                                        <asp:ListItem Text="CHILDREN'S" Value="CHILDREN'S"></asp:ListItem>
                                        <asp:ListItem Text="COOKING" Value="COOKING"></asp:ListItem>
                                        <asp:ListItem Text="CONTEMPORARY" Value="CONTEMPORARY"></asp:ListItem>
                                        <asp:ListItem Text="DYSTOPIAN" Value="DYSTOPIAN"></asp:ListItem>
                                        <asp:ListItem Text="FAMILIES & RELATIONSHIPS" Value="FAMILIES & RELATIONSHIPS"></asp:ListItem>
                                        <asp:ListItem Text="FANTASY" Value="FANTASY"></asp:ListItem>
                                        <asp:ListItem Text="GUIDE/HOW-TO" Value="GUIDE/HOW-TO"></asp:ListItem>
                                        <asp:ListItem Text="HEALTH" Value="HEALTH"></asp:ListItem>
                                        <asp:ListItem Text="HISTORICAL FICTION" Value="HISTORICAL FICTION"></asp:ListItem>
                                        <asp:ListItem Text="HISTORY" Value="HISTORY"></asp:ListItem>
                                        <asp:ListItem Text="HORROR" Value="HORROR"></asp:ListItem>
                                        <asp:ListItem Text="HUMOR" Value="HUMOR"></asp:ListItem>
                                        <asp:ListItem Text="MEMOIR" Value="MEMOIR"></asp:ListItem>
                                        <asp:ListItem Text="MYSTERY" Value="MYSTERY"></asp:ListItem>
                                        <asp:ListItem Text="MOTIVATIONAL" Value="MOTIVATIONAL"></asp:ListItem>
                                        <asp:ListItem Text="PARANORMAL" Value="PARANORMAL"></asp:ListItem>
                                        <asp:ListItem Text="ROMANCE" Value="ROMANCE"></asp:ListItem>
                                        <asp:ListItem Text="SCIENCE FICTION" Value="SCIENCE FICTION"></asp:ListItem>
                                        <asp:ListItem Text="SELF-HELP / PERSONAL DEVELOPMENT" Value="SELF-HELP / PERSONAL DEVELOPMENT"></asp:ListItem>
                                        <asp:ListItem Text="THRILLER" Value="THRILLER"></asp:ListItem>
                                        <asp:ListItem Text="TRAVEL" Value="TRAVEL"></asp:ListItem>
                                    </asp:ListBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Edition</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="textbox8"
                                        runat="server" placeholder="Edition"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Cost(per unit)</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="textbox9"
                                        runat="server" placeholder="Cost" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Page</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="textbox10"
                                        runat="server" placeholder="Page" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="textbox4"
                                        runat="server" placeholder="stock" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Current stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="textbox5"
                                        runat="server" placeholder="Current stock" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>issue</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="textbox6"
                                        runat="server" placeholder="Page" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-12">
                                <label>Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="textbox11"
                                        runat="server" placeholder="description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4 d-grid gap-2">
                                <asp:Button class="btn btn-outline-danger mt-3" ID="button4" runat="server" Text="delete" OnClick="button4_Click" />
                            </div>

                            <div class="col-4 d-grid gap-2">
                                <asp:Button class="btn btn-outline-warning mt-3" ID="button1" runat="server" Text="Update" OnClick="button1_Click" />
                            </div>

                            <div class="col-4 d-grid gap-2">
                                <asp:Button class="btn btn-outline-success mt-3" ID="button2" runat="server" Text="Add" OnClick="button2_Click" />
                            </div>
                        </div>

                        <a href="homepage.aspx"><< back to homepage </a>
                        <br>
                        <br>
                    </div>
                </div>
            </div>


            <div class="col-md-7">
                <div class="card my-5 mx-2">
                    <div class="card-body">

                        <div class="row">
                            <div clas="col">
                                <center>
                                    <h4>Book List</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LibraryManagementDBConnectionString %>" SelectCommand="SELECT * FROM [Book]"></asp:SqlDataSource>
                                <hr>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered"
                                    ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="Book_ID" HeaderText="ID" SortExpression="Book_ID" />



                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Book_Name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Author-|<asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Author_Name") %>'></asp:Label>
                                                                    |Genere-<asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("Genre") %>'></asp:Label>
                                                                    |language-<asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("B_Language") %>'></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Publisher-<asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("Publisher_Name") %>'></asp:Label>
                                                                    |Publish date-<asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("Publish_Date") %>'></asp:Label>
                                                                    |page-<asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("No_Of_Pages") %>'></asp:Label>
                                                                    |Edition-<asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("Edition") %>'></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    cost-<asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("Book_Cost") %>'></asp:Label>
                                                                    | Stock-<asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("Actual_Stock") %>'></asp:Label>
                                                                    | Available-<asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("Current_Stock") %>'></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Description-<asp:Label ID="Label12" runat="server" Font-Bold="True" Text='<%# Eval("Book_Description") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-6 col-md-4 col-lg-2">
                                                            <asp:Image class="img-fluid p-2" ID="Image1" runat="server" ImageUrl='<%# Eval("Book_Img_Link") %>' />
                                                        </div>
                                                    </div>


                                                </div>
                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
