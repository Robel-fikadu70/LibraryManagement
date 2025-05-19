<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="LibraryManagement.adminlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4 mx-auto">
                <div class="card my-5 mx-2">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150" src="img/user.png" /></center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Admin Login</h3>
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
                                <asp:Panel ID="Panel1" runat="server" Visible="false" Style="text-align: center; padding: 1rem;">
                                    <div style="background-color: #fff3f5; color: #e63946; padding: 0.5rem 1rem; border: 1px solid #e63946; border-radius: 6px; display: inline-block; font-size: 0.9rem;">
                                        <i class="fa-solid fa-triangle-exclamation" style="margin-right: 6px;"></i>
                                        Incorrect Credential.
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel2" runat="server" Visible="false" Style="text-align: center; padding: 1rem;">
                                    <div style="background-color: #d4edda; color: #155724; padding: 0.5rem 1rem; border: 1px solid #c3e6cb; border-radius: 6px; display: inline-block; font-size: 0.9rem;">
                                        <i class="fa-solid fa-circle-check" style="margin-right: 6px; color: #155724;"></i>
                                        Login successful.
                                    </div>
                                </asp:Panel>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">

                                <div class="form-group my-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="User Name"></asp:TextBox>
                                </div>


                                <div cssclass="form-group my-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>


                                <div class="form-group my-3 ">
                                    <asp:Button CssClass="btn btn-outline-success w-100" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                                </div>


                            </div>
                        </div>

                    </div>

                </div>
                <a class="link-underline link-underline-opacity-0" href="homepage.aspx"><< Back to Home </a>
                <br />
                <br />
            </div>
        </div>
    </div>

</asp:Content>
