using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment10.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Bowler> Bowler { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string Team { get; set; }
    }
}
