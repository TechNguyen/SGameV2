using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Service.Constant
{
	public static class StatusConstant
	{
		public static string SUCCESS { get; set; } = "SUCCESS";
		public static string ERROR { get; set; } = "ERROR";
        public static string WARNING { get; set; } = "WARNING";


		public static class ApproveConstant
		{
			[DisplayName("Chờ phê duyệt")]
			public static string CHOPHEDUYET { get; set; } = "CHOPHEDUYET";
            [DisplayName("Đã phê duyệt")]
            public static string DAPHEDUYET { get; set; } = "DAPHEDUYET";
            [DisplayName("Đã hủy")]
            public static string DAHUY { get; set; } = "DAHUY";
        }
		public static class ErrorCode
		{
			public static string TOKEN_EXPRIED = "TOKEN_EXPRIED";
			public static string UNAUTHOIZED = "";
		}
    }
}
