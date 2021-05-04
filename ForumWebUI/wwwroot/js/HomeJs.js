var ThemeSide = document.getElementById("ThemesSideId");
var BodyHeight = document.documentElement.scrollHeight;
var PostSide = document.getElementById("PostsSideId");
var HeaderHeight = 56;


window.addEventListener("resize", resizeFunction);

ThemeSide.style.marginTop = HeaderHeight + "px";
PostSide.style.marginLeft = ThemeSide.offsetWidth + "px";
PostSide.style.marginTop = HeaderHeight + "px";

function resizeFunction() {
    PostSide.style.marginLeft = ThemeSide.offsetWidth + "px";
    PostSide.style.marginTop = HeaderHeight + "px";
}

ThemeSide.style.height = BodyHeight - HeaderHeight + "px";