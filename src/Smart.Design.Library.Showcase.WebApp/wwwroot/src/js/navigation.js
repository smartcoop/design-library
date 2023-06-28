import gsap from 'gsap';

// window.addEventListener('resize', function(event) {
//     var ww = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
// 	var wh = window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;
// 	const home_splash = document.querySelectorAll('.home-splash');
//     const map = document.querySelector('#map');
    
//         gsap.set(home_splash, {height: wh, width: ww });
//         gsap.set(map, {height: wh, width: ww });

// }, true);
var ww = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
var wh = window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;
const burger = document.querySelector('.burger');
// const burger__close = document.querySelector('.burger--close');
// const burger_bar__top = burger__close.querySelectorAll('.burger-icon__bar')[0];
// const burger_bar__bot = burger__close.querySelectorAll('.burger-icon__bar')[1];
const menu = document.querySelectorAll('.site-navigation');

document.querySelectorAll(".current_page_item").forEach(item=>item.setAttribute('data-barba-prevent','all'));

const burgerMotionIn = gsap.timeline({
    defaults: {
        duration: .125, ease: "expo.out"
    }
});

gsap.set(menu, {width: ww}, 0);
gsap.set(menu, {height: wh}, 0);
gsap.set(menu, {autoAlpha:0}, 0);


burgerMotionIn
    .fromTo(menu,  { scale:.85 }, { autoAlpha:1, duration: .25, scale:1 },  0.1)
    .reverse();

burger.addEventListener('click', function(event) {
    event.preventDefault();
    console.log("open menu");
    burgerMotionIn.reversed(!burgerMotionIn.reversed());
});

// burger__close.addEventListener('click', function(event) {
//     event.preventDefault();
//     console.log("close menu");
//     burgerMotionIn.reversed(!burgerMotionIn.reversed());
// });


// Close navigation en click on items
// for (let i = 0; i < menu__item_a.length; i++) {
//     menu__item_a[i].addEventListener("click", function() {
//         menu__item_a[i].classList.toggle("active");
//         burgerMotionIn.reversed(!burgerMotionIn.reversed());
//     });
// }