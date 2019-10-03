var index = 2;

function AddEpisode() {
    var x = document.getElementById("AddEpisodeButton");

    var form = CreateEpisodeForm();

    x.insertAdjacentHTML("beforebegin", form);
}

function CreateEpisodeForm() {
    var form = '<h3>Episode ' + (index + 1) + '</h3>'+
        '<div class="form-group">'+
            //'<label asp-for="Episodes[' + index + '].Title"></label>'+
        '<label for="Episodes_'+index+'__Title">Title</label>'+
            //'<input class="form-control" asp-for="Episodes[' + index + '].Title" />'+
        '<input class="form-control" type="text" id="Episodes_'+index+'__Title" name="Episodes['+index+'].Title" value="">'+
        //'<span class="text-danger" asp-validation-for="Episodes[' + index + '].Title"></span>'+
        '<span class="text-danger field-validation-valid" data-valmsg-for="Episodes['+index+'].Title" data-valmsg-replace="true"></span>'+
        '</div>'+
        '<div class="form-group">'+
        '<label for="Episodes_' + index + '__Description">Description</label>' +
        '<input class="form-control" type="text" id="Episodes_'+index+'__Description" name="Episodes['+index+'].Description" value="">'+
        '<span class="text-danger field-validation-valid" data-valmsg-for="Episodes['+index+'].Description" data-valmsg-replace="true"></span>'+
        '</div>'+
        '<div class="form-group">'+
        '<label for="Episodes_' + index + '__PlayTimeHours">PlayTimeHours</label>'+
        '<input class="form-control" type="number" data-val="true" data-val-required="The PlayTimeHours field is required." id="Episodes_'+index+'__PlayTimeHours" name="Episodes['+index+'].PlayTimeHours" value="">'+
        '<span class="text-danger field-validation-valid" data-valmsg-for="Episodes['+index+'].PlayTimeHours" data-valmsg-replace="true"></span>'+
        '</div>'+
        '<div class="form-group">'+
        '<label for="Episodes_' + index + '__PlayTimeMinutes">PlayTimeMinutes</label>'+
        '<input class="form-control" type="number" data-val="true" data-val-required="The PlayTimeMinutes field is required." id="Episodes_'+index+'__PlayTimeMinutes" name="Episodes['+index+'].PlayTimeMinutes" value="">'+
        '<span class="text-danger field-validation-valid" data-valmsg-for="Episodes['+index+'].PlayTimeMinutes" data-valmsg-replace="true"></span>'+
        '</div>'+
        '<div class="form-group">'+
        '<label for="Episodes_' + index + '__ReleaseDate">ReleaseDate</label>'+
        '<input class="form-control" type="datetime-local" data-val="true" data-val-required="The ReleaseDate field is required." id="Episodes_'+index+'__ReleaseDate" name="Episodes['+index+'].ReleaseDate" value="">'+
        '<span class="text-danger field-validation-valid" data-valmsg-for="Episodes['+index+'].ReleaseDate" data-valmsg-replace="true"></span>'+
        '</div>';

    index++;

    return form;
}


//'<div class="form-group">' +
//    '<label asp-for="Episodes[' + index + '].Description"></label>' +
//    '<input class="form-control" asp-for="Episodes[' + index + '].Description" />' +
//    '<span class="text-danger" asp-validation-for="Episodes[' + index + '].Description"></span>' +
//    '</div>' +
//    '<div class="form-group">' +
//    '<label asp-for="Episodes[' + index + '].PlayTimeHours"></label>' +
//    '<input class="form-control" asp-for="Episodes[' + index + '].PlayTimeHours" />' +
//    '<span class="text-danger" asp-validation-for="Episodes[' + index + '].PlayTimeHours"></span>' +
//    '</div>' +
//    '<div class="form-group">' +
//    '<label asp-for="Episodes[' + index + '].PlayTimeMinutes"></label>' +
//    '<input class="form-control" asp-for="Episodes[' + index + '].PlayTimeMinutes" />' +
//    '<span class="text-danger" asp-validation-for="Episodes[' + index + '].PlayTimeMinutes"></span>' +
//    '</div>' +
//    '<div class="form-group">' +
//    '<label asp-for="Episodes[' + index + '].ReleaseDate"></label>' +
//    '<input class="form-control" asp-for="Episodes[' + index + '].ReleaseDate" />' +
//    '<span class="text-danger" asp-validation-for="Episodes[' + index + '].ReleaseDate"></span>' +
//    '</div>'