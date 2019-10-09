//Title
function editTitle() {
    var x = document.getElementById("Title");
    x.style.display = "none";

    var y = document.getElementById("TitleForm");
    y.style.display = "block";

    document.getElementById("TitleValue").value = document.getElementById("Title").innerHTML;
}

function cancelTitle() {
    var x = document.getElementById("Title");
    x.style.display = "block";

    var y = document.getElementById("TitleForm");
    y.style.display = "none";
}

function saveTitle() {
    var x = document.getElementById("Title");
    x.style.display = "block";

    var y = document.getElementById("TitleForm");
    y.style.display = "none";
}

//Description
function editDescription() {
    var x = document.getElementById("Description");
    x.style.display = "none";

    var y = document.getElementById("DescriptionForm");
    y.style.display = "block";

    document.getElementById("DescriptionValue").value = document.getElementById("Description").innerHTML;
}

function cancelDescription() {
    var x = document.getElementById("Description");
    x.style.display = "block";

    var y = document.getElementById("DescriptionForm");
    y.style.display = "none";
}

function saveDescription() {
    var x = document.getElementById("Description");
    x.style.display = "block";

    var y = document.getElementById("DescriptionForm");
    y.style.display = "none";
}

//Playtime
function editPlayTime() {
    var x = document.getElementById("PlayTime");
    x.style.display = "none";

    var y = document.getElementById("PlayTimeForm");
    y.style.display = "block";

    document.getElementById("PlayTimeValue").value = document.getElementById("PlayTime").innerHTML;
}

function cancelPlayTime() {
    var x = document.getElementById("PlayTime");
    x.style.display = "block";

    var y = document.getElementById("PlayTimeForm");
    y.style.display = "none";
}

function savePlayTime() {
    var x = document.getElementById("PlayTime");
    x.style.display = "block";

    var y = document.getElementById("PlayTimeForm");
    y.style.display = "none";
}

//ReleaseDate
function editReleaseDate() {
    var x = document.getElementById("ReleaseDate");
    x.style.display = "none";

    var y = document.getElementById("ReleaseDateForm");
    y.style.display = "block";

    document.getElementById("ReleaseDateValue").value = document.getElementById("ReleaseDate").innerHTML;
}

function cancelReleaseDate() {
    var x = document.getElementById("ReleaseDate");
    x.style.display = "block";

    var y = document.getElementById("ReleaseDateForm");
    y.style.display = "none";
}

function saveReleaseDate() {
    var x = document.getElementById("ReleaseDate");
    x.style.display = "block";

    var y = document.getElementById("ReleaseDateForm");
    y.style.display = "none";
}

//Genre
function editGenre() {
    var x = document.getElementById("Genre");
    x.style.display = "none";

    var y = document.getElementById("GenreForm");
    y.style.display = "block";

    $('#GenreValue').val(document.getElementById("Genre").innerHTML);
}

function cancelGenre() {
    var x = document.getElementById("Genre");
    x.style.display = "block";

    var y = document.getElementById("GenreForm");
    y.style.display = "none";
}

function saveGenre() {
    var x = document.getElementById("Genre");
    x.style.display = "block";

    var y = document.getElementById("GenreForm");
    y.style.display = "none";
}

//Actors
function editActors() {
    var x = document.getElementById("Actors");
    x.style.display = "none";

    var y = document.getElementById("ActorsForm");
    y.style.display = "block";

    $('#ActorsValue').val(document.getElementById("Actors").innerHTML);
}

function cancelActors() {
    var x = document.getElementById("Actors");
    x.style.display = "block";

    var y = document.getElementById("ActorsForm");
    y.style.display = "none";
}

function saveActors() {
    var x = document.getElementById("Actors");
    x.style.display = "block";

    var y = document.getElementById("ActorsForm");
    y.style.display = "none";
}

//Directors
function editDirectors() {
    var x = document.getElementById("Directors");
    x.style.display = "none";

    var y = document.getElementById("DirectorsForm");
    y.style.display = "block";

    $('#DirectorsValue').val(document.getElementById("Directors").innerHTML);
}

function cancelDirectors() {
    var x = document.getElementById("Directors");
    x.style.display = "block";

    var y = document.getElementById("DirectorsForm");
    y.style.display = "none";
}

function saveDirectors() {
    var x = document.getElementById("Directors");
    x.style.display = "block";

    var y = document.getElementById("DirectorsForm");
    y.style.display = "none";
}

//Playlist
function addToPlaylist() {
    var x = document.getElementById("Playlist");
    x.style.display = "none";

    var y = document.getElementById("PlaylistForm");
    y.style.display = "block";

    $('#PlaylistsValue').val(document.getElementById("Playlist").innerHTML);
}

function cancelPlaylist() {
    var x = document.getElementById("Playlist");
    x.style.display = "block";

    var y = document.getElementById("PlaylistForm");
    y.style.display = "none";
}

function savePlaylist() {
    var x = document.getElementById("Playlist");
    x.style.display = "block";

    var y = document.getElementById("PlaylistForm");
    y.style.display = "none";
}
