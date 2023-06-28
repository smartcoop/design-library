
import barba from '@barba/core';
import gsap from 'gsap';
import updateBodyClasses from './updateBodyClasses';
import Home from './pages/home';
import Detail from './pages/detail';
import {  animationEnter, animationLeave } from './animations';

barba.init({
	debug: true,
	views: [Home, Detail],
	transitions: [
		{
			name: 'general-transition',
			once: ({ next }) => {
				updateBodyClasses(next);
				animationEnter(next.container);
			},
			leave: ({ current }) => animationLeave(current.container),
			enter: ({ next }) => {
				updateBodyClasses(next);
				animationEnter(next.container);
			}
		},
		{
            name: 'home',
            to: {
				namespace: ['home']
			},
            once: ({ next }) => {
				updateBodyClasses(next);
				animationEnter(next.container);
			},
			leave: ({ current }) => animationLeave(current.container),
            enter: ({ next }) => {
				updateBodyClasses(next);
                animationEnter(next.container);
			},
        },
		{
            name: 'detail',
            to: {
				namespace: ['detail']
			},
            once: ({ next }) => {
				updateBodyClasses(next);
				animationEnter(next.container);
			},
			leave: ({ current }) => animationLeave(current.container),
            enter: ({ next }) => {
				updateBodyClasses(next);
                animationEnter(next.container);
			},
        }
	]
});