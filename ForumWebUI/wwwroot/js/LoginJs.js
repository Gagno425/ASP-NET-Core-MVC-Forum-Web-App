var Form = document.getElementById("LoginFormId");
var FormHeight = Form.offsetHeight;
var BodyHeight = document.documentElement.scrollHeight;
var HeaderHeight = 56;
var DistanceForMargin = (BodyHeight - HeaderHeight - FormHeight) / 2;
Form.style.marginTop = DistanceForMargin + HeaderHeight + "px";