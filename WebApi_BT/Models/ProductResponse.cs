﻿using System.Linq;

namespace WebApi_BT.Models
{
    public class ProductResponse
    {
        public string Id { get; set; }
        public bool Status { get; set; }
        public IEnumerable<Product> Products{ get; set; }
        public Product Product{ get; set; }
        public Error Error { get; set; }

    }

    public class Error
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

    }
}

