
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
/// <summary>
/// Summary description for JsonResponse
/// </summary>
public class output
{
    private bool _IsSucess = false;

    public bool IsSucess
    {
        get { return _IsSucess; }
        set { _IsSucess = value; }
    }

    private string _Message = string.Empty;

    public string Message
    {
        get { return _Message; }
        set { _Message = value; }
    }

    private object _ResponseData = null;

    public object ResponseData
    {
        get { return _ResponseData; }
        set { _ResponseData = value; }
    }

    private string _CallBack = string.Empty;

    public string CallBack
    {
        get { return _CallBack; }
        set { _CallBack = value; }
    }

    public output GetResponsePost<T>(T obj,string msg)
    {
        output result = new output();
        try
        {
            if (obj != null)
            {
                result.IsSucess = true;
                result.Message = "success";
                result.ResponseData = obj;
            }
            else
            {
                result.IsSucess = false;
                result.Message = msg;
                result.ResponseData = null;
            }
        }
        catch (Exception ex)
        {
            result.IsSucess = false;
            result.Message = ex.Message;
        }
        return result;
    }
    public output GetResponse<T>(IEnumerable<T> obj)
    {
        output result = new output();
        try
        {
            if (obj != null)
            {
                //if (obj.Count() != 0)
                //{
                    result.IsSucess = true;
                    result.Message = "success";
                    result.ResponseData = obj;
                //}
                /*else
                {
                    result.IsSucess = false;
                    result.Message = "";
                    result.ResponseData = null;
                }*/
            }
            else
            {
                result.IsSucess = false;
                result.Message = "";
                result.ResponseData = null;
            }
        }
        catch (Exception ex)
        {
            result.IsSucess = false;
            result.Message = ex.Message;
        }
        return result;
    }
}
