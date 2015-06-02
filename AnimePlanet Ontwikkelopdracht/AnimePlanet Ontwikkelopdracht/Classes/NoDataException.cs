using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimePlanet_Ontwikkelopdracht.Classes
{
    public class NoDataException : Exception
    {
        public NoDataException(string message)
            : base(message)
        {

        }
    }
}