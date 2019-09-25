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