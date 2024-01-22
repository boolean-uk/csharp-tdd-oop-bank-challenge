using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Enums
{
    public enum Branch
    {
        Yorkshire, Berkshire, Lincolnshire, Worcestershire,
        Shropshire, Oxforshire, Warwickshire, Cambridgeshire, Derbyshire, Gloucestershire,
        Lancashire, Nottinghamshire, Staffordshire, Buckinghamshire, Wiltshire, Bedfordshire,
        Northamptonshire
    }

    public enum OverdraftStatus { Default = 0, Requested = 1, Denied = 2, Accepted = 3 }
}
