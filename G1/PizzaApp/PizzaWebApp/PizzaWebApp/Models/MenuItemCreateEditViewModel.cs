﻿using System.ComponentModel;

namespace PizzaWebApp.Models
{
    public class MenuItemCreateEditViewModel
    {
        public int Id { get; set; }
        [DisplayName("Selected Pizza")]
        public int SelectedPizzaId { get; set; }
        [DisplayName("Selected Size")]
        public int SelectedSizeId { get; set; }
        public decimal Price { get; set; }
    }
}
