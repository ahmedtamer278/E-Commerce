﻿using Shared.Authentication;

namespace Shared.Orders
{
    public record OrderResponse
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; } = default!;
        public DateTimeOffset Date { get; set; }
        public AddressDTO Address { get; set; } = default!;
        public ICollection<OrderItemDTO> Items { get; set; } = [];
        public string DeliveryMethod { get; set; } = default!;
        public string PaymentStatus { get; set; } 
        public string PaymentIntentId { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }
}
