var UploadImage = document.getElementById("file");
var ProfileImage = document.getElementById("ProfileIMG");
UploadImage.onchange = function () {
    const file = this.files[0];
    if (file) {
        const reader = new FileReader();

        reader.addEventListener("load", function () {
            var path = (window.URL || window.webkitURL).createObjectURL(file);
            ProfileImage.setAttribute("src", path);
        });

        reader.readAsText(file);
    }
};


