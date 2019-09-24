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