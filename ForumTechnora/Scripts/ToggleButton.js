let status = true;
const button = document.querySelector(".switch");
button.addEventListener("change", function () {
    if (status === false) {
        document.querySelector(".navbar").className = "navbar fixed-top navbar-expand-md navbar-dark bg-primary";
        const element = document.querySelectorAll("a, span");
        element.forEach(function (el) {
            el.style.color = "black";
        })
        getComputedStyle(document.documentElement)
            .getPropertyValue("--main-bg-color");
        document.documentElement.style
            .setProperty("--main-bg-color", "#17a2b8");
        bodyDarkMode(false);
        cardDarkMode(false);
        status = true;
    }
    else if (status === true) {
        document.querySelector(".navbar").className = "navbar fixed-top navbar-expand-md navbar-dark bg-dark";
        const element = document.querySelectorAll("a, span");
        element.forEach(function (el) {
            el.style.color = "#99cc00";
        })
        getComputedStyle(document.documentElement)
            .getPropertyValue("--main-bg-color");
        document.documentElement.style
            .setProperty("--main-bg-color", "white");
        bodyDarkMode(true);
        cardDarkMode(true);
        status = false;
    }
});

function bodyDarkMode(active) {
    const element = document.querySelectorAll("p, h3, h6, li, option, label");
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
function cardDarkMode(active) {
    const element = document.getElementsByClassName("card-body");
    for (let el of element) {
        el.classList.toggle("dark");
    }
    const element2 = document.getElementsByClassName("list-group-item");
    for (let el2 of element2) {
        el2.classList.toggle("dark");
    }
    const element3 = document.getElementsByClassName("form-control");
    for (let el3 of element3) {
        el3.classList.toggle("dark");
    }
}