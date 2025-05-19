<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="LibraryManagement.adminmembermanagement" %>
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
                        <div class="row mb-3">
                            <div class="col text-center">
                                <h4>Member Details</h4>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col text-center">
                                <img src="img/verified-account.png" width="100" alt="Verified Account" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="textbox1"
                                        runat="server" placeholder="Member ID"></asp:TextBox>
                                    <asp:LinkButton class="btn btn-secondary" ID="linkButton0"
                                        runat="server" onclick="LinkButton0_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Full Name</label>
                                <asp:TextBox CssClass="form-control" ID="textbox2"
                                    runat="server" placeholder="Full Name" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label>Status</label>
                                <div class="input-group ">
                                    <asp:TextBox CssClass="form-control me-1" ID="textbox7"
                                        runat="server" placeholder="Account Status" ReadOnly="true"></asp:TextBox>
                                    <!-- Buttons to change account status -->
                                    <asp:LinkButton class="btn btn-outline-success me-1" ID="linkButton1"
                                        runat="server" OnClick="LinkButton1_Click" ><i class="fas fa-check-circle " ></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn btn-outline-warning me-1" ID="linkButton2"
                                        runat="server" onclick="LinkButton2_Click"><i class="fas fa-pause-circle"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn btn-outline-danger me-1" ID="linkButton3"
                                        runat="server" onclick="LinkButton3_Click" ><i class="fas fa-times-circle"></i></asp:LinkButton>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Date of Birth</label>
                                <asp:TextBox CssClass="form-control" ID="textbox4"
                                    runat="server" placeholder="DoB" TextMode="Date" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label>Phone</label>
                                <asp:TextBox CssClass="form-control" ID="textbox5"
                                    runat="server" placeholder="Phone" ReadOnly="true"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label>Email</label>
                                <asp:TextBox CssClass="form-control" ID="textbox6"
                                    runat="server" placeholder="Email" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mt-4">
                            <div class="col text-center">
                                <asp:Button class="btn btn btn-outline-danger px-5" ID="button4"
                                    runat="server" onclick="button4_Click" Text="Delete User" />
                            </div>
                        </div>


                        <div class="row mt-3">
                            <div class="col text-center">
                                <a href="homepage.aspx">Back to Homepage</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-7">
                <div class="card my-5 mx-3">
                    <div class="card-body">
                        <div class="row mb-3">
                            <div class="col text-center">
                                <h4>Member List</h4>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LibraryManagementDBConnectionString %>" SelectCommand="SELECT * FROM [Member_Table]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered"
                                    ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Member_ID" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="Member_ID" HeaderText="Member_ID" ReadOnly="True" SortExpression="Member_ID" />
                                        <asp:BoundField DataField="Full_Name" HeaderText="Full_Name" SortExpression="Full_Name" />
                                        <asp:BoundField DataField="Acc_Status" HeaderText="Acc_Status" SortExpression="Acc_Status" />
                                        <asp:BoundField DataField="Phone_No" HeaderText="Phone_No" SortExpression="Phone_No" />
                                        <asp:BoundField DataField="Full_Address" HeaderText="Full_Address" SortExpression="Full_Address" />
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
