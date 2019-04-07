$(document).ready(
    function () {
        if (typeof menuItemId === "undefined") {
        } else {
            $("div.menu-list ul.menu-content li#" + menuItemId).addClass("active");
        }
    }
);