using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
public class Cls_brand_b
{
	public Cls_brand_b()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Public Methods
    public DataTable SelectAll(Int64 typeId)
    {
        DataTable dt = new DataTable();
        try
        {
            Cls_brand_db objCls_company_db = new Cls_brand_db();
            dt = objCls_company_db.SelectAll(typeId);
            return dt;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return dt;
        }
    }
    //public DataTable SelectAllAdmin()
    //{
    //    DataTable dt = new DataTable();
    //    try
    //    {
    //        Cls_company_db objCls_company_db = new Cls_company_db();
    //        dt = objCls_company_db.SelectAllAdmin();
    //        return dt;
    //    }
    //    catch (Exception ex)
    //    {
    //        ErrHandler.writeError(ex.Message, ex.StackTrace);
    //        return dt;
    //    }
    //}
    public Brand SelectById(Int64 cid)
    {
        Brand objcompany = new Brand();
        try
        {
            Cls_brand_db objCls_company_db = new Cls_brand_db();

            objcompany = objCls_company_db.SelectById(cid);
            return objcompany;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return objcompany;
        }
    }
    public Int64 Insert(Brand objcompany)
    {
        Int64 result = 0;
        try
        {
            Cls_brand_db objCls_company_db = new Cls_brand_db();

            result = Convert.ToInt64(objCls_company_db.Insert(objcompany));
            return result;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return result;
        }
    }
    public Int64 Update(Brand objcompany)
    {
        Int64 result = 0;
        try
        {
            Cls_brand_db objCls_company_db = new Cls_brand_db();

            result = Convert.ToInt64(objCls_company_db.Update(objcompany));
            return result;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return result;
        }
    }
    public bool Delete(Int64 cid)
    {
        try
        {
            Cls_brand_db objCls_company_db = new Cls_brand_db();

            if (objCls_company_db.Delete(cid))
            {
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    //public bool Company_IsActive(Int64 CompanyId, Boolean IsActive)
    //{
    //    try
    //    {
    //        Cls_company_db objCls_category_db = new Cls_company_db();
    //        if (objCls_category_db.Company_IsActive(CompanyId, IsActive))
    //        {
    //            return true;
    //        }
    //        return false;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //}

    #endregion

}
public class Brand
{
    public Brand()
    { }

    #region Private Variables
    private Int64 _id;
    private string _brandname;
    private Boolean _isactive;
    private Boolean _isdelete;
    private System.DateTime _createddate;
    private System.DateTime _modifieddate;
    private Int64 _Fk_typeId;
    
    #endregion


    #region Public Properties
    public Int64 id
    {
        get { return _id; }
        set { _id = value; }
    }
    public String brandname
    {
        get { return _brandname; }
        set { _brandname = value; }
    }

    public Boolean isactive
    {
        get { return _isactive; }
        set { _isactive = value; }
    }
    public Boolean isdelete
    {
        get { return _isdelete; }
        set { _isdelete = value; }
    }
    public System.DateTime createddate
    {
        get { return _createddate; }
        set { _createddate = value; }
    }
    public System.DateTime modifieddate
    {
        get { return _modifieddate; }
        set { _modifieddate = value; }
    }
    public Int64 Fk_typeId
    {
        get { return _Fk_typeId; }
        set { _Fk_typeId = value; }
    }
    
    #endregion
}

}
