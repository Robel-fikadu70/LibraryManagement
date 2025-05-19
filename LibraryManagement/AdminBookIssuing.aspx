<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminBookIssuing.aspx.cs" Inherits="LibraryManagement.AdminBookIssuing" %>

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
                <div class="card my-5 mx-2">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>book issuing</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/time-to-study.png" width="100" />

                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2"
                                        runat="server" Placeholder="Member ID"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="textbox1"
                                            runat="server" Placeholder="Book ID"></asp:TextBox>
                                        <asp:Button class="btn btn-secondary" ID="button1"
                                            runat="server" Text="Go" OnClick="button1_Click" />
                                    </div>
                                </div>

                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3"
                                        runat="Server" Placeholder="Member Name" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="Server" placeholder="Book Name" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6">
                                <label>Issue Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="textbox5"
                                        runat="server" placeholder="start date" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-6">
                                <label>Due Date</label>
                                <div class="form-group">

                                    <asp:TextBox CssClass="form-control" ID="textbox6"
                                        runat="server" placeholder="end date" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6 d-grid gap-2">
                                <asp:Button class="btn btn-outline-secondary mt-3" ID="button2"
                                    runat="server" Text="issue" OnClick="button2_Click" />
                            </div>


                            <div class="col-6 d-grid gap-2">
                                <asp:Button class="btn btn-outline-info mt-3" ID="button3"
                                    runat="server" Text="return" OnClick="button3_Click" />
                            </div>
                        </div>

                    </div>
                </div>
                <a href="homepage.aspx"><< back to homepage</a><br>
                <br>
            </div>

            <div class="col-md-7">
                <div class="card my-5 mx-3">
                    <div class="card-body">

                        <div class="row">
                            <div clas="col">
                                <center>
                                    <h4>issued book list</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>

                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:LibraryManagementDBConnectionString %>' SelectCommand="SELECT * FROM [Book_Issue]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered"
                                    ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="Member_ID" HeaderText="Member_ID" SortExpression="Member_ID" />
                                        <asp:BoundField DataField="Member_Name" HeaderText="Member_Name" SortExpression="Member_Name" />
                                        <asp:BoundField DataField="Book_ID" HeaderText="Book_ID" SortExpression="Book_ID" />
                                        <asp:BoundField DataField="Book_Name" HeaderText="Book_Name" SortExpression="Book_Name" />
                                        <asp:BoundField DataField="Issue_Date" HeaderText="Issue_Date" SortExpression="Issue_Date" />
                                        <asp:BoundField DataField="Due_Date" HeaderText="Due_Date" SortExpression="Due_Date" />
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
