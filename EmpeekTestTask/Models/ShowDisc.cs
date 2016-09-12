using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpeekTestTask.Models
{
    public class ShowDisc
    {
        public bool Status { get; set; }        // Showing stsatus

        //Show or not show list of discs
        public ShowDisc findStatus(bool status)
        {
            ShowDisc sd = new ShowDisc { Status = status };

            return sd;
        }
    }
}