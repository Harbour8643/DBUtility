using System;
using System.Configuration;
namespace Maticsoft.DBUtility
{
    /// <summary>
    /// 公共常量
    /// </summary>
    public class PubConstant
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return GetConnectionString("ConnectionString");
            }
        }

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。(AppSettings: ConStringEncrypt,true 加密)
        /// </summary>
        /// <param name="configName">连接字符串名</param>
        /// <returns>数据库连接字符串</returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.AppSettings[configName];
            string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
            if (ConStringEncrypt == "true")
            {
                connectionString = DESEncrypt.Decrypt(connectionString);
            }
            return connectionString;
        }
    }
}
