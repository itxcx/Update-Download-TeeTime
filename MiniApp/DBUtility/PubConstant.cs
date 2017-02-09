namespace MiniApp.DBUtility
{
    
    public class PubConstant
    {        
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {           
            get
            {
                string _connectionString = "server=192.168.0.247;database=GolfClub_XM;uid=sa;pwd=mujker";
                return _connectionString; 
            }
        }

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = "server=192.168.0.247;database=GolfClub_XM;uid=sa;pwd=mujker";
            return connectionString;
        }


    }
}
