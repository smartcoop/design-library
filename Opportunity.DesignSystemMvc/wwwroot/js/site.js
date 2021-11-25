// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


customElements.define('smart-accordion-html',
    class extends HTMLElement {
        constructor() {
            super();
            let template = document.getElementById('smart-accordion-html');
            let templateContent = template.content;

            const shadowRoot = this.attachShadow({mode: 'open'})
                .appendChild(templateContent.cloneNode(true));
        }
    }
);
