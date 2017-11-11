using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG.Azure.Data
{
    /// <summary>
    /// Base class for any datasource related activities
    /// </summary>
    public class DBAccessBase
    {
        protected void LogAndThrowApplicationException(string message, Exception ex)
        {
            //Logging implementation
        }
    }
}
