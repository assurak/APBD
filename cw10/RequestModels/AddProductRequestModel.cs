﻿using cw10.Models;

namespace cw10.RequestModels;

public class AddProductRequestModel
{
    public string productName { get; set; }
    public decimal productWeight { get; set; }
    public decimal productWidth { get; set; }
    public decimal productHeight { get; set; }
    public decimal productDepth { get; set; }
    
    public int [] categoriesId { get; set; }
}