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
