using System;

namespace Boolean.CSharp.Main.Exceptions;

public class NotManagerException: Exception
{
    public NotManagerException()
    {
    }

    public NotManagerException(string message): base(message)
    {
    }
}
