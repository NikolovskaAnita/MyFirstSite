﻿namespace MyFirstSite.DomainModels
{
    public class OrderItem
    {
        public int Id { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }

        public OrderItem()
        {
            
        }

        public OrderItem(int id, MenuItem menuItem, int quantity)
        {
            Id = id;
            MenuItem = menuItem;
            Quantity = quantity;
        }
    }
}
