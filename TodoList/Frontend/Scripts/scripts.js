function LoadAllTasks() {
    $('#add').hide();

    $.ajax({
        type: "GET",
        cache: false,
        url: "http://localhost:8080/api/todolist",
        success: function (result) {
            FillTasks(JSON.parse(result));
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function FilterResolved() {
    $.ajax({
        type: "GET",
        cache: false,
        url: "http://localhost:8080/api/todolist?isDone=false",
        success: function (result) {
            FillTasks(JSON.parse(result));
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function FilterByDescription() {
    var desc = $('#txtDescription').val();

    $.ajax({
        type: "GET",
        cache: false,
        url: "http://localhost:8080/api/todolist?description=" + desc,
        success: function (result) {
            FillTasks(JSON.parse(result));
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function FillTasks(tasks) {
    var taskList = "<table class='table table-striped'>";
    var i;
    for (i = 0; i < tasks.length; i++) {

        var button = "";
        var desc = "";
        var link = "<a href='" + tasks[i].Attachment + "'>File</a>";
        if (tasks[i].IsDone === false) {
            desc = tasks[i].Description;
            button = "<a id='btnResolve_" + tasks[i].ID + "' onclick='MarkAsResolved(" + tasks[i].ID + ")' class='btn btn-success btn-xs'>Terminar</a>";
        }
        else {
            desc = "<s>" + tasks[i].Description + "</s>";
        }

        taskList += "<tr><td>" + desc + "</td><td>" + link + "</td><td>" + button + "</td></tr>";
    }
    taskList += "</table>";

    $('#taskList').html("");
    $('#taskList').html(taskList);
}

function MarkAsResolved(ID) {
    $.ajax({
        type: "POST",
        cache: false,
        url: "http://localhost:8080/api/todolist/" + ID,
        success: function (result) {
            //$('#btnResolve_' + ID).hide();
            LoadAllTasks();
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function AddNewTask() {
    var fileupload = $("#fileAttached")[0].files[0];
    var description = $("#txtAddDescription").val();

    if (fileupload == undefined) {
        alert("Please upload your logo before you hit save.");
        return;
    };

    if (fileupload.size > 20971520) {
        alert("Max file size is 20mb. Please try again.");
        return;
    };

    if (description.length <= 0) {
        alert("Description can't be empty.");
        return;
    }

    var formData = new FormData();
    formData.append("file", fileupload);
    formData.append("description", description);


    $.ajax({
        url: "http://localhost:8080/api/todolist",
        method: "POST",
        data: formData,
        contentType: false,
        processData: false,
        cache: false,
        success: function (result) {
            alert(result);
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function ShowNewTask() {
    $('#list').hide();
    $('#add').show();
}

function BackToList() {
    $('#list').show();
    $('#add').hide();
}