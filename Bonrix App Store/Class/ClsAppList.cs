using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bonrix_App_Store.Class
{
    public class ClsAppList
    {
        public string ApkName { get; set; }
        public string DateTime { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Package { get; set; }
        public string Version { get; set; }
        public string ApkPath { get; set; }
    }
    public class GetClsAppList
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<ClsAppList> Data { get; set; }
    }
    public class GridList
    {
        public string ApkName { get; set; }
        public string DateTime { get; set; }
        public string ImageUrl { get; set; }
        public string DownloadUrl { get; set; }
        public string CopyUrl { get; set; }
        public string Name { get; set; }
        public string Package { get; set; }
        public string Version { get; set; }

    }

}