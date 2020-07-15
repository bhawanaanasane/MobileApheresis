using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAPI.Models.Result
{
    public class ResultModel
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Response { get; set; }
    }

    public class ResultPageListModel
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Response { get; set; }

        public int CurrentPage { get; set; }
        public int pageSize { get; set; }
        public int TotalListCount { get; set; }
    }
}
