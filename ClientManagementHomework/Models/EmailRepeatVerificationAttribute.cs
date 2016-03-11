using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ClientManagementHomework.Models
{
    internal class EmailRepeatVerificationAttribute : DataTypeAttribute
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        public EmailRepeatVerificationAttribute() : base(DataType.Text)
        {
        }

        public override bool IsValid(object value)
        {
            string Email = value as string;
            var 聯絡人 = db.客戶聯絡人.ToList().AsQueryable().Where(x => x.Email.Equals(Email) && x.已刪除.Equals(false));

            //var result = db.客戶聯絡人.SqlQuery("select Email from where Email=@Email", Email);

            return 聯絡人.FirstOrDefault() == null ? true : false;

            //private 客戶資料Entities db = new 客戶資料Entities();
            //為什麼這樣寫會有錯誤?
        }
    }
}