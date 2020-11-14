using System;
using System.Collections.Generic;
using System.Text;

namespace API.PDD.Model
{
    public class PDDCat
    {
        /// <summary>
        /// 类目层级，1-一级类目，2-二级类目，3-三级类目，4-四级类目
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// 商品类目名称
        /// </summary>
        public string cat_name { get; set; }
        /// <summary>
        /// id所属父类目ID，其中，parent_id=0时为顶级节点
        /// </summary>
        public long parent_cat_id { get; set; }
        /// <summary>
        /// 商品类目ID
        /// </summary>
        public long cat_id { get; set; }
    }
}
