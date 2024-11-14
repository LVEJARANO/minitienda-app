<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFCategories.aspx.cs" ValidateRequest="false" Inherits="Presentation.WFCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <%--Id--%>
            <asp:HiddenField ID="HFCategoryId" runat="server" />
            <div class="p-2 col-7">
                <%--Descripcion--%>
                <asp:Label ID="Label1" runat="server" Text="">Descripción</asp:Label>
                <asp:TextBox ID="TBDescription" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="p-2 col-5">
                <%--Fecha--%>
                <asp:Label ID="Label2" runat="server" Text="">Fecha</asp:Label>
                <asp:TextBox ID="TBFecha" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="p-2 col">
                <asp:Button ID="BtnSave" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
                <asp:Button ID="BtnUpdate" CssClass="btn btn-primary" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />
                <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="p-2 col">
                <%--Lista de Categorias--%>
                <asp:GridView ID="GVCategories" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVCategories_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="cat_id" HeaderText="Id" />
                        <asp:BoundField DataField="cat_descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="cat_fecha_creacion" HeaderText="Fecha" />
                        <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-info"/>
                        <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
