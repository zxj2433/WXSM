using System;
using System.Collections.Generic;
using System.Text;

namespace API.PDD.Model
{
    public class PDDGoodSpec
    {
        public long cat_id { get; set; }
        public long parent_spec_id { get; set; }
        public string parent_spec_name { get; set; }
    }
}
