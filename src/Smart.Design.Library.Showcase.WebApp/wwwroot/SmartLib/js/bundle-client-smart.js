import slideToggle from "./smart-modules/slides.js";

/* Menu Sublist
   ========================================================================== */


class Subltitle {
    constructor(menu_subtitle) {
        this.subtitle = menu_subtitle;

        this.subtitle.addEventListener('click', myFunc, false);

        function myFunc(e) {
            var sublist = e.currentTarget.nextElementSibling;
            sublist.classList.toggle("open");
        }
    }
}

const menu_subtitles = document.querySelectorAll(".c-side-menu__subtitle");

if (menu_subtitles.length) {
    [...menu_subtitles].map((menu_subtitle) => new Subltitle(menu_subtitle));
}

/* Burger menu
   ========================================================================== */

var ww = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
var burger_icon = document.querySelector(".burger-icon");
var side_menu = document.querySelector(".c-app-layout-inner__sidebar");

if (ww < 700) {
    burger_icon.addEventListener('click', openSideMenu);
}

function openSideMenu(e) {
    e.preventDefault();
    e.currentTarget.classList.toggle("open");
    slideToggle(side_menu, 600);
    /* Do we need to close the menu after link is clicked in sidemenu ? */
}

window.addEventListener('resize', function () {
    var ww = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;

    if (ww > 700) {
        side_menu.style.display = 'block';
    } else {
        side_menu.style.display = 'none';
    }

}, true);
