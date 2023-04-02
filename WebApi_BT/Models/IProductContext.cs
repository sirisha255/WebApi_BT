﻿namespace WebApi_BT.Models
{
    public interface IProductContext
    {
        ProductResponse GetAll();
        ProductResponse Get(int id);
        ProductResponse Add(Product item);
        ProductResponse Remove(int id);
        ProductResponse Update(Product item);
    }
}
