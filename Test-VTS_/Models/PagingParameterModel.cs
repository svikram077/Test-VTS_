﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_VTS_.Models
{
    public class PagingParameterModel
    {
        const int maxPageSize = 20;

        public int pageNumber { get; set; } = 1;

        public int _pageSize { get; set; } = 10;

        public int pageSize
        {

            get { return _pageSize; }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public string QuerySearch { get; set; }
    }
}