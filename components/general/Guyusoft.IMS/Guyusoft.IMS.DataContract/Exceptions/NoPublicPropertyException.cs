using System;

namespace Guyusoft.IMS.DataContract.Exceptions
{
    public class NoPublicPropertyException : Exception
    {
        public NoPublicPropertyException(string typeName):base(string.Format("No any public property defined in {0}",typeName))
        {

        }
    }
}
