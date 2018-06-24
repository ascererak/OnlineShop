using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace MultiflexersShop.Models.Entities
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public int InStok { get; set; }
        public bool IsPopular { get; set; }
        public int Bought { get; set; }
        public int CategoryId { get; set; }
        public int Promotional { get; set; }
        public DateTime AddDate { get; set; }
        public virtual Category Category { get; set; }
    }
}
