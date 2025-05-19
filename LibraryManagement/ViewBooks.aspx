<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewBooks.aspx.cs" Inherits="LibraryManagement.ViewBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-sm-12">
                <center>
                    <h3>List Of Books</h3>
                </center>
                <div class="row">
                    <div class="col-sm-12 col-md-12">
                        <asp:Panel class="alert alert-success" role="alert" ID="Panel1" runat="server" Visible="false">
                            <asp:Label runat="server" Text="Label"></asp:Label>
                        </asp:Panel>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="card">
                        <div class="card-body">



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
            <center>
                <a href="Homepage.aspx"><< back to Home </a><span class="clearfix"></span>
                <br />
            </center>
        </div>
    </div>
</asp:Content>
