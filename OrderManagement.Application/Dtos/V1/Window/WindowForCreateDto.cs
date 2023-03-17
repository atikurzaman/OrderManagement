﻿namespace OrderManagement.Application.Dtos.V1.Window
{
    public class WindowForCreateDto
    {
        public string Name { get; set; }

        public int QuantityOfWindows { get; set; }

        public int TotalSubElements { get; set; }

        public int OrderId { get; set; }
    }
}