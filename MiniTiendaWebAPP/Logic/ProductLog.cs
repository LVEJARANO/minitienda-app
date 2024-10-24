using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic
{
    public class ProductLog
    {
        ProductDat objProd = new ProductDat();

        // Método para mostrar los productos desde la base de datos.
        public DataSet showProducts()
        {
            return objProd.showProducts();
        }

        //Metodo para guardar un nuevo Producto
        public bool saveProducts(string _code, string _description, int _quantity, double _price, int _fkCategory, int _fkProvider)
        {
            return objProd.saveProducts(_code, _description, _quantity, _price, _fkCategory, _fkProvider);
        }

        //Metodo para actulizar un producto
        public bool updateProducts(int _id, string _code, string _description, int _quantity, double _price, int _fkCategory, int _fkProvider)
        {
            return objProd.updateProducts(_id, _code, _description, _quantity, _price, _fkCategory, _fkProvider);
        }

        //Metodo para borrar un Producto
        public bool deleteProducts(int _idProduct)
        {
            return objProd.deleteProducts(_idProduct);
        }
    }
}