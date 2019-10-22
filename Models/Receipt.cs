using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyReceiptWebApp.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public byte[] Image { get; set; }

        public DateTime Date { get; set; }
    }
}
