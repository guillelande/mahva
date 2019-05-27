<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Frontend._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />

    <div class="container">
        <h1>TODO List:</h1>
        <div id="list" class="form-inline">
            <div class="form-group form-inline">
                <label for="txtDescription">Filtrar por</label>
                <input type="text" id="txtDescription" class="form-control input-sm"/>
                <a id="btnFilterDescription" onclick="FilterByDescription()" class="btn btn-sm btn-default">Filtrar por descripción</a>
                <a id="btnFilterResolved" onclick="FilterResolved()" class="btn btn-sm btn-default">Filtrar resueltas</a>
            </div>
            <span id="taskList"></span>
            <a id="btnAddNewTask" onclick="ShowNewTask()" class="btn btn-sm btn-info">Nuevo</a>
        </div>

        <div id="add" class="form-horizontal">
            <div class="form-group">
                <label for="txtAddDescription">Tarea</label>
                <input type="text" id="txtAddDescription" class="form-control input-sm" />
            </div>
            <div class="form-group">
                <label for="fileAttached">Adjuntar archivo</label>
                <input type="file" id="fileAttached" class="form-control input-sm" />
            </div>
            <div class="form-group">
                <a id="btnAddTask" onclick="AddNewTask()" class="btn btn-sm btn-info">Agregar</a>
                <a id="btnBack" onclick="BackToList()" class="btn btn-sm btn-default">Volver</a>
            </div>
        </div>
    </div>
    
    <script src="Scripts/scripts.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script>
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(LoadAllTasks);  
    </script>
    
</asp:Content>