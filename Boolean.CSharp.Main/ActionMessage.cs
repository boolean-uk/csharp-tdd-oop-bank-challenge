using System;
using System.Dynamic;

namespace Boolean.CSharp.Main;

public class ActionMessage
{
    public bool Success{get; set;}
    public decimal ReturnValue{get; set;}
    public string Message{get;set;}

    public ActionMessage(bool success, decimal returnV, string msg)
    {
        Success = success;
        ReturnValue = returnV;
        Message = msg;
    }
}
