using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EmpeekTestTask.Models
{
    public class RealPath
    {
        public string LastName { get; set; }        // prev path
        public string PathName { get; set; }        // this path
        public int SmallFiles { get; set; }         // number of small files in a directory
        public int MiddleFiles { get; set; }        // ...middle
        public int HardFiles { get; set; }          // ...hard
        public string ErrorStatus { get; set; }     // error message
        public bool ShowDisc { get; set; }          // show or not show discs
        public int Direct { get; set; }             // go foward or come back in file system (1 or 0)

        // Get current path
        public RealPath findPath(string currentPath, int dir)
        {

            RealPath p = new RealPath { PathName = currentPath, SmallFiles = 0, MiddleFiles = 0, HardFiles = 0, ErrorStatus = "No Errors", LastName = "", ShowDisc = true, Direct = dir };

            DirectoryInfo directory = new DirectoryInfo(currentPath);

            var index = currentPath.LastIndexOf('\\');

            string lastPath = "";

            for (int i = 0; i < index; i++)
            {
                lastPath += currentPath[i];
            }

            index = lastPath.LastIndexOf('\\');
            if (index == -1)
            {
                lastPath += '\\';
            }

            if (currentPath == lastPath && p.Direct == 0)
            {
                p.ShowDisc = true;
            }
            else
            {
                p.ShowDisc = false;
            }

            p.LastName = lastPath;

            try
            {
                var files = directory.GetFiles("*.*", SearchOption.AllDirectories);

                foreach (var d in files)
                {
                    if (d.Length / 1024 / 1024 <= 10) p.SmallFiles++;
                    if (d.Length / 1024 / 1024 > 10 && d.Length / 1024 / 1024 <= 50) p.MiddleFiles++;
                    if (d.Length / 1024 / 1024 >= 100) p.HardFiles++;
                }
            }
            catch (Exception ex)
            {
                p.ErrorStatus = "Access limitation! Protected files in a directory";
            }

            return p;
        }
    }
}