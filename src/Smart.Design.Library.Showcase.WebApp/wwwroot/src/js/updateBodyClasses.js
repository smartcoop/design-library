const updateBodyClasses = (next) => {
	var body = document.querySelector('body');
    if(next.container.getAttribute('data-page-body-class')){
        var pageClass = next.container.getAttribute('data-page-body-class');
    }else{
        var pageClass = next.container.getAttribute('data-barba-namespace');
    }
    body.className = '';
    body.classList.add(pageClass);
    body.classList.add(next.container.getAttribute('data-theme'));
}

export default updateBodyClasses;