// Adjust image to render within window
document.getElementById("sailboat").height = window.innerHeight - 20;

window.onresize = function () {
    document.getElementById("sailboat").height = window.innerHeight - 20;
}

var ship = new Sailboat();
document.getElementById("calculateHullSpeed").addEventListener("click", function (event) {
    event.preventDefault();

    ship.setName(document.getElementById("name").value);
    ship.setLength(parseInt(document.getElementById("length").value));
    document.getElementById("result").value = ship.hullspeed().toFixed(1);
});