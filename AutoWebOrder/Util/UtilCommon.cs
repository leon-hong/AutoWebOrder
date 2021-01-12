using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutoWebOrder.Util
{
    class UtilCommon
    {
        public static bool IsExistFile(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            return fileInfo.Exists;
        }
    }
}
