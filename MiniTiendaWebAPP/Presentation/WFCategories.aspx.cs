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
    public partial class WFCategories : System.Web.UI.Page
    {
        CategoryLog objCat = new CategoryLog();

        private int _id;
        private string _description;
        private DateTime _date;
        private bool executed = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showCategories();
            }
        }

        //Metodo para mostrar todos los productos
        private void showCategories()
        {
            DataSet ds = new DataSet();
            ds = objCat.showCategories();
            GVCategories.DataSource = ds;
            GVCategories.DataBind();
        }

        // Metodo para limpiar los TextBox y DDL
        private void clear()
        {
            HFCategoryId.Value = "";
            TBDescription.Text = "";
            TBFecha.Text = "";
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            _description = TBDescription.Text;
            _date = DateTime.Parse(TBFecha.Text);

            executed = objCat.saveCategory(_description, _date);

            if (executed)
            {
                LblMsj.Text = "La categoria se guardo exitosamente!";
                clear(); // Se invoca el metodo para limpiar los Texbox y DDL
                showCategories(); // Se invoca el metodo para mostrar los productos
            }
            else
            {
                LblMsj.Text = "Error al guardar!";
            }
        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(HFCategoryId.Value);
            _description = TBDescription.Text;
            _date = DateTime.Parse(TBFecha.Text);

            executed = objCat.updateCategory(_id, _description, _date);

            if (executed)
            {
                LblMsj.Text = "La categoria se actualizo exitosamente!";
                clear(); // Se invoca el metodo para limpiar los Texbox
                showCategories(); // Se invoca el metodo para mostrar los productos
            }
            else
            {
                LblMsj.Text = "Error al actualizar!";
            }
        }

        protected void GVCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            HFCategoryId.Value = GVCategories.SelectedRow.Cells[0].Text;
            // El metodo HttpUtility.HtmlDecode, para mostrar correctamente las palabras con tildes
            TBDescription.Text = HttpUtility.HtmlDecode(GVCategories.SelectedRow.Cells[1].Text);

            // Convertir la fecha al formato "yyyy-MM-dd" y asignarla al TextBox
            string fechaSeleccionada = GVCategories.SelectedRow.Cells[2].Text.Substring(0, 10);
            DateTime fechaConvertida = DateTime.Parse(fechaSeleccionada);
            TBFecha.Text = fechaConvertida.ToString("yyyy-MM-dd");
        }
    }
}