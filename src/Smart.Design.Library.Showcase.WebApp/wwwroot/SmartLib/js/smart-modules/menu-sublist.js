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
