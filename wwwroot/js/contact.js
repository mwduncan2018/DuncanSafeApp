'use strict';

document.addEventListener('DOMContentLoaded', function () {

    setTimeout(function () {

        var secret = document.createElement("span");
        var message = document.createTextNode(" (Duncan Safe Product!)");
        secret.appendChild(message);
        secret.id = "secretMessage";

        var copyright = document.querySelector("#copyright");
        copyright.appendChild(secret);

    }, 2000);

});