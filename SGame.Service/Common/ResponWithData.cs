using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGame.Service.Constant;

namespace SGame.Service.Common
{
	public class ResponWithData<T>
	{
        public T data { get; set; }
        public int Code { get; set; }
        public string message { get; set; }
        public string Status { get; set; }

        public void SetSucessMess(string message)
        {
            this.message = message;
            this.Code = 200;
            this.Status = StatusConstant.SUCCESS;
        }

        public void SetSucessMessData(string message, T dataSet)
        {
            this.data = dataSet;
            this.Code = 200;
            this.message = message;
            this.Status = StatusConstant.SUCCESS; 
        }
    }


    public class ResponseWithMessage
	{
        public int Code { get; set; }
        public string message { get; set; }
		public string Status { get; set; }
        public string? Error_code { get; set; }
    }

}
