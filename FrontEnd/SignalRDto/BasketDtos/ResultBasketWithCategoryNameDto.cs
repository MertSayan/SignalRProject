using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDto.BasketDtos
{
    public class ResultBasketWithCategoryNameDto
    {
        public int BasketId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }

        public int TableId { get; set; }
    }
}
