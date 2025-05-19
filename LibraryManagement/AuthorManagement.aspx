<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AuthorManagement.aspx.cs" Inherits="LibraryManagement.AuthorManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="row">
        <div class="col-md-5">
            <div class="card my-5 mx-3">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <h4>Author Detail</h4>
                            </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <center>
                                <img width="100" src="img/writer.png" />
                                
                            </center>
                        </div>

                    </div>


                    <div class="row">
                        <div class="col">
                            <hr />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <label>Author Id</label>
                            <div class="form-group ">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="author_Id_tbx" runat="server" placeholder="Id" ></asp:TextBox>
                                    <asp:Button CssClass="btn btn-secondary" ID="Go_btn" runat="server" Text="Go" OnClick="Go_btn_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-9">
                            <label>Author Name</label>
                            <div class="form-group ">
                                <asp:TextBox CssClass="form-control" ID="Author_Name_tbx" runat="server" placeholder="Author Name"></asp:TextBox>
                            </div>
                        </div>
                    </div>


                    <div class="row my-2">
                        <div class="col-4 d-grid gap-2">
                            <asp:Button CssClass="btn btn-outline-success me-2" ID="Add_btn" runat="server" Text="Add" OnClick="Add_btn_Click"  />
                        </div>
                        <div class="col-4 d-grid gap-2">
                            <asp:Button CssClass="btn btn-outline-warning me-2" ID="update_btn" runat="server" Text="update" OnClick="update_btn_Click"  />
                        </div>
                        <div class="col-4 d-grid gap-2">
                            <asp:Button CssClass="btn btn-outline-danger me-2" ID="delete_btn" runat="server" Text="delete" OnClick="delete_btn_Click"  />
                        </div>
                    </div>

                </div>

            </div>
            <a class="link-underline link-underline-opacity-0" href="#"><< Back to Home </a>
            <br />
            <br />
        </div>
        <div class="col-md-7">
            <div class="card my-5 mx-3">
                <div class="card-body">


                    <div class="row">
                        <div class="col">
                            <center>
                                <h3>Author List</h3>


                            </center>
                        </div>
                    </div>



                    <div class="row">
                        <div class="col">
                            <hr />
                        </div>
                    </div>


                    <div class="row">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LibraryManagementDBConnectionString %>" SelectCommand="SELECT * FROM [author]"></asp:SqlDataSource>
                        <div class="col">
                            <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="author_ID">
                                <Columns>
                                    <asp:BoundField DataField="author_ID" HeaderText="author_ID" ReadOnly="True" SortExpression="author_ID" />
                                    <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
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
