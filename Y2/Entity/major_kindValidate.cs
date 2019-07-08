using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public  class major_kindValidate
    {

        public short mfk_id { get; set; }
        public string major_kind_id { get; set; }
        [Required(ErrorMessage = "职分类位名称不能为空")]
        public string major_kind_name { get; set; }
    }
}
