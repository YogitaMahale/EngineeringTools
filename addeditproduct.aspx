﻿<%@ Page Title="" Language="C#" MasterPageFile="~/morya.master" AutoEventWireup="true" CodeFile="addeditproduct.aspx.cs" Inherits="addeditproduct" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .error {
            color: red;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div style="text-align:center;">
                    <h3 class="box-title"><b id="spnMessgae" runat="server"></b></h3>
                </div>
        <!-- left column -->
        <div class="col-md-6">
            <!-- general form elements -->
            <div class="box box-primary">
                <%--<div class="box-header with-border">
                    <h3 class="box-title"><b id="spnMessgae" runat="server"></b></h3>
                </div>--%>
                <!-- /.box-header -->
                <!-- form start -->

                <div class="box-body">
                      <div class="form-group">
                        <label for="exampleInputEmail1">Select Type </label>
                        <asp:DropDownList ID="ddlType" Class="form-control" Width="500px" AutoPostBack="true"  OnSelectedIndexChanged="ddlType_SelectedIndexChanged" runat="server"></asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlType" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                    </div>
                      <div class="form-group">
                        <label for="exampleInputEmail1">Select Brand </label>
                        <asp:DropDownList ID="ddlBrand" Class="form-control" Width="500px" runat="server"></asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlBrand" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                    </div>
                    <%---------------------------------------------------%>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Select Category </label>
                        <asp:DropDownList ID="ddlCategory" Class="form-control" Width="500px" runat="server"></asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RFVddlCategory" runat="server" InitialValue="0" Display="Dynamic" ControlToValidate="ddlCategory" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Product Name </label>
                        <asp:TextBox ID="txtProductName" Class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtProductName" runat="server" Display="Dynamic" ControlToValidate="txtProductName" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group" >
                        <label for="exampleInputEmail1">Product SKU</label>
                        <asp:TextBox ID="txtSKU" Class="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="exampleInputPassword1">Customer Price </label>
                        <asp:TextBox ID="txtCustomerProductPrice" Class="form-control" runat="server"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBtxtCustomerProductPrice" runat="server" FilterMode="ValidChars" TargetControlID="txtCustomerProductPrice" ValidChars="01234567890."></cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="RFVtxtCustomerProductPrice" runat="server" Display="Dynamic" ControlToValidate="txtCustomerProductPrice" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>
                    </div>



                    <div class="form-group">
                        <label for="exampleInputPassword1">Dealer Price</label>
                        <asp:TextBox ID="txtDealerPrice" Class="form-control" runat="server"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBDealer" runat="server" FilterMode="ValidChars" TargetControlID="txtDealerPrice" ValidChars="01234567890."></cc1:FilteredTextBoxExtender>

                        <asp:RequiredFieldValidator ID="RFVtxtDealerPrice" runat="server" Display="Dynamic" ControlToValidate="txtDealerPrice" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                    </div>

                    <div class="form-group">
                        <label for="exampleInputPassword1">Wholesale Price</label>
                        <asp:TextBox ID="txtWholesalePrice" Class="form-control" runat="server"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBtxtWholesalePrice" runat="server" FilterMode="ValidChars" TargetControlID="txtWholesalePrice" ValidChars="01234567890."></cc1:FilteredTextBoxExtender>

                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Super Wholesale Price</label>
                        <asp:TextBox ID="txtSuperWholesalePrice" Class="form-control" runat="server"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBtxtSuperWholesalePrice" runat="server" FilterMode="ValidChars" TargetControlID="txtSuperWholesalePrice" ValidChars="01234567890."></cc1:FilteredTextBoxExtender>

                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Product Discount Price</label>
                        <asp:TextBox ID="txtDiscountProductPrice" Class="form-control" runat="server"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBtxtDiscountProductPrice" runat="server" FilterMode="ValidChars" TargetControlID="txtDiscountProductPrice" ValidChars="01234567890."></cc1:FilteredTextBoxExtender>

                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Product GST in %</label>
                        <asp:TextBox ID="txtGST" Class="form-control" runat="server"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBtxtGST" runat="server" FilterMode="ValidChars" TargetControlID="txtGST" ValidChars="01234567890."></cc1:FilteredTextBoxExtender>

                    </div>

                    <div class="form-group">
                        <label for="exampleInputPassword1">Stock Quantites </label>
                        <asp:TextBox ID="txtQuantites" Class="form-control" runat="server"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBtxtQuantites" runat="server" FilterMode="ValidChars" TargetControlID="txtQuantites" ValidChars="01234567890.%"></cc1:FilteredTextBoxExtender>

                        <asp:RequiredFieldValidator ID="RFVtxtQuantites" runat="server" Display="Dynamic" ControlToValidate="txtQuantites" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Stock Alert Quantites</label>
                        <asp:TextBox ID="txtAlertQuantites" Class="form-control" runat="server"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FTBtxtAlertQuantites" runat="server" FilterMode="ValidChars" TargetControlID="txtAlertQuantites" ValidChars="01234567890.%"></cc1:FilteredTextBoxExtender>

                        <asp:RequiredFieldValidator ID="RFVtxtAlertQuantites" runat="server" Display="Dynamic" ControlToValidate="txtAlertQuantites" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Is Stock</label>
                        <asp:CheckBox ID="cbIsStock" Class="form-control" runat="server"></asp:CheckBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Is HotProduct</label>
                        <asp:CheckBox ID="cbIsHotproduct" Class="form-control" runat="server"></asp:CheckBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">HSN Code</label>
                        <asp:TextBox ID="txt_Hsncode" Class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txt_Hsncode" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Real Stock</label>
                        <asp:TextBox ID="txt_RealStock" Class="form-control" runat="server"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars" TargetControlID="txt_RealStock" ValidChars="01234567890.%"></cc1:FilteredTextBoxExtender>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="txt_RealStock" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                    </div>



                </div>
                <!-- /.box-body -->



            </div>
            <!-- /.box -->

            <!-- Form Element sizes -->

            <!-- /.box -->


            <!-- /.box -->

            <!-- Input addon -->

            <!-- /.box -->

        </div>
        <div class="col-md-6">
            <div class="box box-primary">
                <div class="box-body">
                    <div class="form-group">
                        <label for="exampleInputPassword1">Puchase( Landing ) Price</label>
                        <asp:TextBox ID="txt_landingprice" Class="form-control" runat="server"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars" TargetControlID="txt_landingprice" ValidChars="01234567890."></cc1:FilteredTextBoxExtender>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="txt_landingprice" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Short Description </label>
                        <asp:TextBox ID="txtProductShortDescription" Class="form-control"  TextMode="MultiLine" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RFVtxtProductShortDescription" runat="server" Display="Dynamic" ControlToValidate="txtProductShortDescription" CssClass="error" ErrorMessage="Required Field" ValidationGroup="p1"></asp:RequiredFieldValidator>

                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Long Description</label>
                        <asp:TextBox ID="txtProductDescription" Class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox></td>
               
                    </div>



                    <div class="form-group">
                        <label for="exampleInputFile">Image</label>
                        <table>
                            <tr>
                                <td>
                                    <asp:FileUpload ID="fpProduct" runat="server" />
                                </td>
                                <td>
                                    <asp:Image ID="imgProduct" Visible="false" Width="75px" Height="50px" runat="server" />
                                </td>
                                <td>&nbsp;&nbsp;&nbsp;<asp:Button ID="btnRemove" runat="server" Visible="false" Text="X" CssClass="btn btn-danger" CausesValidation="false" OnClick="btnRemove_Click" />
                                    &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnImageUpload" runat="server" Text="Upload" CssClass="btn btn-info" OnClick="btnImageUpload_Click" OnClientClick="return checkFileExtension()" />
                                </td>
                            </tr>
                        </table>
                    </div>


                    <div class="form-group">
                        <label for="exampleInputPassword1">YouTube Video 1</label>
                        <asp:TextBox ID="txtYouTubeVideo1" Class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">YouTube Video Name 1 </label>
                        <asp:TextBox ID="txtYoutubeName1" Class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">YouTube Video 2</label>
                        <asp:TextBox ID="txtYouTubeVideo2" Class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">YouTube Video Name 2</label>
                        <asp:TextBox ID="txtYoutubeName2" Class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">YouTube Video 3</label>
                        <asp:TextBox ID="txtYouTubeVideo3" Class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">YouTube Video Name 3</label>
                        <asp:TextBox ID="txtYoutubeName3" Class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">YouTube Video 4</label>
                        <asp:TextBox ID="txtYouTubeVideo4" Class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">YouTube Video Name 4</label>
                        <asp:TextBox ID="txtYoutubeName4" Class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="box-footer">
                        <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="p1" Text="Save" class="btn btn-primary" OnClick="btnSave_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-primary" Text="Cancel" OnClick="btnCancel_Click" />


                    </div>
                </div>

            </div>
        </div>
        <!--/.col (left) -->
        <!-- right column -->

        <!--/.col (right) -->
    </div>
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
    <script type="text/javascript">
        function checkFileExtension() {
            var result = false;
            var _validFileExtensions = [".jpg", ".jpeg", ".bmp", ".gif", ".png"];
            //if (($("#ctl00_ContentPlaceHolder1_fpProduct").val() == "") || ($("#ctl00_ContentPlaceHolder1_fpProduct").val() == null)) {
            if ((document.getElementById("fpProduct").val() == "") || (document.getElementById("fpProduct").val() == null)) {
                    alert("Please Upload Image.")
                result = false;
            }
            else {
                var allowedFiles = [".jpg", ".jpeg", ".bmp", ".gif", ".png"];
                //var fileUpload = document.getElementById("ctl00_ContentPlaceHolder1_fpProduct");
                var fileUpload = document.getElementById("fpProduct");
                var regex = new RegExp("([a-zA-Z0-9\s_\\.\-:])+(" + allowedFiles.join('|') + ")$");
                if (!regex.test(fileUpload.value.toLowerCase())) {
                    alert("Please upload files having extensions:" + allowedFiles.join(', ') + " only.");
                    result = false;
                }
                else {
                    result = true;
                }
            }

            return result;
        }
    </script>
</asp:Content>

