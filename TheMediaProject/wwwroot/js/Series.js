var index = 1;

function AddEpisode() {
    var x = document.getElementById("AddEpisodeButton");

    var form = CreateEpisodeForm();

    x.insertAdjacentHTML("beforebegin", form);
}

function CreateEpisodeForm() {
    var form = '<h3>Episode ' + (index + 1) + '</h3>'+
        '<div class="form-group">'+
        '<label for="Episodes_'+index+'__Title">Title</label>'+
        '<input class="form-control" type="text" id="Episodes_'+index+'__Title" name="Episodes['+index+'].Title" value="">'+
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