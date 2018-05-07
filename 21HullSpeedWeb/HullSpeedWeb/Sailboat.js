function Sailboat() {
    // Private member variables
    var name;
    var length;
 
    // Properties (setters and getters)
    this.setName = function(value) {
        name = value;
    }

    this.getName = function(){
        return name;
    }

    this.setLength = function(value) {
        length = value;
    }

    this.getLength = function() {
        return length;
    }

    // Member functions

    // Calculate the hull speed for the boat.
    this.hullspeed = function () {
        return 1.34 * Math.sqrt(length);
    }

}
