using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductPulseServer.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}