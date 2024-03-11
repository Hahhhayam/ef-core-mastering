using System;
using System.Collections.Generic;

namespace ef_core_mastering.DTOs
{
    public class ProfileDTO
    {
        public string Nickname { get; set; }
        public string CountyName { get; set; }
        public string Flag { get; set; }

        public override string ToString()
        {
            return $"{Nickname} - {CountyName}{Flag}";
        }
    }
}
