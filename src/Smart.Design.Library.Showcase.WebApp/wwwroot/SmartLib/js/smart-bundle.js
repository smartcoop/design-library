/* Accordion
   ========================================================================== */

var headersAcc = document.querySelectorAll('.c-accordion .c-accordion__item .c-accordion__item-header');

for(var i = 0; i < headersAcc.length; i++) {
  headersAcc[i].addEventListener('click', openCurrAcc);
}

//Use this as the callback if you would like multiple dropdowns to be open
function openAcc(e) {
  var parent = this.parentElement;
  var article = this.nextElementSibling;
  
  if (!parent.classList.contains('js-active')) {
    parent.classList.add('js-active');
    article.style.maxHeight = article.scrollHeight + 'px';
  }
  else {
    parent.classList.remove('js-active');
    article.style.maxHeight = '0px';
  }
}

//Use this as the callback if you would like no more than one dropdown to be open
function openCurrAcc(e) {
  for(var i = 0; i < headersAcc.length; i++) {
    var parent = headersAcc[i].parentElement;
    var article = headersAcc[i].nextElementSibling;

    if (this === headersAcc[i] && !parent.classList.contains('js-active')) {
      parent.classList.add('js-active');
      article.style.maxHeight = article.scrollHeight + 'px';
    }
    else {
      parent.classList.remove('js-active');
      article.style.maxHeight = '0px';
    }
  }
}

/* alert JS
   ========================================================================== */

 class CloseAlert {
  constructor(alert) {
      this.alertClass = alert;
      this.closeButton = alert.querySelector('[data-alert-close]');
      this.init();
  }

  init() {
    const parentClassScope = this;
    this.closeButton.addEventListener('click', function(e){
      parentClassScope.alertClass.remove();
    });
  }
}

const closableAlerts = document.querySelectorAll('[data-alert-closable]');

if (closableAlerts.length) {
  [...closableAlerts].map((closableAlertsWithClick) => new CloseAlert(closableAlertsWithClick));
}

/* banner JS
   ========================================================================== */

class CloseBanner {
  constructor(banner) {
      this.bannerClass = banner;
      this.closeIcon = banner.querySelector('[data-banner-close]');
      this.changeHeightClass = document.querySelector('.js-has-global-banner');
      this.init();
  }

  init() {
    const parentClassScope = this;
    this.closeIcon.addEventListener('click', function(e){
      parentClassScope.bannerClass.remove();
      if (parentClassScope.changeHeightClass != null) {
        parentClassScope.changeHeightClass.classList.remove('js-has-global-banner');
      }
    });
  }
}

const closablebanners = document.querySelectorAll('.c-global-banner');

if (closablebanners.length) {
  [...closablebanners].map((closablebannersWithClick) => new CloseBanner(closablebannersWithClick));
}
/* Copy btn JS
   ========================================================================== */

class CopyBtn {
  constructor(btn) {
    this.btn = btn;
    
    var copy_trad = this.btn.getAttribute('data-action-trad');
    var target__el = document.querySelector(this.btn.getAttribute('data-copy-content'));
    var target__el__content = target__el.innerHTML;
    
    this.btn.addEventListener('click', myFunc, false);
    this.btn.myBtn = this.btn;

    function myFunc(evt) {
      var tooltipContent = evt.currentTarget.myBtn.nextElementSibling.querySelector("span");
      navigator.clipboard.writeText(target__el__content).then(function(x) {
        tooltipContent.innerHTML = target__el__content + " "  + copy_trad;
      });
    }
  }
}

const copyBtns = document.querySelectorAll("[data-action='copy']");

if (copyBtns.length) {
  [...copyBtns].map((copyBtnsWithClick) => new CopyBtn(copyBtnsWithClick));
}
/* ==========================================================================
  Mobile menu
   ========================================================================== */

const htmlElement = document.querySelector('html');
const mobileNavigationOpenButton = document.querySelector('#c-design-system-nav-open');
const mobileNavigationCloseButton = document.querySelector('#c-design-system-nav-close');
const mobileMenu = document.querySelector('.c-design-system-nav__mobile');

const handleMenuOpen = function handleMenuOpen(e) {
  e.preventDefault();
  mobileMenu.classList.add('c-design-system-nav__mobile--visible');
  htmlElement.classList.add('u-kill-scroll');
}

const handleMenuClose = function handleMenuClose(e) {
  e.preventDefault();
  mobileMenu.classList.remove('c-design-system-nav__mobile--visible');
  htmlElement.classList.remove('u-kill-scroll');
}

mobileNavigationOpenButton && mobileNavigationOpenButton.addEventListener('click', handleMenuOpen, false);
mobileNavigationCloseButton && mobileNavigationCloseButton.addEventListener('click', handleMenuClose, false);

/* ==========================================================================
  Input password (view password) toggle
   ========================================================================== */

class InputPassword {
  constructor(el) {
    this.el = el;
    this.button = el.parentElement.querySelector(
      "button[data-password-toggle]"
      );
    this.button.addEventListener("click", function(event) {
      this.el = this.parentElement.querySelector("input");
      if (this.el.type === "password") {
        this.el.type = "text";
      } else {
        this.el.type = "password";
      }
    });
  }
}

const passwordsInputs = document.querySelectorAll("input[type=password]");

if (passwordsInputs.length) {
  [...passwordsInputs].map((input) => new InputPassword(input));
}

/* Navbar components
   ========================================================================== */

var headers = document.querySelectorAll('.c-navbar-components .c-navbar-components__header');

for(var i = 0; i < headers.length; i++) {
	headers[i].addEventListener('click', openCurrNavbar);
}

//Use this as the callback if you would like multiple dropdowns to be open
function openNavbar(e) {
	var parent = this.parentElement;
	var article = this.nextElementSibling;
	
	if (!parent.classList.contains('js-active')) {
		parent.classList.add('js-active');
		article.style.maxHeight = article.scrollHeight + 'px';
	}
	else {
		parent.classList.remove('js-active');
		article.style.maxHeight = '0px';
	}
}

//Use this as the callback if you would like no more than one dropdown to be open
function openCurrNavbar(e) {
	for(var i = 0; i < headers.length; i++) {
		var parent = headers[i].parentElement;
		var article = headers[i].nextElementSibling;

		if (this === headers[i] && !parent.classList.contains('js-active')) {
			parent.classList.add('js-active');
			article.style.maxHeight = article.scrollHeight + 'px';
		}
		else {
			parent.classList.remove('js-active');
			article.style.maxHeight = '0px';
		}
	}
}
/* JS adapted from https://inclusive-components.design/tabbed-interfaces/ */
class Tabs {
  constructor(el) {
    this.el = el;
    this.tablist = this.el.querySelector("ul");
    this.tabs = this.el.querySelectorAll("a.c-tabs__item");
    this.panels = this.el.querySelectorAll(".c-tabs__section");

    this.init();
  }

  init() {
    // Add the tablist role to the first <ul> in the .tabbed container
    this.tablist.setAttribute("role", "tablist");

    // Add semantics and remove user focusability for each tab
    this.tabs.forEach((tab, i) => {
      tab.setAttribute("role", "tab");
      tab.setAttribute("id", "tab" + (i + 1));
      tab.setAttribute("tabindex", "-1");
      tab.parentNode.setAttribute("role", "presentation");

      // Attach events to the tabs if the tabs have panels. Otherwise they just act as links
      if (this.panels.length) this.attachEvents(tab, i);
    });

    // Add tab panel semantics and hide them all
    this.panels.forEach((panel, i) => {
      panel.setAttribute("role", "tabpanel");
      panel.setAttribute("tabindex", "-1");
      panel.setAttribute("aria-labelledby", this.tabs[i].id);
      panel.hidden = true;
    });

    // Initially activate the first tab and reveal the first tab panel
    if (this.panels[0]) {
      this.tabs[0].removeAttribute("tabindex");
      this.tabs[0].setAttribute("aria-selected", "true");
      this.panels[0].hidden = false;
    }
  }

  attachEvents(tab) {
    // Handle clicking of tabs for mouse users
    tab.addEventListener("click", (e) => {
      e.preventDefault();
      let currentTab = this.tablist.querySelector("[aria-selected]");
      if (e.currentTarget !== currentTab) {
        this.switchTab(currentTab, e.currentTarget);
      }
    });

    // Handle keydown events for keyboard users
    tab.addEventListener("keydown", (e) => {
      // Get the index of the current tab in the tabs node list
      let index = [...this.tabs].indexOf(e.currentTarget);

      // Work out which key the user is pressing and
      // Calculate the new tab's index where appropriate
      let dir =
        e.which === 37
          ? index - 1
          : e.which === 39
          ? index + 1
          : e.which === 40
          ? "down"
          : null;

      if (dir !== null) {
        e.preventDefault();
        // If the down key is pressed, move focus to the open panel,
        // otherwise switch to the adjacent tab
        dir === "down"
          ? this.panels[index].focus()
          : this.tabs[dir]
          ? this.switchTab(e.currentTarget, this.tabs[dir])
          : void 0;
      }
    });
  }

  switchTab(oldTab, newTab) {
    newTab.focus();
    // Make the active tab focusable by the user (Tab key)
    newTab.removeAttribute("tabindex");
    // Set the selected state
    newTab.setAttribute("aria-selected", "true");
    oldTab.removeAttribute("aria-selected");
    oldTab.setAttribute("tabindex", "-1");
    // Get the indices of the new and old tabs to find the correct
    // tab panels to show and hide
    let index = [...this.tabs].indexOf(newTab);
    let oldIndex = [...this.tabs].indexOf(oldTab);
    if (this.panels[oldIndex]) this.panels[oldIndex].hidden = true;
    if (this.panels[index]) this.panels[index].hidden = false;
  }
}

const tablists = document.querySelectorAll(".c-tabs");

if (tablists.length) {
  [...tablists].map((tablist) => new Tabs(tablist));
}

// Check if click is outside element
const isClickOutside = (event, elements) => {
  const excludedElements =
    elements.forEach === undefined ? [elements] : elements;
  let target = event.target;
  let isOutside = true;

  do {
    excludedElements.forEach((excludedElement) => {
      // this is a click inside
      if (target === excludedElement) {
        isOutside = false;
      }
    });
    // traverse upwards
    target = target.parentNode;
  } while (target);

  return isOutside;
};

export { isClickOutside };

class SwitchViewButton {
  constructor(els) {
      this.els = els;
      this.init();
    }
    
    init() {
      this.els.forEach((el, i) => {
        // Attach events
        el.addEventListener("click", (e) => {
            var target__el = document.querySelector('.' + el.getAttribute('data-switch-target') );
            if(el.getAttribute('data-switch-target') === el.getAttribute('data-toggle')){
              // This way you can remove the target classname of the element you are targeting
              target__el.classList.remove(el.getAttribute('data-toggle'));
            }else if(el.getAttribute('data-toggle') === "disabled"){
              this.toggleAttribute(target__el, "disabled");
            }else{
              e.preventDefault();
              this.toggleClass(target__el, ( el.getAttribute('data-switch-target') + '--' + el.getAttribute('data-toggle')));
              this.els.forEach((il) => {
                  this.toggleClass(il, "c-button--secondary");
                  this.toggleClass(il, "c-button--primary");
              });
            }

          });
      });
     
  }

  toggleClass(target, toggleClass){
      target.classList.toggle(toggleClass);
  }
  
  toggleAttribute(target, attribute){
      if (target.hasAttribute(attribute)) {
          target.removeAttribute(attribute) 
      }else{
          target.setAttribute(attribute, "");
      }
  }

}

const switchViewButtons = document.querySelectorAll("[data-toggle]");

if (switchViewButtons.length) {
  new SwitchViewButton(switchViewButtons);
}

class ScrollToLink {
  constructor(els) {
      this.els = els;
      this.target__el = document.querySelector('.' + this.els[0].getAttribute('data-scroll-target-id') );
      this.init();
  }

  init() {
      this.els.forEach((el, i) => {
          // Attach events
          el.addEventListener("click", (e) => {
            e.preventDefault();
            var scrollToElement = document.querySelector('#' + el.getAttribute("data-scroll-target-id"));
            this.scrollTo(scrollToElement)
          });
      });
     
  }

  scrollTo(element) {
    window.scrollTo({
        top:  element.offsetTop,
        behavior: "smooth"
    });
  }

}

const ScrollToLinks = document.querySelectorAll("[data-scroll-to]");

if (ScrollToLinks.length) {
  new ScrollToLink(ScrollToLinks);
}
