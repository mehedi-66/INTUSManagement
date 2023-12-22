﻿namespace INTUSManagement.Model
{
    public class Order
    {
        public Order() { 
             this.Windows = new List<Window>();
        }
        public int OrderId { get; set; }
        private string Name {get; set;}
        private string State { get; set;}

        private List<Window> Windows { get; set;}

    }
}