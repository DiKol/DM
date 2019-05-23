$(document).ready(function () {
    $.ajaxSetup({ cache: false });
    
})

function RenderActions(RenderActionstring) {
    $("#OpenDialog").load(RenderActionstring, function () {
        $('#Birth').datepicker();
    });
    
}

function CreateNew() {
    if (!ValidateInputs())
        return;

    

    $.ajax({
        url: '/User/Create/',
        type: 'POST',
        data: $('form').serialize(),
        success: function (response) {
            Clean();
            $('#btnCloseModal').click();
            var raw = '';
            raw += "<tr id=" + response.Id + '>';
            raw += "<td>" + response.Id + "</td>";
            raw += "<td>" + response.FirstName + "</td>";
            raw += "<td>" + response.LastName + "</td>";
            raw += "<td>" + (new Date(parseInt(response.Birth.substr(6)))).toLocaleString() + "</td>";
            raw += "<td>" + "<button class = \"btn btn-sm btn-primary\" data-toggle=\"modal\" data-target=\"#modalCreate\" onclick=\"RenderActions('/User/Edit/' + " + response.Id + ")\">Edit</button> | " +
                "<button class = \"btn btn-sm btn-danger\" data-toggle=\"modal\" data-target=\"#modalCreate\" onclick=\"RenderActions('/User/Delete/' + " + response.Id + ")\">Delete</button></td>";
            raw += "</tr>";
            $('#indexTbody').append(raw);
        },
        error: function (err) { alert("Error: " + err.responseText); }
    });
}

function DeleteUser(id) {
    document.getElementById(id).remove();
    $.ajax({
        url: '/User/Delete/' + id,
        data: $('form').serialize(),
        type: 'POST',
        success: function () { $('#btnCloseModal').click(); },
        error: function (err) { alert("Error: " + err.responseText); }
    });
}

function EditUser(id) {
    if (!ValidateInputs())
        return;
    $.ajax({
        url: '/User/Edit/' + id,
        type: 'POST',
        data: $('form').serialize(),
        success: function (res) {
            var keys = ["Id", "FirstName", "LastName", "Birth"];
            $('#' + res.Id + ' td').each(function (i) {
                
                if (i === 3) {
                    $(this).text(
                        (new Date(parseInt(res[keys[i]].substr(6)))).toLocaleString()
                    );
                    
                } else {
                    $(this).text(res[keys[i]]);
                }
            });
            $('#btnCloseModal').click();
        },
        error: function (err) { alert("Error: " + err.responseText); }
    });
}

function Clean() {
    $('#modalCreate').find('textarea,input').val('');
}

function ValidateInputs() {
    var flag = true;
    var fname = $('#FirstName');
    var lname = $('#LastName');

    if ($.trim(fname.val()) !== '') {
        fname.closest('.form-group').removeClass('has-error');
        flag = true;
    }

    if ($.trim(lname.val()) !== '') {
        lname.closest('.form-group').removeClass('has-error');
        flag = true;
    }

    if ($.trim(fname.val()) === '') {
        fname.closest('.form-group').addClass('has-error');
        flag = false;
    }

    if ($.trim(lname.val()) === '') {
        lname.closest('.form-group').addClass('has-error');
        flag = false;
    }

    return flag;
}