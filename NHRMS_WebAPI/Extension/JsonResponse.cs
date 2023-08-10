
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
/// <summary>
/// Summary description for JsonResponse
/// </summary>
/// 
public class data
{
//    private bool _IsSucess = false;

//    public bool IsSucess
//    {
//        get { return _IsSucess; }
//        set { _IsSucess = value; }
//    }

//    private string _Message = string.Empty;

//    public string Message
//    {
//        get { return _Message; }
//        set { _Message = value; }
//    }
    private object _ResponseDataC = null;

    public object ResponseDataC
    {
        get { return _ResponseDataC; }
        set { _ResponseDataC = value; }
    }

    public data GetResponsePost<T>(T obj, string msg)
    {
        data result = new data();
        try
        {
            if (obj != null)
            {
                //result.IsSucess = true;
                //result.Message = "success";
                result.ResponseDataC = obj;
            }
            else
            {
                //result.IsSucess = false;
                //result.Message = msg;
                result.ResponseDataC = null;
            }
        }
        catch (Exception ex)
        {
            //result.IsSucess = false;
            //result.Message = ex.Message;
        }
        return result;
    }
    public data GetResponseData<T>(IEnumerable<T> obj)
    {
        data result = new data();
        try
        {
            if (obj != null)
            {
                //if (obj.Count() != 0)
                //{
                //result.IsSucess = true;
                //result.Message = "success";
                result.ResponseDataC = obj;
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
                //result.IsSucess = false;
                //result.Message = "";
                result.ResponseDataC = null;
            }
        }
        catch (Exception ex)
        {
            //result.IsSucess = false;
            //result.Message = ex.Message;
        }
        return result;
    }
}
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

    public output GetResponsePost<T>(T obj, string msg)
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
                result.Message = "An error occured";
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

    public output GetResponseCollection<T>(object[] obj, int size, string[] arrName)
    {
        output result = new output();
        try
        {
            if (obj != null)
            {
                result.IsSucess = true;
                result.Message = "success";
                Dictionary<String, IEnumerable<T>> dic = new Dictionary<String, IEnumerable<T>>();
                IEnumerable<T>[] list = new IEnumerable<T>[size];
                int i = 0;
                foreach (IEnumerable<T> item in obj)
                {
                    dic[arrName[i]] = item;
                    //list[i]=item;
                    i++;
                }
                result.ResponseData = list;
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
