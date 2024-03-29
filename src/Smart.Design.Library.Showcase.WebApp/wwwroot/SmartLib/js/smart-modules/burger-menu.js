/* Burger menu
   ========================================================================== */

var ww = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
var burger_icon = document.querySelector(".burger-icon");
var other_menu_points = document.querySelectorAll(".c-toolbar__item:not(.u-hidden--dsktp) button");
var side_menu = document.querySelector(".c-app-layout-inner__sidebar");

if (ww < 700 && burger_icon) {
    burger_icon.addEventListener('click', openSideMenu);
    other_menu_points.forEach((el) => {
        el.addEventListener('click', closeSideMenu);
    });
}

function closeSideMenu() {
    slideUp(side_menu);
    burger_icon.querySelector("svg").innerHTML = "";
    burger_icon.querySelector("svg").innerHTML = "<path d='M4 7C4 6.44772 4.44772 6 5 6H19C19.5523 6 20 6.44772 20 7C20 7.55228 19.5523 8 19 8H5C4.44772 8 4 7.55228 4 7ZM4 12C4 11.4477 4.44772 11 5 11H19C19.5523 11 20 11.4477 20 12C20 12.5523 19.5523 13 19 13H5C4.44772 13 4 12.5523 4 12ZM4 17C4 16.4477 4.44772 16 5 16H19C19.5523 16 20 16.4477 20 17C20 17.5523 19.5523 18 19 18H5C4.44772 18 4 17.5523 4 17Z' fill='#595959'></path>";
    burger_icon.classList.remove("open");
    burger_icon.setAttribute('aria-pressed', false);
}
function openSideMenu(e) {
    e.preventDefault();
    var el = e.currentTarget;
    var isNotPressed = el.getAttribute('aria-pressed') === "false";
    el.classList.toggle("open");
    slideToggle(side_menu);
    burger_icon.querySelector("svg").innerHTML = "";
    if (isNotPressed) {
        el.querySelector("svg").innerHTML = "<path d='M5.29289 5.2929C5.68342 4.90237 6.31658 4.90237 6.70711 5.2929L12 10.5858L17.2929 5.2929C17.6834 4.90237 18.3166 4.90237 18.7071 5.2929C19.0976 5.68342 19.0976 6.31659 18.7071 6.70711L13.4142 12L18.7071 17.2929C19.0976 17.6834 19.0976 18.3166 18.7071 18.7071C18.3166 19.0976 17.6834 19.0976 17.2929 18.7071L12 13.4142L6.70711 18.7071C6.31658 19.0976 5.68342 19.0976 5.29289 18.7071C4.90237 18.3166 4.90237 17.6834 5.29289 17.2929L10.5858 12L5.29289 6.70711C4.90237 6.31659 4.90237 5.68342 5.29289 5.2929Z' fill='#595959'></path>";
    } else {
        el.querySelector("svg").innerHTML = "<path d='M4 7C4 6.44772 4.44772 6 5 6H19C19.5523 6 20 6.44772 20 7C20 7.55228 19.5523 8 19 8H5C4.44772 8 4 7.55228 4 7ZM4 12C4 11.4477 4.44772 11 5 11H19C19.5523 11 20 11.4477 20 12C20 12.5523 19.5523 13 19 13H5C4.44772 13 4 12.5523 4 12ZM4 17C4 16.4477 4.44772 16 5 16H19C19.5523 16 20 16.4477 20 17C20 17.5523 19.5523 18 19 18H5C4.44772 18 4 17.5523 4 17Z' fill='#595959'></path>";
    }
    el.setAttribute('aria-pressed', (isNotPressed) ? true : false); 
}

window.addEventListener('resize', function () {
    var ww = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;

    if (ww > 700 && side_menu) {
        side_menu.style.display = 'block';
    } else if (burger_icon) {
        closeSideMenu();
        burger_icon.addEventListener('click', openSideMenu);
    }
}, true);
