//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientManagementHomework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class 客戶銀行資訊
    {
        public int Id { get; set; }
        public int 客戶Id { get; set; }
        [Required]
        public string 銀行名稱 { get; set; }
        [Required]
        [RegularExpression("^/+?[1-9][0-9]*$", ErrorMessage = "銀行代碼限定數字")]
        public int 銀行代碼 { get; set; }
        public Nullable<int> 分行代碼 { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "帳戶名稱不得超過50個字元")]
        public string 帳戶名稱 { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "帳戶號碼不得超過20個字元")]
        public string 帳戶號碼 { get; set; }

        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
