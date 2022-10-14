using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Globalization;
using System.Data.SqlClient;
using System.Data.Common;
namespace Assignment2.Models
{
    public class DrugsBookingListViewModel
    {
        public String DrugName {get;set;}
        public int Stock { get;set;}
        public String FacilityName { get;set;}
        public float Distance { get;set;}
    }

}