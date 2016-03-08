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
    public partial class 客戶資料
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public 客戶資料()
        {
            this.客戶銀行資訊 = new HashSet<客戶銀行資訊>();
            this.客戶聯絡人 = new HashSet<客戶聯絡人>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "客戶名稱不可超過50個字")]
        public string 客戶名稱 { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = "統一編號不可超過8個字")]
        public string 統一編號 { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "電話號碼不可超過50個字")]
        public string 電話 { get; set; }
        [StringLength(50, ErrorMessage = "傳真號碼不可超過50個字")]
        public string 傳真 { get; set; }
        [StringLength(100, ErrorMessage = "地址不可超過100個字")]
        public string 地址 { get; set; }
        [StringLength(250, ErrorMessage = "Email不可超過250個字")]
        [EmailAddress(ErrorMessage = "這不是一個有效的Email")]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<客戶銀行資訊> 客戶銀行資訊 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<客戶聯絡人> 客戶聯絡人 { get; set; }
    }
}
