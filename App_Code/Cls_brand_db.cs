using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
public class Cls_brand_db
{
      SqlConnection ConnectionString = new SqlConnection();

	public Cls_brand_db()
	{
        string name = string.Empty;
            string conname = string.Empty;
            ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
            if (connections.Count != 0)
            {
                foreach (ConnectionStringSettings connection in connections)
                {
                    name = connection.Name;
                }
                conname = "" + name + "";
            }
            ConnectionString.ConnectionString = ConfigurationManager.ConnectionStrings[conname].ConnectionString;
     
	}

    #region Public Methods
    public DataTable SelectAll(Int64 typeId)
    {
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "tbl_brand_SelectAll";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = ConnectionString;
            cmd.Parameters.AddWithValue("@Fk_typeId",typeId);
            ConnectionString.Open();
            da = new SqlDataAdapter(cmd); 
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return null;
        }
        finally
        {
            ConnectionString.Close();
        }
        return ds.Tables[0];
    }

    //public DataTable SelectAllAdmin()
    //{
    //    DataSet ds = new DataSet();
    //    SqlDataAdapter da;
    //    try
    //    {
    //        SqlCommand cmd = new SqlCommand();
    //        cmd.CommandText = "company_SelectAllAdmin";
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Connection = ConnectionString;
    //        ConnectionString.Open();
    //        da = new SqlDataAdapter(cmd);
    //        da.Fill(ds);
    //    }
    //    catch (Exception ex)
    //    {
    //        ErrHandler.writeError(ex.Message, ex.StackTrace);
    //        return null;
    //    }
    //    finally
    //    {
    //        ConnectionString.Close();
    //    }
    //    return ds.Tables[0];
    //}

    public Brand SelectById(Int64 cid)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        Brand objcompany = new Brand();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "tbl_brand_SelectById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = ConnectionString;
            cmd.Parameters.AddWithValue("@id", cid);
            ConnectionString.Open();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0] != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            {
                                objcompany.id = Convert.ToInt64(ds.Tables[0].Rows[0]["id"]);
                                objcompany.brandname = Convert.ToString(ds.Tables[0].Rows[0]["brandname"]);
                                objcompany.Fk_typeId = Convert.ToInt64(ds.Tables[0].Rows[0]["Fk_typeId"]);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return null;
        }
        finally
        {
            ConnectionString.Close();
        }
        return objcompany;
    }
    public Int64 Insert(Brand objcompany)
    {
        Int64 result = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "tbl_brand_Insert";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = ConnectionString;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@id";
            param.Value = objcompany.id;
            param.SqlDbType = SqlDbType.BigInt;
            param.Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add(param);
            cmd.Parameters.AddWithValue("@brandname", objcompany.brandname);
            cmd.Parameters.AddWithValue("@Fk_typeId", objcompany.Fk_typeId);
            
            ConnectionString.Open();
            cmd.ExecuteNonQuery();
            result = Convert.ToInt64(param.Value);
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return result;
        }
        finally
        {
            ConnectionString.Close();
        }
        return result;
    }
    public Int64 Update(Brand  objcompany)
    {
        Int64 result = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "tbl_brand_Update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = ConnectionString;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@id";
            param.Value = objcompany.id;
            param.SqlDbType = SqlDbType.BigInt;
            param.Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add(param);
            cmd.Parameters.AddWithValue("@brandname", objcompany.brandname);
            cmd.Parameters.AddWithValue("@Fk_typeId", objcompany.Fk_typeId);
            
	 



            ConnectionString.Open();
            cmd.ExecuteNonQuery();
            result = Convert.ToInt64(param.Value);
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return result;
        }
        finally
        {
            ConnectionString.Close();
        }
        return result;
    }
    public bool Delete(Int64 cid)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "tbl_brand_Delete";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = ConnectionString;

            cmd.Parameters.AddWithValue("@id", cid);

            ConnectionString.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return false;
        }
        finally
        {
            ConnectionString.Close();
        }
        return true;
    }

    //public bool Company_IsActive(Int64 CompanyId, Boolean IsActive)
    //{
    //    try
    //    {
    //        SqlCommand cmd = new SqlCommand();
    //        cmd.CommandText = "company_IsActive";
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Connection = ConnectionString;
    //        cmd.Parameters.AddWithValue("@cid", CompanyId);
    //        cmd.Parameters.AddWithValue("@isactive", IsActive);
    //        ConnectionString.Open();
    //        cmd.ExecuteNonQuery();
    //    }
    //    catch (Exception)
    //    {
    //        return false;
    //    }
    //    finally
    //    {
    //        ConnectionString.Close();
    //    }
    //    return true;
    //}


    #endregion

}

}
