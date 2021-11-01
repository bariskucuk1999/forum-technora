let status = true;
const button = document.querySelector(".switch");
button.addEventListener("change", function () {
    if (status === false) {
        document.querySelector(".navbar").className = "navbar fixed-top navbar-expand-md navbar-dark bg-primary";
        document.querySelector(".dropdown-menu").className = "dropdown-menu dropdown-menu-right";
        const element = document.querySelectorAll("a");
        element.forEach(function (el) {
            el.style.color = "white";
        })
        const element2 = document.querySelectorAll("label, span, .dropdown-item");
        element2.forEach(function (el) {
            el.style.color = "black";
        })
        getComputedStyle(document.documentElement)
            .getPropertyValue("--main-bg-color");
        document.documentElement.style
            .setProperty("--main-bg-color", "#17a2b8");
        bodyDarkMode(false);
        status = true;
    }
    else if (status === true) {
        document.querySelector(".navbar").className = "navbar fixed-top navbar-expand-md navbar-dark bg-dark";
        document.querySelector(".dropdown-menu").className = "dropdown-menu dropdown-menu-right bg-dark";
        const element = document.querySelectorAll("a, span, label");
        element.forEach(function (el) {
            el.style.color = "#ff6600";
        })
        const element2 = document.querySelectorAll(".form-control label"); //SignUp form ekranı elemanlarına erişim
        element2.forEach(function (el) {
            el.style.color = "black";
        })
        getComputedStyle(document.documentElement)
            .getPropertyValue("--main-bg-color");
        document.documentElement.style
            .setProperty("--main-bg-color", "white");
        bodyDarkMode(true);
        status = false;
    }
});

function bodyDarkMode(active) {
    const element = document.querySelectorAll("p, h3, li");
    element.forEach(function (el) {
        if (active) {
            document.querySelector("body").style.backgroundColor = "#202020";
            el.style.color = "#99cc00";
        }
        else {
            document.querySelector("body").style.backgroundColor = "white";
            el.style.color = "black";
        }
    });
}