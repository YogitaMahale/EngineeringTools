﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
public partial class addeditType : System.Web.UI.Page
{
    int categoryImageFrontWidth = 500;
    int categoryImageFrontHeight = 605;
    string categoryMainPath = "~/uploads/type/";
    string categoryFrontPath = "~/uploads/type/front/";
    common ocommon = new common();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //BindBank();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            if (Request.QueryString["id"] != null)
            {
                BindCategory(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                btnSave.Text = "Update";
                hPageTitle.InnerText = "Type Update";
                Page.Title = "Type Update";
            }
            else
            {
                hPageTitle.InnerText = "Type Add";
                Page.Title = "Type Add";
                btnSave.Text = "Add";
                txtCategoryDiscount.Text = "0";
                txtActualPrice.Text = "0";
            }
        }
    }

    private void Clear()
    {
        txtCategoryName.Text = string.Empty;
        txtActualPrice.Text = string.Empty;
        txtCategoryDiscount.Text = string.Empty;
        txtCategoryShortDescription.Text = string.Empty;
        txtCategoryLongDescription.Text = string.Empty;
        btnImageUpload.Visible = true;
        btnRemove.Visible = false;
        imgCategory.Visible = false;
        ViewState["fileName"] = null;
    }

    //private void BindBank()
    //{
    //    DataTable dtBank = (new Cls_bankmaster_b().SelectAll());
    //    if (dtBank != null)
    //    {
    //        if (dtBank.Rows.Count > 0)
    //        {
    //            ddlBank.DataSource = dtBank;
    //            ddlBank.DataTextField = "bankname";
    //            ddlBank.DataValueField = "bankid";
    //            ddlBank.DataBind();
    //            ListItem objListItem = new ListItem("--Select Bank--", "0");
    //            ddlBank.Items.Insert(0, objListItem);
    //        }
    //    }
    //}

    public void BindCategory(Int64 CategoryId)
    {
        TypeMaster  objcategory = (new Cls_Type_b().SelectById(CategoryId));
        if (objcategory != null)
        {
            //ddlBank.SelectedValue = objcategory.bankid.ToString();
            txtCategoryName.Text = objcategory.typename;
            txtCategoryShortDescription.Text = objcategory.shortdesc;
            txtCategoryLongDescription.Text = objcategory.longdescp;
            if (!string.IsNullOrEmpty(objcategory.imagename))
            {
                imgCategory.Visible = true;
                ViewState["fileName"] = objcategory.imagename;
                imgCategory.ImageUrl = categoryFrontPath + objcategory.imagename;
                btnImageUpload.Visible = false;
                btnRemove.Visible = true;
            }
            else
            {
                btnImageUpload.Visible = true;
            }
        }
    }

    protected override void Render(HtmlTextWriter writer)
    {
        string validatorOverrideScripts = "<script src=\"" + Page.ResolveUrl("~") + "js/validators.js\" type=\"text/javascript\"></script>";
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ValidatorOverrideScripts", validatorOverrideScripts, false);
        base.Render(writer);
    }

    protected void btnImageUpload_Click(object sender, EventArgs e)
    {
        if (fpCategory.HasFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(fpCategory.FileName.Replace(' ', '_')) + DateTime.Now.Ticks.ToString() + Path.GetExtension(fpCategory.FileName);
            fpCategory.SaveAs(MapPath(categoryMainPath + fileName));
            ocommon.CreateThumbnail1("uploads\\type\\", categoryImageFrontWidth, categoryImageFrontHeight, "~/Uploads/type/front/", fileName);
            imgCategory.Visible = true;
            imgCategory.ImageUrl = categoryFrontPath + fileName;
            ViewState["fileName"] = fileName;
            btnRemove.Visible = true;
            btnImageUpload.Visible = false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        TypeMaster objcategory = new TypeMaster();
        objcategory.typename = txtCategoryName.Text.Trim();
        objcategory.actualprice = 0;
        objcategory.discountprice = 0;
        objcategory.shortdesc = txtCategoryShortDescription.Text.Trim();
        objcategory.longdescp = txtCategoryLongDescription.Text.Trim();
        //objcategory.bankid = Convert.ToInt32(ddlBank.SelectedValue);
        if (ViewState["fileName"] != null)
        {
            objcategory.imagename = ViewState["fileName"].ToString();
        }
        if (Request.QueryString["id"] != null)
        {
            objcategory.id = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            Result = (new Cls_Type_b ().Update(objcategory));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/manageType.aspx?mode=u"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Type Not Updated";
                BindCategory(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            }
        }
        else
        {
            Result = (new Cls_Type_b ().Insert(objcategory));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/manageType.aspx?mode=i"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Type Not Inserted";

            }
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        var filePath = Server.MapPath("~/uploads/type/" + ViewState["fileName"].ToString());
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        var filePath1 = Server.MapPath("~/uploads/type/front/" + ViewState["fileName"].ToString());
        if (File.Exists(filePath1))
        {
            File.Delete(filePath1);
        }

        btnImageUpload.Visible = true;
        btnRemove.Visible = false;
        ViewState["fileName"] = string.Empty;
        imgCategory.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/manageType.aspx"));
    }
}