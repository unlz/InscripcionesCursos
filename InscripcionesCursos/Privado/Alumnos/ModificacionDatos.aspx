﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificacionDatos.aspx.cs" Inherits="InscripcionesCursos.ModificacionDatos" %>
<%@ Register src="~/Controles/wucRelevamientoLimitaciones.ascx" tagname="Relevamiento" tagprefix="uc1" %>
<asp:Content ID="TitleContentModificacionDatos" runat="server" ContentPlaceHolderID="TitleContent">
    <%= String.Format(ConfigurationManager.AppSettings["TitleGeneric"], ConfigurationManager.AppSettings["TitleModificacionDatos"])%>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="upModDatos" runat="server" UpdateMode="Always" ChildrenAsTriggers="True">
        <ContentTemplate>
            <asp:ScriptManager runat="Server" EnablePartialRendering="true" ID="scriptManagerModificacion" />
            <div class="contenedorFormGenerar">
                <div class="tituloContenido">
                    <asp:Label ID="lblTitulo" runat="server" Text=""><%= ConfigurationManager.AppSettings["ContentMainTitleModificacionDatos"] %></asp:Label>
                </div>
                <div class="resultadosGen" style="margin-left: 265px;">
                    <div class="resultadosLinea">
                        <asp:Label CssClass="labelsCambioPass" ID="lblDni" runat="server" Text=""><%= ConfigurationManager.AppSettings["LabelDNI"] %></asp:Label>
                        <asp:TextBox CssClass="inputsResultadosGen" ID="txtDni" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="resultadosLinea">
                        <asp:Label CssClass="labelsCambioPass" ID="lblApellidoNombre" runat="server" Text=""><%= ConfigurationManager.AppSettings["LabelApellidoNombre"] %></asp:Label>
                        <asp:TextBox CssClass="inputsResultadosGen" ID="txtApellidoNombre" runat="server" Enabled="False"></asp:TextBox>
                    </div>
                    <div class="resultadosLinea">
                        <asp:Label CssClass="labelsCambioPass" ID="lblEmail" runat="server" Text=""><%= ConfigurationManager.AppSettings["LabelEmail"]%></asp:Label>
                        <asp:TextBox CssClass="inputsResultadosGen" ID="txtEmail" runat="server" Enabled="False" MaxLength="40"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtEmail" ID="EmailRequired" runat="server" ToolTip="Debe ingresar una dirección de mail" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ControlToValidate="txtEmail" ID="EmailValidate" runat="server" ToolTip="Debe ingresar una dirección de mail válida" ValidationExpression="^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$" ForeColor="Red">*</asp:RegularExpressionValidator>
                    </div>
                    <div class="resultadosLinea">
                        <asp:Label CssClass="labelsCambioPass" ID="lblCarrera" runat="server" Text=""><%= ConfigurationManager.AppSettings["LabelCarrera"]%></asp:Label>
                        <asp:TextBox CssClass="inputsResultadosGen" ID="txtCarrera" runat="server" Enabled="False"></asp:TextBox>
                    </div>
                    <br />
                    <uc1:Relevamiento runat="server" ID="ucRelevamientoMod" />
                </div>
                <div id="divMessage" runat="server" class="changePasswordStatus" visible="false">
                    <asp:Label ID="FailureText" runat="server"></asp:Label>
                </div>
                <div class="contenedorBotonActualizar">
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" 
                        CssClass="blackButton" onclick="btnActualizar_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
