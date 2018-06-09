using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo.RegSvrEnum;

namespace InternalsViewer.Ui.TestApp.Helpers
{
    public class ConnectionStringHelper
    {
        /// <summary>
        /// Creates a SqlConnectionInfo object from a UIConnectionInfo object
        /// </summary>
        /// <param name="connectionInfo">The connection info.</param>
        /// <returns></returns>
        public static SqlConnectionInfo CreateSqlConnectionInfo(UIConnectionInfo connectionInfo)
        {
            var sqlConnInfo = new SqlConnectionInfo();

            sqlConnInfo.ServerName = connectionInfo.ServerName;
            sqlConnInfo.UserName = connectionInfo.UserName;

            if (string.IsNullOrEmpty(connectionInfo.Password))
            {
                sqlConnInfo.UseIntegratedSecurity = true;
            }
            else
            {
                sqlConnInfo.Password = connectionInfo.Password;
            }

            return sqlConnInfo;
        }
    }
}
