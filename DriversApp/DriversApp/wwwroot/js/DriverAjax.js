function LoadDepartments() {

    $('departmentDropdown option').remove();

    $.ajax({
        type: 'GET',
        url: 'Departments/GetDepartments',
        success(data) {
            if (data !== null) {
                var s = '<option value="-1">select a department</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].id + '">' + data[i].departmentName + '</option>';
                }
                $("#departmentDropdown").html(s);
            }
        }, error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function LoadSections() {

    $('sectionDropdown option').remove();

    $.ajax({
        type: 'GET',
        url: 'Sections/GetSections',
        success(data) {
            if (data !== null) {
                var s = '<option value="-1">select a section</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].id + '">' + data[i].sectionName + '</option>';
                }
                $("#sectionDropdown").html(s);
            }
        }, error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function LoadManagers() {

    $('managerDropdown option').remove();

    $.ajax({
        type: 'GET',
        url: 'Managers/GetManagers',
        success(data) {
            if (data !== null) {
                var s = '<option value="-1">select a manager</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].id + '">' + data[i].fullName + '</option>';
                }
                $("#managerDropdown").html(s);
            }
            console.log(data);
        }, error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function LoadRequirements() {

    $('requirementDropdown option').remove();

    $.ajax({
        type: 'GET',
        url: 'Requirements/GetRequirements',
        success(data) {
            if (data !== null) {
                var s = '<option value="-1">select a requirement</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].id + '">' + data[i].name + '</option>';
                }
                $("#requirementDropdown").html(s);
            }
            console.log(data);
        }, error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function LoadData() {
    $.ajax({
        url: 'Drivers/GetDriversInformation',
        type: 'GET',
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td hidden>' + item.id + '</td>';
                html += '<td>' + item.firstName + '</td>';
                html += '<td>' + item.lastName + '</td>';
                html += '<td>' + item.email + '</td>';
                html += '<td>' + item.department + '</td>';
                html += '<td>' + item.section + '</td>';
                html += '<td>' + item.requirement + '</td>';
                html += '<td>' + item.managerId + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.id + ')">Edit</a> | <a href="#" onclick="Delele(' + item.id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function SaveData() {

    var res = Validate();
    if (res === false) {
        return false;
    }
    var driverModel = {
        FirstName: $('#txtfirstName').val(),
        LastName: $('#txtlastName').val(),
        Email: $('#txtEmail').val(),
        Department: $('#departmentDropdown :selected').text(),
        Section: $('#sectionDropdown :selected').text(),
        Requirement: $('#requirementDropdown :selected').text(),
        ManagerId: $('#managerDropdown').val()
    };

    $.ajax({
        url: 'Drivers/AddNewDriver',
        type: 'POST',
        data: { driver: driverModel },
        success: function (data) {
            LoadData();
            clearData();
        }, error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function getbyID(driverId) {
    $.ajax({
        url: 'Drivers/GetById',
        type: "GET",
        data: { driverId: driverId },
        success: function (result) {
            $('#txtId').val(result.id);
            $('#txtfirstName').val(result.firstName);
            $('#txtlastName').val(result.lastName);
            $('#txtEmail').val(result.email);
            $('#departmentDropdown').val(result.id);
            $('#sectionDropdown').val(result.id);
            $('#requirementDropdown').val(result.id);
            $('#managerDropdown').val(result.managerId);
            $('#driversModal').modal('show');
            //$('#btnUpdate').show();
            $('#btnAdd').hide();
            console.log(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


function UpdateData() {

    var res = Validate();
    if (res === false) {
        return false;
    }
    var driverModel = {
        Id: $('#txtId').val(),
        FirstName: $('#txtfirstName').val(),
        LastName: $('#txtlastName').val(),
        Email: $('#txtEmail').val(),
        Department: $('#departmentDropdown :selected').text(),
        Section: $('#sectionDropdown :selected').text(),
        Requirement: $('#requirementDropdown :selected').text(),
        ManagerId: $('#managerDropdown').val()
    };

    $.ajax({
        url: 'Drivers/UpdateDriver',
        type: 'PUT',
        data: { driver: driverModel },
        success: function (data) {
            LoadData();
            $('#driversModal').modal('hide');
            clearData();
        }, error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Delele(Id) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Drivers/DeleteDriver/",
            data: { Id:Id },
            type: "DELETE",
            success: function (result) {
                LoadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}