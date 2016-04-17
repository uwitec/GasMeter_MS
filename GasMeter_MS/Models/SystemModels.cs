using System;
using System.ComponentModel.DataAnnotations;

namespace GasMeter_MS.Models
{
    //
    //系统信息表
    public class SysInfo
    {
        [Required]
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "站点名称")]
        [StringLength(20, ErrorMessage = "{0} 最多包含 20 个字符。")]
        public string SiteName { get; set; }

        [Display(Name = "读写气卡操作的端口号")]
        public int Port { get; set; }

        [Display(Name = "比特率")]
        public int Baud { get; set; }

        [Display(Name = " 备注")]
        public string Memo { get; set; }
    }

    //
    //选项初始化表
    public class KeyValue
    {
        [Required]
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "选项名（价格类型、用户状态等）")]
        [StringLength(20, ErrorMessage = "{0} 最多包含 20 个字符。")]
        public string Key { get; set; }

        [StringLength(20, ErrorMessage = "{0} 最多包含 20 个字符。")]
        [Display(Name = "可选项")]
        public string Value { get; set; }

        [Display(Name = "备注")]
        public string BMemo{ get; set; }
    }

    //
    //主菜单配置表
    public class Menu
    {
        [Required]
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} 最多包含 20 个字符。")]
        [Display(Name = "菜单名")]
        public string MenuName { get; set; }

        [StringLength(50, ErrorMessage = "{0} 最多包含 50 个字符。")]
        [Display(Name = "对应的页面 ")]
        public string URL { get; set; }

        [StringLength(10, ErrorMessage = "{0} 最多包含 10 个字符。")]
        [Display(Name = "页面对应的 tab 标识  ")]
        public string Rel { get; set; }

        [Display(Name = "是否只刷新页面一次 ")]
        public bool Fresh { get; set; }

        [Display(Name = "是否以框架形式加载页面  ")]
        public bool External { get; set; }
    }
}