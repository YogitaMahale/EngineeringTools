using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
public class Cls_Type_b
{
	public Cls_Type_b()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Public Methods
    public DataTable SelectAllAdmin()
    {
        DataTable dt = new DataTable();
        try
        {
            Cls_Type_db objCls_Type_db = new Cls_Type_db();
            dt = objCls_Type_db.SelectAllAdmin();
            return dt;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return dt;
        }
    }
    public DataTable SelectAll()
    {
        DataTable dt = new DataTable();
        try
        {
            Cls_Type_db objCls_Type_db = new Cls_Type_db();
            dt = objCls_Type_db.SelectAll();
            return dt;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return dt;
        }
    }
    //public DataTable category_WSSelectAll()
    //{
    //    DataTable dt = new DataTable();
    //    try
    //    {
    //        Cls_category_db objCls_category_db = new Cls_category_db();
    //        dt = objCls_category_db.category_WSSelectAll();
    //        return dt;
    //    }
    //    catch (Exception ex)
    //    {
    //        ErrHandler.writeError(ex.Message, ex.StackTrace);
    //        return dt;
    //    }
    //}
    public TypeMaster SelectById(Int64 cid)
    {
        TypeMaster objTypeMaster = new TypeMaster();
        try
        {
            Cls_Type_db objCls_Type_db = new Cls_Type_db();
            objTypeMaster = objCls_Type_db.SelectById(cid);
            return objTypeMaster;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return objTypeMaster;
        }
    }
    //public DataTable category_WSSelectById(Int64 cid)
    //{
    //    DataTable dt = new DataTable();
    //    try
    //    {
    //        Cls_Type_db objCls_Type_db = new Cls_Type_db();
    //        dt = objCls_Type_db.category_WSSelectById(cid);
    //        return dt;
    //    }
    //    catch (Exception ex)
    //    {
    //        ErrHandler.writeError(ex.Message, ex.StackTrace);
    //        return dt;
    //    }
    //}
    public Int64 Insert(TypeMaster objTypeMaster)
    {
        Int64 result = 0;
        try
        {
            Cls_Type_db objCls_Type_db = new Cls_Type_db();
            result = Convert.ToInt64(objCls_Type_db.Insert(objTypeMaster));
            return result;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return result;
        }
    }
    public Int64 Update(TypeMaster objTypeMaster)
    {
        Int64 result = 0;
        try
        {
            Cls_Type_db objCls_Type_db = new Cls_Type_db();
            result = Convert.ToInt64(objCls_Type_db.Update(objTypeMaster));
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
        bool result = false;
        try
        {
            Cls_Type_db objCls_Type_db = new Cls_Type_db();
            if (objCls_Type_db.Delete(cid))
            {
                result = true;
            }
            else
            {
                result = false;
            }
        }
        catch (Exception ex)
        {
            result = false;
            ErrHandler.writeError(ex.Message, ex.StackTrace);
        }
        return result;
    }
    public bool Category_IsActive(Int64 CategoryId, Boolean IsActive)
    {
        try
        {
            Cls_Type_db objCls_Type_db = new Cls_Type_db();
            if (objCls_Type_db.Category_IsActive(CategoryId, IsActive))
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

    #endregion


}
public class TypeMaster
{
    public TypeMaster()
    { }

    #region Private Variables
    private Int64 _id;
    private String _typename;
    private String _imagename;
    private Decimal _actualprice;
    private Decimal _discountprice;
    private String _shortdesc;
    private String _longdescp;
    private Boolean _isdelete;
    private System.DateTime _createddate;
    private System.DateTime _modifieddate;
    private String _field1;
    private String _field2;
    private Int32 _bankid;
    #endregion


    #region Public Properties
    public Int64 id
    {
        get { return _id; }
        set { _id = value; }
    }
    public Int32 bankid
    {
        get { return _bankid; }
        set { _bankid = value; }
    }
    public String typename
    {
        get { return _typename; }
        set { _typename = value; }
    }
    public String imagename
    {
        get { return _imagename; }
        set { _imagename = value; }
    }
    public Decimal actualprice
    {
        get { return _actualprice; }
        set { _actualprice = value; }
    }
    public Decimal discountprice
    {
        get { return _discountprice; }
        set { _discountprice = value; }
    }
    public String shortdesc
    {
        get { return _shortdesc; }
        set { _shortdesc = value; }
    }
    public String longdescp
    {
        get { return _longdescp; }
        set { _longdescp = value; }
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
    public String field1
    {
        get { return _field1; }
        set { _field1 = value; }
    }
    public String field2
    {
        get { return _field2; }
        set { _field2 = value; }
    }
    #endregion
}

}
