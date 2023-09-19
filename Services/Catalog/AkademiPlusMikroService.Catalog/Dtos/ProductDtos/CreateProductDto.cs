﻿using AkademiPlusMikroService.Catalog.Models;

namespace AkademiPlusMikroService.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {
     
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryId { get; set; }
     
    }
}
