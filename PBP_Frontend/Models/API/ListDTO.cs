using System;
using System.Collections.Generic;

namespace PBP_Frontend.Models.API
{
    public class ListDTO
    {
        public int ListId { get; set; }
        public string Name { get; set; }
        public string Requester { get; set; }
        public TimeSpan Time { get; set; }
        public List<ProductDTO> ProductsList { get; set; }
        public List<LocationDTO> Locations { get; set; }
    }

    public class ProductDTO
    {
        public int ProductListId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int ListId { get; set; }
        public int LocationId { get; set; }
        public int RequiredQuantity { get; set; }
        public int QuantityCatched { get; set; }
    }

    public class LocationDTO
    {
        public int LocationId { get; set; }
        public int Structure { get; set; }
        public int Street { get; set; }
        public int Building { get; set; }
        public int Flat { get; set; }
    }
}