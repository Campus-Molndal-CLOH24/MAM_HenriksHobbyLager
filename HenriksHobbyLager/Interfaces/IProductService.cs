﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenriksHobbyLager.Interfaces
{
    public interface IProductService
    {
        void AddProduct();
        void DeleteProduct();
        void ShowAllProducts();
        void UpdateProduct();
    }
}
