<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFProducts.aspx.cs" Inherits="Presentation.WFProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestion de productos</h1>
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <%--Id--%>
                <asp:HiddenField ID="HFProductId" runat="server" />

                <%--Codigo--%>
                <asp:Label ID="Label1" runat="server" Text="Ingrese el codigo"></asp:Label>
                <asp:TextBox ID="TBCode" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <%--Descripcion--%>
                <asp:Label ID="Label2" runat="server" Text="Ingrese la descripcion"></asp:Label>
                <asp:TextBox ID="TBDescription" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <%--Cantidad--%>
                <asp:Label ID="Label4" runat="server" Text="Ingrese la cantidad"></asp:Label>
                <asp:TextBox ID="TBQuantity" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="p-2 col">
                <%--Precio--%>
                <asp:Label ID="Label5" runat="server" Text="Ingrese el precio"></asp:Label>
                <asp:TextBox ID="TBPrice" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="p-2 col">
                <%--Categoria--%>
                <asp:Label ID="Label6" runat="server" Text="Categoria"></asp:Label>
                <asp:DropDownList ID="DDLCategories" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="p-2 col">
                <%--Proveedor--%>
                <asp:Label ID="Label7" runat="server" Text="Proveedor"></asp:Label>
                <asp:DropDownList ID="DDLProviders" CssClass="form-select" runat="server"></asp:DropDownList>

            </div>
        </div>
        <div class="row">
            <div class="p-2 col">
                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="BtnSave_Click" />
                <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" CssClass="btn btn-primary" OnClick="BtnUpdate_Click" />
                <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="p-2 col">
                <%--Lista de Productos--%>
                <asp:GridView ID="GVProducts" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVProducts_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="pro_id" HeaderText="Id" />
                        <asp:BoundField DataField="pro_codigo" HeaderText="Codigo" />
                        <asp:BoundField DataField="pro_descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="pro_cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="pro_precio" HeaderText="Precio" />
                        <asp:BoundField DataField="tbl_categoria_cat_id" HeaderText="FkCategoria" />
                        <asp:BoundField DataField="cat_descripcion" HeaderText="Categoria" />
                        <asp:BoundField DataField="tbl_proveedor_prov_id" HeaderText="FkProveedor" />
                        <asp:BoundField DataField="prov_nombre" HeaderText="Proveedor" />
                        <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-info" />
                        <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
