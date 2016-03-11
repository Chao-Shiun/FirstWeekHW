using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ClientManagementHomework.Models
{
    internal class CellPhoneVerificationAttribute : DataTypeAttribute
    {
        public CellPhoneVerificationAttribute() : base(DataType.Text)
        {
        }

        public override bool IsValid(object value)
        {
            var str = value as string;
            Regex reg = new Regex(@"\d{4}-\d{6}", RegexOptions.IgnoreCase);
            bool result = reg.IsMatch(str);
            return result;
        }
    }
}