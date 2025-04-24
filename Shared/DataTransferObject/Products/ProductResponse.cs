﻿namespace Shared.DataTransferObject.Products
{
    public record ProductResponse
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string PictureUrl { get; init; }
        public decimal Price { get; init; }
        public string TypeName { get; init; }
        public string BrandName { get; init; }

    }
}
