using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpeekTestTask.Models
{
    public class Disc
    {
        public string DiscName { get; set; } // name of the disc

        //Get list of all discs on a current computer
        public IEnumerable<Disc> findAll()
        {
            string[] Drives = Environment.GetLogicalDrives();
            Disc[] d = new Disc[Drives.Count()];

            int i = 0;
            foreach (string s in Drives)
            {
                d[i++] = new Disc { DiscName = s };
            }

            return d;
        }
    }
}