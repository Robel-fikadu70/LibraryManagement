<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="LibraryManagement.userprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card my-5 mx-3">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100" src="img/reading-book.png" /></center>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>your profile</h3>
                                    <span>Account Status-</span>
                                    <asp:Label class="badge rounded-pill text-bg-info" ID="Label1" runat="server" Text="Your States"></asp:Label>
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
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact No" TextMode="Number" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Email ID</label>
                                <div class="form-group my-3">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email ID" TextMode="Email" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col my-2">
                                <center><span class="badge rounded-pill text-bg-info">Login Credentials</span></center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>User ID</label>
                                <div class="form-group my-3">
                                    <asp:TextBox Class="form-control" ID="TextBox8" runat="server" placeholder="User ID" AutoPostBack="False" aria-readonly="True" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Old Password</label>
                                <div class="form-group my-3">
                                    <asp:TextBox Class="form-control" ID="TextBox9" runat="server" placeholder="Password"  ></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-4">
                                <label>New Password</label>
                                <div class="form-group my-3">
                                    <asp:TextBox Class="form-control" ID="TextBox5" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-8 mx-auto">
                                <a href="usersignup.aspx" class="link-underline link-underline-opacity-0">
                                    <center>
                                        <div class="form-group d-grid">
                                            <asp:Button class="btn btn-outline-primary d-block" ID="Button1" runat="server" text="Update" OnClick="Button1_Click" />
                                        </div>
                                    </center>
                                </a>
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
                                    <img width="100" src="img/schedule.png" /></center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>your issus books</h3>

                                    <asp:Label class="badge text-bg-info" ID="Label2" runat="server" Text="your books info "></asp:Label>
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
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                            </div>
                        </div>

                    </div>

                </div>
            </div>


        </div>
    </div>

</asp:Content>
