
function getVal(val) {
  //  var test = $("#ddlMarcas").val($(this).find("option:selected").text());
    //var test = document.getElementById("#ddlMarcas").value;
    alert(val);
}

function callChangefunc(val) {
    window.location.href = "/Controller/ActionMethod?value=" + val;
}