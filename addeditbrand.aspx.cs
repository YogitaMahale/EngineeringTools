using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class addeditbrand : System.Web.UI.Page
{
    SqlConnection ConnectionString = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["cnstring"].ToString());
    common ocommon = new common();
    private void BindTypeList()
    {
        DataTable dt = (new Cls_category_b().LoadTypesForBrand());
        if (dt != null)
        {
            ddlTypeList.DataTextField = "typename";
            ddlTypeList.DataValueField = "id";
            ddlTypeList.DataSource = dt;
            ddlTypeList.DataBind();
            ListItem objListItem = new ListItem("-- Select --", "0");
            ddlTypeList.Items.Insert(0, objListItem);
        }
        else
        {
            ddlTypeList.DataSource = null;
            ddlTypeList.DataBind();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindTypeList();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            if (Request.QueryString["id"] != null)
            {

                BindCompany(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                //    BindBank();
                btnSave.Text = "UPDATE";
                hPageTitle.InnerText = "Update Brand";
                Page.Title = "Update Brand";
            }
            else
            {

                hPageTitle.InnerText = "New Brand";
                Page.Title = "New Brand";
                btnSave.Text = "ADD";
            }
        }
    }

    private void Clear()
    {
        txtBrandName.Text = string.Empty;
        //txtCompanyShortDescription.Text = string.Empty;
        //txtCompanyLongDescription.Text = string.Empty;
        //imgProduct.Visible = false;
        //ViewState["fileName"] = null;
        //btnImageUpload.Visible = true;
        //btnRemove.Visible = false;
    }

    public void BindCompany(Int64 CompanyId)
    {
        Brand objcompany = (new Cls_brand_b().SelectById(CompanyId));
        if (objcompany != null)
        {
            txtBrandName.Text = objcompany.brandname;
            ddlTypeList.SelectedValue = objcompany.Fk_typeId.ToString();



        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        Brand objcompany = new Brand();
        objcompany.brandname = txtBrandName.Text.Trim();
        objcompany.Fk_typeId = Convert.ToInt64(ddlTypeList.SelectedValue.ToString());

        if (Request.QueryString["id"] != null)
        {
            objcompany.id = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            Result = (new Cls_brand_b().Update(objcompany));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/manageBrand.aspx?mode=u"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Brand Not Updated";
                BindCompany(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            }
        }
        else
        {
            Result = (new Cls_brand_b().Insert(objcompany));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/manageBrand.aspx?mode=i"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Brand Not Inserted";

            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/manageBrand.aspx"));
    }
}