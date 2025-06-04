using System;
using System.Collections.Generic;

namespace FashionStore.Models
{
    public class UserProfileModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public List<OrderModel> Orders { get; set; }
        public List<AddressModel> Addresses { get; set; }
        public List<WishlistItemModel> WishlistItems { get; set; }
        public bool NewsletterSubscribed { get; set; }
        public bool OrderUpdatesSubscribed { get; set; }
        public bool ProductUpdatesSubscribed { get; set; }
    }

    public class OrderModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class AddressModel
    {
        public int Id { get; set; }
        public string AddressType { get; set; }
        public string FullName { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsDefault { get; set; }
    }

    public class WishlistItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public int? Discount { get; set; }
        public bool IsNew { get; set; }
        public string ImageUrl { get; set; }
    }
}
