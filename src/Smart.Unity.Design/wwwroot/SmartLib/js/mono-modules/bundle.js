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
  Mono dialogs JS 0.4

  * 0.3 "Smart version"
    * Rename to dialog (JR)
  * 0.3 "BT version"
    * Improve closing (Fanny Benisek)
  * 0.2 "TB version"
    * Add query params and push state to URL (Erik Gelderblom)
  * 0.1 "NGD version"
    * Initial version (Simon Wuyts)
   ========================================================================== */

import { isClickOutside } from './util.js';

// Global settings
const dialogClass = 'c-dialog';
const backdropClass = 'c-dialog-backdrop';
const backdropVisibleclass = 'c-dialog-backdrop--visible';
const contextClass = 'c-dialog-context';
const contextVisibleClass = 'c-dialog-context--visible';
const menuActiveClass = '.c-menu--visible';
const queryParams = getQueryParameters();

// DOM elements
const bodyEl = document.querySelector('body');
const dialogTriggers = document.querySelectorAll('[data-dialog]');
const closeButtons = document.querySelectorAll('[data-dialog-close]');
const closeAllButtons = document.querySelectorAll("[data-dialog-close-all]");
let contexts = document.querySelectorAll(`.${contextClass}`);
const dialogs = document.querySelectorAll(`.${dialogClass}`);
let backdrop = document.querySelector(`.${backdropClass}`);


// Check for triggers on page
if (dialogTriggers.length > 0) {
  // Create backdrop if non-existent
  if (backdrop === null) {
    backdrop = document.createElement('div');
    backdrop.classList.add(backdropClass);
    bodyEl.appendChild(backdrop);
  }
}

// Find parent context -- add try-catch to prevent error when class is not found
const findParentContext = function findParentContext(el) {
  let parentEl = el;
  try {
    while (!parentEl.classList.contains(contextClass)) {
      parentEl = parentEl.parentNode;
    }
  }
  catch {
    return null;
  }
  return parentEl;
};

// Open dialog
const showdialog = function showdialog(contextEl) {
  if(contextEl) {
    contextEl.classList.add(contextVisibleClass);
    bodyEl.classList.add("u-kill-scroll");
    backdrop.classList.add(backdropVisibleclass);
  }
  // Push dialog to URL of browser
  window.history.pushState(
    'page',
    'Title',
    `${window.location.origin}${
      window.location.pathname
    }?dialog=${contextEl.getAttribute('id')}`
  );
};

// Close dialog
const closedialog = function closedialog(contextEl) {
  if(contextEl) {
    contextEl.classList.remove(contextVisibleClass);
    bodyEl.classList.remove("u-kill-scroll");
    backdrop.classList.remove(backdropVisibleclass);
  }
  // Push normal URL to browser again
  window.history.pushState(
    'page',
    'Title',
    `${window.location.origin}${window.location.pathname}`
  );
};

// Close all other dialogs in case multiple dialogs are opened after each other
const closedialogs = function closedialogs(contextEl) {
  [...dialogs]
  .filter((dialog) => dialog.parentElement !== contextEl)
   .forEach((dialog) => {
     if (dialog.parentElement.classList.contains(contextVisibleClass)) {
       dialog.parentElement.classList.remove(contextVisibleClass)
       bodyEl.classList.remove("u-kill-scroll");
     }
   }
  );
};

// Handle trigger clicks
const handleTriggerClick = function handleTriggerClick(e) {
  e.preventDefault();
  const contextId = e.currentTarget.getAttribute('data-dialog');
  const contextEl = document.getElementById(contextId);
  closedialogs(contextEl);
  showdialog(contextEl);
};

// Handle close button clicks
const handleCloseClicks = function handleCloseClicks(e) {
  e.preventDefault();
  const contextEl = findParentContext(e.currentTarget);
  closedialog(contextEl);
 };

 // Handle close all button clicks
const handleCloseAllClicks = function handleCloseAllClicks(e) {
  e.preventDefault();
  closedialogs(null);
  const contextEl = findParentContext(e.currentTarget);
  closedialog(contextEl);
};


// Close dialog on click outside
const handleContextClicks = function handleContextClicks(e) {
  const activeContext = document.querySelector(`.${contextVisibleClass}`);
  if (isClickOutside(e, dialogs)) {
    if (!activeContext.querySelector(menuActiveClass))
      closedialog(activeContext);
  }
};

// Close dialog on pressing escape key
const handleEscKey = function handleEscapeKey(e) {
  if (e.keyCode === 27) {
    const activeContext = document.querySelector(`.${contextVisibleClass}`);
    closedialog(activeContext);
  }
};

// Get query parameters to open dialogs if they're in the URL
function getQueryParameters(str) {
  return (str || document.location.search)
    .replace(/(^\?)/, '')
    .split('&')
    .map(
      function (n) {
        return (n = n.split('=')), (this[n[0]] = n[1]), this;
      }.bind({})
    )[0];
}

// If there is a parameter `dialog` in the URL, call that dialog
if (queryParams.dialog) {
  const calldialog = document.getElementById(queryParams.dialog);
  showdialog(calldialog);
}

// Move contexts to root element
contexts.forEach((context) => bodyEl.appendChild(context));

// Add click listener to triggers
dialogTriggers.forEach((dialogTrigger) =>
  dialogTrigger.addEventListener('click', handleTriggerClick, false)
);

// Add click listener to close buttons
closeButtons.forEach((closeButton) =>
  closeButton.addEventListener('click', handleCloseClicks, false)
);

// Add click listener to close buttons for all dialogs
closeAllButtons.forEach((closeAllButton) =>
 closeAllButton.addEventListener("click", handleCloseAllClicks, false)
);

// Add click listener to contexts
contexts.forEach((context) =>
  context.addEventListener('click', handleContextClicks, false)
);

// Add click listener to key press
document.addEventListener('keyup', handleEscKey, false);

/* Accessibility
   ========================================================================== */

// Needs to be reviewed/improved

window.addEventListener('load', function () {
  for (let i = 0; i < dialogs.length; i += 1) {
    focusTrap(dialogs[i]);
  }
});

const focusTrap = function focusTrap(dialog, e) {
  dialog.focusedElBeforeOpen;

  let focusableEls = dialog.querySelectorAll(
    'a[href], area[href], input:not([disabled]), select:not([disabled]), textarea:not([disabled]), button:not([disabled]), [tabindex]:not([tabindex="-1"]'
  );
  dialog.focusableEls = Array.prototype.slice.call(focusableEls);

  dialog.firstFocusableEl = dialog.focusableEls[0];
  dialog.lastFocusableEl = dialog.focusableEls[dialog.focusableEls.length - 1];
  dialog.firstFocusableEl.focus();

  function handleKeyDown(e) {
    const KEY_TAB = 9;

    function handleBackwardTab() {
      if (document.activeElement === dialog.firstFocusableEl) {
        e.preventDefault();
        dialog.lastFocusableEl.focus();
      }
    }

    function handleForwardTab() {
      if (document.activeElement === dialog.lastFocusableEl) {
        e.preventDefault();
        dialog.firstFocusableEl.focus();
      }
    }

    switch (e.keyCode) {
      case KEY_TAB:
        if (dialog.focusableEls.length === 1) {
          e.preventDefault();
          break;
        }
        if (e.shiftKey) {
          handleBackwardTab();
        } else {
          handleForwardTab();
        }
        break;
      default:
        break;
    }
  }

  dialog.addEventListener('keydown', handleKeyDown, false);
};
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

import { createPopper, preventOverflow } from '@popperjs/core';
import { isClickOutside } from './util';

/* Menu JS
========================================================================== */

// Collect all triggers on the page except for the sidebar
const menuTriggers = document.querySelectorAll('[data-menu]:not(.js-no-action)');
const selectOptions = document.querySelectorAll('[role="option"]');

// Global settings
const menuActiveClass = 'c-menu--visible';
var menuButtonActiveClass = 'c-menu-button-active';
const dropdownMargin = 6;
let popperInstances = [];

// Find target dropdown element
const findDropdown = (triggerEl) => {
  const targetId = triggerEl.getAttribute('data-menu');
  return document.getElementById(targetId);
};

// find Select for clicked option
const findSelect = (element) => {
  return document.querySelector(`[data-menu="${element.parentElement.id}`);
};

// Position dropdown
function create(triggerEl, targetEl) {
  const placement = triggerEl.dataset.menuPlacement || 'bottom-end';
  const samewidthEnable = !!triggerEl.dataset.menuSamewidth || false;
  const offset = triggerEl.dataset.menuOffset || dropdownMargin;
  
  let popperInstance = new createPopper(triggerEl, targetEl, {
    placement,
    modifiers: [
      preventOverflow,
      {
        name: 'offset',
        options: {
          offset: [8, offset],
        },
      },
      {
        name: 'sameWidth',
        enabled: samewidthEnable,
        phase: 'beforeWrite',
        requires: ['computeStyles'],
        fn: ({ state }) => {
          state.styles.popper.width = `${state.rects.reference.width}px`;
        },
        effect: ({ state }) => {
          state.elements.popper.style.width = `${state.elements.reference.offsetWidth}px`;
        },
      },
    ],
  });
  
  popperInstances.push(popperInstance);
  
  
}

function showPopper(trigger, targetEl) {
  create(trigger, targetEl);
  trigger.classList.add(menuButtonActiveClass)
  targetEl.setAttribute('data-show', '');
  targetEl.classList.add(menuActiveClass);
}

function hidePopper(instance) {
  const popper = instance.state.elements.popper;
  var reference = instance.state.elements.reference;
  reference.classList.remove(menuButtonActiveClass);
  popper.removeAttribute('data-show');
  popper.classList.remove(menuActiveClass);
  destroy(instance);
}

function destroy(target) {
  const instance = popperInstances.find((instance) => instance === target);
  if (instance) {
    instance.destroy();
    popperInstances.splice(popperInstances.indexOf(target), 1);
  }
}

const findPopperInstance = (target) => popperInstances.find(
  (instance) =>
    instance.state.elements.popper === document.getElementById(target)
  ); // Add or remove classes on clicking a trigger

  const handleClick = (event) => {  
    // Detect if we are clicking another menu
    // if (event.target.dataset.menu) {
    //   [...popperInstances].map((instance) => {
    //     hidePopper(instance);
    //   });
    // }
    
    event.stopPropagation();
    const trigger = event.currentTarget;
    const targetEl = findDropdown(trigger);
    const instance = findPopperInstance(targetEl.id);
    
    if (!instance) {
      showPopper(trigger, targetEl);
    } else {
      hidePopper(instance);
    }
    
    if(popperInstances.length > 1) {
      hidePopper(popperInstances[0]);
    }
  };
  
  // Custom select
  const handleSelectClick = (event) => {
    const selectedItem = event.currentTarget
    .querySelector('.c-menu__label')
    .cloneNode(true);
    
    const targetSelect = findSelect(event.currentTarget);
    const previousItem = targetSelect.querySelector('.c-select-custom__value');
    
    selectedItem.classList.replace('c-menu__label', 'c-select-custom__value');
    previousItem.parentNode.replaceChild(selectedItem, previousItem);
    let popper = findPopperInstance(targetSelect.dataset.menu);
    popper.state.elements.popper.removeAttribute('data-show');
    popper.state.elements.popper.classList.remove(menuActiveClass);
    destroy(popper);
  };
  
  // Hide all menus when clicking outside
  const handleOutsideClick = (event) => {
    if (!popperInstances.length) return;
    
    event.stopImmediatePropagation();
    
    const poppers = popperInstances.map(
      (instance) => instance.state.elements.popper
      );
      
      if (isClickOutside(event, [...poppers]))
      [...popperInstances].map((instance) => {
        hidePopper(instance);
      });
    };
    
    // Loop through all triggers on the page
    // Attach event listeners
    menuTriggers.forEach((trigger) =>
    trigger.addEventListener('click', handleClick)
    );
    
    // Custom select code
    // Attach event listeners
    selectOptions.forEach((option) =>
    option.addEventListener('click', handleSelectClick)
    );
    
    // Add click listener on outside
    document.addEventListener('click', handleOutsideClick);
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
import { createPopper } from '@popperjs/core';
import { isClickOutside } from './util';

// Collect all triggers on the page
const popoverTriggers = document.querySelectorAll('[data-popover]');

// Global settings
const popoverMargin = '16';

let popoverOpen = false;
let targetEl;
let openPopover;
let popoverId;
let popoverTrigger;

// Find target popover element
function findpopover(triggerEl) {
  const targetId = triggerEl.getAttribute('data-popover');
  return document.getElementById(targetId);
}

let popperInstance = null;

function create(triggerEl, targetEl) {
  const placement = triggerEl.getAttribute('data-popover-placement') || 'top';

  popperInstance = createPopper(triggerEl, targetEl, {
    placement: placement,
    modifiers: [
      {
        name: 'offset',
        options: {
          offset: [0, popoverMargin],
        },
      },
      {
        name: 'arrow',
        options: {
          padding: 4, // 4px from the edges of the popper
        },
      },
    ],
  });
}

function destroy() {
  if (popperInstance) {
    popperInstance.destroy();
    popperInstance = null;
  }
}

function togglePopover(e) {
  if (popoverOpen) {
    openPopover = document.querySelector('.c-popover[data-show]');
    popoverId = openPopover.getAttribute('id');
    popoverTrigger = document.querySelector(`[data-popover='${popoverId}']`);
  }
  if (openPopover && popoverTrigger && e.currentTarget !== popoverTrigger) {
    openPopover.removeAttribute('data-show');
    destroy();
    targetEl = findpopover(e.currentTarget);
    targetEl.setAttribute('data-show', '');
    create(e.currentTarget, targetEl);
    popoverOpen = true;
  } else {
    targetEl = findpopover(e.currentTarget);
    popoverOpen = !popoverOpen;
    if (popoverOpen) {
      create(e.currentTarget, targetEl);
      targetEl.setAttribute('data-show', '');
    } else {
      destroy();
      targetEl.removeAttribute('data-show');
    }
  }
}

popoverTriggers.forEach((trigger) =>
  trigger.addEventListener('click', togglePopover)
);

document.addEventListener('click', function (e) {
  if (popoverOpen) {
    openPopover = document.querySelector('.c-popover[data-show]');
    popoverId = openPopover.getAttribute('id');
    popoverTrigger = document.querySelector(`[data-popover='${popoverId}']`);
  }
  if (
    popoverOpen &&
    openPopover &&
    popoverTrigger &&
    isClickOutside(e, [popoverTrigger, openPopover])
  ) {
    popoverOpen = false;
    openPopover.removeAttribute('data-show');
    destroy();
  }
});

import { createPopper } from '@popperjs/core';

// Collect all triggers on the page
const tooltipTriggers = document.querySelectorAll('[data-tooltip]');
const tooltips = document.querySelectorAll('.c-tooltip');

// Global settings
const tooltipMargin = '16';

const showEvents = ['mouseenter', 'focus'];
const hideEvents = ['mouseleave', 'blur'];

for (let i = 0; i < tooltipTriggers.length; i += 1) {
  // Attach event listeners
  showEvents.forEach(event => {
    tooltipTriggers[i].addEventListener(event, show);
  });
  hideEvents.forEach(event => {
    tooltipTriggers[i].addEventListener(event, hide);
  });
}

// Find target tooltip element
function findTooltip(triggerEl) {
  const targetId = triggerEl.getAttribute('data-tooltip');
  return document.getElementById(targetId);
};

let popperInstance = null;

function create(triggerEl, targetEl) {
  const placement = triggerEl.getAttribute('data-tooltip-placement') || 'top';
  popperInstance = createPopper(triggerEl, targetEl, {
    placement: placement,
    modifiers: [
      {
        name: 'offset',
        options: {
          offset: [0, tooltipMargin],
        },
      },
      {
        name: 'arrow',
        options: {
          padding: 4, // 4px from the edges of the popper
        },
      },
    ],
  });
}

function destroy() {
  if (popperInstance) {
    popperInstance.destroy();
    popperInstance = null;
  }
}

function show(e) {
  const targetEl = findTooltip(e.currentTarget);
  targetEl.setAttribute('data-show', '');
  create(e.currentTarget, targetEl);
}

function hide(e) {
  const targetEl = findTooltip(e.currentTarget);
  targetEl.removeAttribute('data-show');
  destroy();
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
