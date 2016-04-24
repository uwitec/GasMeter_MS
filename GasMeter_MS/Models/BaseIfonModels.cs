using System.ComponentModel.DataAnnotations;
using System;
using GasMeter_MS.Models;
namespace GasMeter_MS.Models
{
    //
    //气价信息表
    public class Price
    {
        [Required]
        [Key]
        [Display(Name = "价格类型号")]
        public int Id { get; set; }

        [Display(Name = "价格类型名")]
        [StringLength(20, ErrorMessage = "{0} 最多包含 20 个字符。")]
        [Required(ErrorMessage = "请输入{0}")]
        public string PName { get; set; }

        [Required(ErrorMessage = "请输入{0}")]
        [Display(Name = "单价")]
        public float SinPrice { get; set; }

        [Display(Name = "价格说明")]
        public string Describe { get; set; }

        [Display(Name = " 启用日期")]
        public DateTime StartDateTime { get; set; }


        [Display(Name = " 更新时间")]
        public DateTime UpdateDateTime { get; set; }

        [Display(Name = " 操作人")]
        public string HandlerBy { get; set; }

        [Display(Name = "备注")]
        public string Memo { get; set; }
    }
}