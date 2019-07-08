using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public  class first_kindValidate
    {
        public short ffk_id { get; set; }
        public string first_kind_id { get; set; }
        [Required(ErrorMessage = "机构名称不能为空")]
        public string first_kind_name { get; set; }
        [Required(ErrorMessage = "一级机构薪酬发放责任人编号不能为空")]
        public string first_kind_salary_id { get; set; }
        [Required(ErrorMessage = "一级机构销售责任人编号不能为空")]
        public string first_kind_sale_id { get; set; }

    }
}
