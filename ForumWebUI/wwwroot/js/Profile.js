var ProfileContainer = document.getElementById("ProfileContainerId");

var BodyHeight = document.documentElement.scrollHeight;
var ProfileHeight = ProfileContainer.offsetHeight;
var HeaderHeight = 56;
var DistanceForMargin = (BodyHeight - HeaderHeight - ProfileHeight) / 2;


ProfileContainer.style.marginTop = DistanceForMargin + HeaderHeight + "px";
