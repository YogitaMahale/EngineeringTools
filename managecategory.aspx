﻿<%@ Page Title="" Language="C#" MasterPageFile="~/morya.master" AutoEventWireup="true" CodeFile="managecategory.aspx.cs" Inherits="managecategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div class="row">
                <div class="col-xs-12">

                    <!-- /.box -->


                   
                    <div class="box">
                        <br />
                         <div class="text-center">
                        <b id="spnMessage" visible="false" runat="server"></b>
                    </div>
                        <br />
                        <!-- /.box-header -->
                        <div class="box-body">
                            <br />
                            <div style="text-align:left;">
                                 <table>
                            <tr>
                                
                                <td>
                                    <label for="exampleInputPassword1">Select Type</label></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text=":" Width="10"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddltype" Class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                                       
                                    </asp:DropDownList></td>
                            </div>
                            <div style="text-align:right;">

                                <asp:Button ID="btnNewCategoty" runat="server" Text="Add New Category" class="btn btn-Normal btn-primary" OnClick="btnNewCategoty_Click" Width="150" />
                            </div>
                            <br />
                            <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th style="text-align: center">Seq No</th>
                                        <th style="text-align: center">Name</th>
                                        <th style="text-align: center">Image</th>
                                        <th style="text-align: center">Is Show</th>
                                        <th style="text-align: center">Action</th>
                                    </tr>
                                </thead>


                                <tbody>
                                    <asp:Repeater ID="repCategory" runat="server" OnItemDataBound="repCategory_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center">
                                                    <asp:DropDownList ID="ddlSeqNo" runat="server" CssClass="form-control" Width="70px" AutoPostBack="true" OnSelectedIndexChanged="ddlSeqNo_SelectedIndexChanged" />
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblCategoryId" runat="server" Visible="false" Text='<%# Eval("cid") %>'></asp:Label>
                                                    <asp:Label ID="lblProductCount" runat="server" Visible="false" Text='<%# Eval("productcount") %>'></asp:Label>
                                                    <asp:Label ID="lblSeqNo" runat="server" Visible="false" Text='<%# Eval("seqno") %>'></asp:Label>
                                                    <asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("categoryname") %>'></asp:Label>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Image ID="imgCategory" Width="75px" Height="50px" runat="server"></asp:Image>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:CheckBox ID="IsActive" runat="server" AutoPostBack="true" Checked='<%# Eval("isactive") %>' OnCheckedChanged="IsActive_CheckedChanged" />
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:HyperLink ID="hlEdit" runat="server" Style="text-decoration: underline" class="btn btn-success" Text="Edit"></asp:HyperLink>&nbsp;
                                        &nbsp;<asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" class="btn btn-danger" OnClientClick="return confirm('Do you want to delete this category?');" OnClick="lnkDelete_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th style="text-align: center">Seq No</th>
                                        <th style="text-align: center">Name</th>
                                        <th style="text-align: center">Image</th>
                                        <th style="text-align: center">Is Show</th>
                                        <th style="text-align: center">Action</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
            <!-- ./wrapper -->
        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- jQuery 3 -->
    <script src="Template/bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="Template/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- DataTables -->
    <script src="Template/bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="Template/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <!-- SlimScroll -->
    <script src="Template/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="Template/bower_components/fastclick/lib/fastclick.js"></script>
    <!-- AdminLTE App -->
    <script src="Template/dist/js/adminlte.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="Template/dist/js/demo.js"></script>
    <!-- page script -->
    <script>
        $(function () {
            $('#example1').DataTable()
            $('#example2').DataTable({
                'paging': true,
                'lengthChange': false,
                'searching': false,
                'ordering': true,
                'info': true,
                'autoWidth': false
            })
        })
    </script>

</asp:Content>

