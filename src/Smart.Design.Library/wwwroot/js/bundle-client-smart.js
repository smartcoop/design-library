/* Burger menu
   ========================================================================== */

var ww = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
var burger_icon = document.querySelector(".burger-icon");
var other_menu_points = document.querySelectorAll(".c-toolbar__item:not(.u-hidden--dsktp) button");
var side_menu = document.querySelector(".c-app-layout-inner__sidebar");

if (ww < 700) {
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

    if (ww > 700) {
        side_menu.style.display = 'block';
    } else {
        closeSideMenu();
        burger_icon.addEventListener('click', openSideMenu);
    }
}, true);

/* SLIDE UP Might move */
let slideUp = (target, duration = 500) => {

    target.style.transitionProperty = 'height, margin, padding';
    target.style.transitionDuration = duration + 'ms';
    target.style.boxSizing = 'border-box';
    target.style.height = target.offsetHeight + 'px';
    target.offsetHeight;
    target.style.overflow = 'hidden';
    target.style.height = 0;
    target.style.paddingTop = 0;
    target.style.paddingBottom = 0;
    target.style.marginTop = 0;
    target.style.marginBottom = 0;
    window.setTimeout(() => {
        target.style.display = 'none';
        target.style.removeProperty('height');
        target.style.removeProperty('padding-top');
        target.style.removeProperty('padding-bottom');
        target.style.removeProperty('margin-top');
        target.style.removeProperty('margin-bottom');
        target.style.removeProperty('overflow');
        target.style.removeProperty('transition-duration');
        target.style.removeProperty('transition-property');
        //alert("!");
    }, duration);
}

/* SLIDE DOWN */
let slideDown = (target, duration = 500) => {

    target.style.removeProperty('display');
    let display = window.getComputedStyle(target).display;
    if (display === 'none') display = 'block';
    target.style.display = display;
    let height = target.offsetHeight;
    target.style.overflow = 'hidden';
    target.style.height = 0;
    target.style.paddingTop = 0;
    target.style.paddingBottom = 0;
    target.style.marginTop = 0;
    target.style.marginBottom = 0;
    target.offsetHeight;
    target.style.boxSizing = 'border-box';
    target.style.transitionProperty = "height, margin, padding";
    target.style.transitionDuration = duration + 'ms';
    target.style.height = height + 'px';
    target.style.removeProperty('padding-top');
    target.style.removeProperty('padding-bottom');
    target.style.removeProperty('margin-top');
    target.style.removeProperty('margin-bottom');
    window.setTimeout(() => {
        target.style.removeProperty('height');
        target.style.removeProperty('overflow');
        target.style.removeProperty('transition-duration');
        target.style.removeProperty('transition-property');
    }, duration);
}

let slideToggle = (target, duration = 500) => {
    if (window.getComputedStyle(target).display === 'none') {
        return slideDown(target, duration);
    } else {
        return slideUp(target, duration);
    }
}

window.slideToggle = slideToggle;


/* Menu Sublist
   ========================================================================== */

class SubTitle {
    constructor(menu_subtitle) {
        this.subtitle = menu_subtitle;

        this.subtitle.addEventListener('click', openSubList, false);

        function openSubList(e) {
            var sublist = e.currentTarget.nextElementSibling;
            sublist.classList.toggle("open");
            e.currentTarget.classList.toggle("active");
            slideToggle(sublist);
            sublist.setAttribute('aria-expanded', (sublist.getAttribute('aria-expanded') === "false") ? true : false); 
        }
    }
}

const menu_subtitles = document.querySelectorAll(".c-side-menu__subtitle");

if (menu_subtitles.length) {
    [...menu_subtitles].map((menu_subtitle) => new SubTitle(menu_subtitle));
}
