<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="LibraryManagement.usersignup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6  mx-auto">
                <div class="card my-5 mx-3">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100" src="img/signup(1).png" /></center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Member Sign Up</h3>
                                </center>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <div class="form-group my-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Address</label>
                                <div class="form-group my-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Address" ></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact No</label>
                                <div class="form-group my-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col my-2">


                                <asp:Panel ID="Panel1" runat="server" Visible="false" Style="text-align: center; padding: 1rem;">
                                    <div style="background-color: #fff3f5; color: #e63946; padding: 0.5rem 1rem; border: 1px solid #e63946; border-radius: 6px; display: inline-block; font-size: 0.9rem;">
                                        <i class="fa-solid fa-triangle-exclamation" style="margin-right: 6px;"></i>
                                        Member Already Exists.
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel2" runat="server" Visible="false" Style="text-align: center; padding: 1rem;">
                                    <div style="background-color: #d4edda; color: #155724; padding: 0.5rem 1rem; border: 1px solid #c3e6cb; border-radius: 6px; display: inline-block; font-size: 0.9rem;">
                                        <i class="fa-solid fa-circle-check" style="margin-right: 6px; color: #155724;"></i>
                                        Sign up successful. Go to the login page to access your account.
                                    </div>
                                </asp:Panel>




                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Email</label>
                                <div class="form-group my-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Password</label>
                                <div class="form-group my-3">
                                    <asp:TextBox Class="form-control" ID="TextBox9" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button CssClass="btn w-100 my-2 btn-outline-success " ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" />
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
