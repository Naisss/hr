using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
 public   class config_majorValidate
    {
        public short mak_id { get; set; }
        public string major_kind_id { get; set; }
      
        public string major_kind_name { get; set; }
        public string major_id { get; set; }
        [Required(ErrorMessage = "职位名称不能为空")]
        public string major_name { get; set; }
        public Nullable<short> test_amount { get; set; }
    }
}
