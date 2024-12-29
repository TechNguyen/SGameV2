using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Service.Common
{
	public class SearchBase
	{
        private int _pageIndex = 1;
        private int _pageSize = 10;
        public int PageIndex { get => _pageIndex; set => (_pageIndex) = (value <= 0) ? 1 : value;    }
        public int PageSize { get => _pageSize; set => (_pageSize) = (value <= 0) ? 10 : value; }
    }
}
