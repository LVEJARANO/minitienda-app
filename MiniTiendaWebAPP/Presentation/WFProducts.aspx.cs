using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFProducts : System.Web.UI.Page
    {
        /* 
         * Se crean instancias de las clases CategoryLog, ProvidersLog
         * y ProductsLog para interactuar con la lógica de negocio.
         */
        ProductLog objProd = new ProductLog();
        ProvidersLog objPro = new ProvidersLog();
        CategoryLog objCat = new CategoryLog();

        private int _id, _quantity, _fkCategory, _fkProvider;
        private string _code, _description;
        private double _price;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            /* 
             * Se verifica si la página se está cargando por primera vez o 
             * si es una devolución de datos del servidor.
             */
            if (!Page.IsPostBack)
            {
                showProducts();//Se invoca el metodo para mostrar todos los productos
                showProvidersDDL();//Se invoca el metodo para mostrar los proveedores en el DDL
                showCategoriesDDL();
                // Se oculta el campo de texto TBId.
                //TBId.Visible = false;
            }
        }
        //Mostrar las categorias en el DDL
        //Metodo para mostrar las categorias en el DDL
        private void showCategoriesDDL()
        {
            // Se asigna el origen de datos al DropDownList,
            // utilizando el método showCategoriesDDL de la instancia objCat de la clase CategoryLog.
            DDLCategories.DataSource = objCat.showCategoriesDDL();

            // Se especifica el campo que se utilizará como valor de cada elemento del DropDownList.
            DDLCategories.DataValueField = "cat_id";

            // Se especifica el campo que se mostrará como texto para cada elemento del DropDownList.
            DDLCategories.DataTextField = "cat_descripcion";

            // Se enlaza el origen de datos con el DropDownList.
            DDLCategories.DataBind();

            // Se agrega un elemento "Seleccione" al principio del DropDownList para indicar al usuario que elija una categoría.
            DDLCategories.Items.Insert(0, "Seleccione");
        }
        //Metodo para mostrar los proveedores en el DDL
        private void showProvidersDDL()
        {
            DDLProviders.DataSource = objPro.showProvidersDDL();
            DDLProviders.DataValueField = "prov_id";//Nombre de la llave primaria
            DDLProviders.DataTextField = "nombre";
            DDLProviders.DataBind();
            DDLProviders.Items.Insert(0, "Seleccione");
        }

       

        //Metodo para mostrar todos los productos
        private void showProducts()
        {
            DataSet ds = new DataSet();
            ds = objProd.showProducts();
            GVProducts.DataSource = ds;
            GVProducts.DataBind();
        }
        // Metodo para limpiar los TextBox y DDL
        private void clear()
        {
            HFProductId.Value = "";
            TBCode.Text = "";
            TBDescription.Text = "";
            TBPrice.Text = "";
            TBQuantity.Text = "";
            DDLCategories.SelectedIndex = 0;
            DDLProviders.SelectedIndex = 0;
        }


        // Evento que se ejecuta cuando se da clic en el boton guardar
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _code = TBCode.Text;// Capturar el valor que se ingrese en el Texbox
            _description = TBDescription.Text;
            _quantity = Convert.ToInt32(TBQuantity.Text);
            _price = Convert.ToDouble(TBPrice.Text);
            _fkCategory = Convert.ToInt32(DDLCategories.SelectedValue);
            _fkProvider = Convert.ToInt32(DDLProviders.SelectedValue);

            executed = objProd.saveProducts(_code,_description, _quantity, _price, _fkCategory, _fkProvider);

            if (executed)
            {
                LblMsj.Text = "El producto se guardo exitosamente!";
                clear(); // Se invoca el metodo para limpiar los Texbox y DDL
                showProducts(); // Se invoca el metodo para mostrar los productos
            }
            else
            {
                LblMsj.Text = "Error al guardar!";
            }


        }
        // Evento que se ejecuta cuando se da clic en el boton actualizar
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(HFProductId.Value);// Llave primaria
            _code = TBCode.Text;// Capturar el valor que se ingrese en el Texbox
            _description = TBDescription.Text;
            _quantity = Convert.ToInt32(TBQuantity.Text);
            _price = Convert.ToDouble(TBPrice.Text);
            _fkCategory = Convert.ToInt32(DDLCategories.SelectedValue);
            _fkProvider = Convert.ToInt32(DDLProviders.SelectedValue);

            executed = objProd.updateProducts(_id,_code, _description, _quantity, _price, _fkCategory, _fkProvider);

            if (executed)
            {
                LblMsj.Text = "El producto se actualizo exitosamente!";
                clear(); // Se invoca el metodo para limpiar los Texbox y DDL
                showProducts(); // Se invoca el metodo para mostrar los productos
            }
            else
            {
                LblMsj.Text = "Error al actualizar!";
            }
        }
        // Evento para seleccionar una fila de la tabla
        protected void GVProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFProductId.Value = GVProducts.SelectedRow.Cells[0].Text;
            TBCode.Text = GVProducts.SelectedRow.Cells[1].Text;
            TBDescription.Text = GVProducts.SelectedRow.Cells[2].Text;
            TBQuantity.Text = GVProducts.SelectedRow.Cells[3].Text;
            TBPrice.Text = GVProducts.SelectedRow.Cells[4].Text;
            DDLCategories.SelectedValue = GVProducts.SelectedRow.Cells[5].Text;
            DDLProviders.SelectedValue = GVProducts.SelectedRow.Cells[7].Text;
        }
    }
}