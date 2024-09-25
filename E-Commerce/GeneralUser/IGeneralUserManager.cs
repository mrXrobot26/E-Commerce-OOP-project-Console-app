using E_Commerce.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.GeneralUser
{
    internal interface IGeneralUserManager
    {
        List<Product> GetAllProducts();

        //Product GetProductByName(string name); XXXXXX =>  if product name are repeated so we will return a list 
        List<Product> GetProductsByName(string name);

    }
}
