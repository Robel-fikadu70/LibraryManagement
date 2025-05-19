<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminpublishermanagement.aspx.cs" Inherits="LibraryManagement.adminpublishermanagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card my-5 mx-3">
                    <div class="card-body">
                        <div class="text-center mb-3">
                            <h4>Publisher Detail</h4>
                        </div>

                        <div class="text-center mb-3">
                            <img src="img/printer.png" alt="Publisher Image" style="width: 100px;" />
                        </div>

                        <hr />

                        <div class="row mb-3">
                            <div class="col-md-3">
                                <label for="TextBox1">Publisher ID</label>
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                    <asp:Button CssClass="btn btn-secondary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                                </div>
                            </div>
                            <div class="col-md-9">
                                <label for="TextBox2">Publisher Name</label>
                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Name"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="row">
                                <div class="col-4 d-grid gap-2">
                                    <asp:Button Class="btn btn-outline-success mx-2" ID="Button2" runat="server" Text="Add" OnClick="Button2_Click" />
                                </div>
                                <div class="col-4 d-grid gap-2">
                                    <asp:Button CssClass="btn btn-outline-warning mx-2" ID="Button3" runat="server" Text="Update" OnClick="Button3_Click" />
                                </div>
                                <div class="col-4 d-grid gap-2">
                                    <asp:Button CssClass="btn btn-outline-danger mx-2" ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click" />
                                </div>
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
                                    <h3>Publisher List</h3>


                                </center>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">


                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LibraryManagementDBConnectionString %>" SelectCommand="SELECT * FROM [Publisher]"></asp:SqlDataSource>


                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Publisher_ID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="Publisher_ID" HeaderText="Publisher_ID" ReadOnly="True" SortExpression="Publisher_ID" />
                                        <asp:BoundField DataField="Publisher_Name" HeaderText="Publisher_Name" SortExpression="Publisher_Name" />
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
