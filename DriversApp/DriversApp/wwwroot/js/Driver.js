$(document).ready(function () {
    LoadDepartments();
    LoadSections();
    LoadManagers();
    LoadData();
    LoadRequirements();
});

function clearData() {
    $('#txtfirstName').val("");
    $('#txtlastName').val("");
    $('#txtEmail').val("");
    $('#departmentDropdown  option:selected').remove();
    $('#sectionDropdown option:selected').remove();
    $('#managerDropdown option:selected').remove();
    $('#requirementDropdown option:selected').remove();
    $('#txtfirstName').css('border-color', 'lightgrey');
    $('#txtlastName').css('border-color', 'lightgrey');
    $('#txtEmail').css('border-color', 'lightgrey');
    $('#departmentDropdown').css('border-color', 'lightgrey');
    $('#sectionDropdown').css('border-color', 'lightgrey');
    $('#managerDropdown').css('border-color', 'lightgrey');
    $('#requirementDropdown').css('border-color', 'lightgrey');
}

function Validate() {
    var isValid = true;
    var department = $("#departmentDropdown option:selected").val();
    var section = $("#sectionDropdown option:selected").val();
    var manager = $("#managerDropdown option:selected").val();
    var requirement = $("#requirementDropdown option:selected").val();

    if ($('#txtfirstName').val().trim() === "") {
        $('#txtfirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtfirstName').css('border-color', 'lightgrey');
    }
    if ($('#txtlastName').val().trim() == "") {
        $('#txtlastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtlastName').css('border-color', 'lightgrey');
    }   
    if ($('#txtEmail').val().trim() === "") {
        $('#txtEmail').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtEmail').css('border-color', 'lightgrey');
    }
    if (department === '-1') {
        $('#departmentDropdown').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#departmentDropdown').css('border-color', 'lightgrey');
    }
    if (section === '-1') {
        $('#sectionDropdown').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#sectionDropdown').css('border-color', 'lightgrey');
    }
    if (manager === '-1') {
        $('#managerDropdown').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#managerDropdown').css('border-color', 'lightgrey');
    }
    if (requirement === '-1') {
        $('#requirementDropdown').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#requirementDropdown').css('border-color', 'lightgrey');
    }
    return isValid;
}