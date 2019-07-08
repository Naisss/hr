using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
public    class public_charValidate
    {

        public short pbc_id { get; set; }
        [Required(ErrorMessage = "小妹妹这里不能为空")]
        public string attribute_kind { get; set; }
        [Required(ErrorMessage = "小弟弟这里不能为空")]
        public string attribute_name { get; set; }
    }
}
