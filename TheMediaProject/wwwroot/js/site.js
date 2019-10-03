function AddActor() {
    var actorlist = document.getElementById("actorslist").value;
    if (actorlist != "") {
        actorlist = actorlist + ", " + document.getElementById("actorsinput").value;
    }
    else {
        actorlist = document.getElementById("actorsinput").value;
    }

    document.getElementById("actorslist").value = actorlist;
    document.getElementById("actorsinput").value = "";
}

function AddDirector() {
    var directorlist = document.getElementById("directorslist").value;
    if (directorlist != "") {
        directorlist = directorlist + ", " + document.getElementById("directorsinput").value;
    }
    else {
        directorlist = document.getElementById("directorsinput").value;
    }

    document.getElementById("directorslist").value = directorlist;
    document.getElementById("directorsinput").value = "";
}

function ShowCreateSeason() {
    var CreateSeasonForm = document.getElementsByClassName("SeasonForm");
    for (var index= 0; index< CreateSeasonForm.length; index++) {
        CreateSeasonForm[index].style.display = "block";
    }

    var CreateSeasonFormHide = document.getElementsByClassName("SeasonFormHide");
    for (var i = 0; i < CreateSeasonFormHide.length; i++) {
        CreateSeasonFormHide[i].style.display = "none";
    }

    var y = document.getElementById("SeasonFormButton");
    y.style.display = "inline-block";
}

function CancelCreateSeason() {
    var CreateSeasonForm = document.getElementsByClassName("SeasonForm");
    for (var index = 0; index < CreateSeasonForm.length; index++) {
        CreateSeasonForm[index].style.display = "none";
    }

    var CreateSeasonFormHide = document.getElementsByClassName("SeasonFormHide");
    for (var i = 0; i < CreateSeasonFormHide.length; i++) {
        CreateSeasonFormHide[i].style.display = "inline-block";
    }

    var y = document.getElementById("SeasonFormButton");
    y.style.display = "none";
}