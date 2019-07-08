using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public  class second_kindValidate
    {
        public short fsk_id { get; set; }
        public string first_kind_id { get; set; }
        public string first_kind_name { get; set; }

        public string second_kind_id { get; set; }
        [Required(ErrorMessage = "二级机构名称不能为空")]
        public string second_kind_name { get; set; }
        [Required(ErrorMessage = "薪酬发放责任人编号不能为空")]
        public string second_salary_id { get; set; }
        [Required(ErrorMessage = "销售责任人编号不能为空")]
        public string second_sale_id { get; set; }
    }
}
