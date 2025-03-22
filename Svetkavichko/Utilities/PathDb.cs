using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svetkavichko.Utilities
{
    public class PathDb
    {
        public static string GetPath(string dbName)
        {
            string dbPathSql = string.Empty;

            //if(DeviceInfo.Platform == DevicePlatform.WinUI)
            //{
                string dbPath = FileSystem.AppDataDirectory;
                dbPath = Path.Combine(dbPath, dbName);
            //}

            dbPathSql = dbPath;

            return dbPathSql;
        }
    }
}
