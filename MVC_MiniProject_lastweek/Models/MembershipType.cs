﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_MiniProject_lastweek.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Type { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths{ get; set; }
        public byte DiscountRate{ get; set; }
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;


    }
}