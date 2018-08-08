// This is separate to the Redgate.com JavaScript bundle because it's used
// on other sites/apps (Forums, Simple Talk) as part of the Community Hub project.
//
// This script makes the primary nav collapse, and the mobile menu toggle
// when the menu in the nav-bar is clicked.

var Redgate = Redgate || {};
Redgate.Hub = Redgate.Hub || {};
Redgate.Hub.Nav = (function() {

    var isHubSubPage = function isHubSubPage () {

        // If the Redgate.Hub.isHubSubPage property is set externally,
        // then use that.
        if (typeof Redgate.Hub.isHubSubPage !== 'undefined') {
            return Redgate.Hub.isHubSubPage;
        }

        var pathname = window.location.pathname;

        if (pathname.charAt(0) === '/') {
            pathname = pathname.substr(1);
        }

        if (pathname.charAt(pathname.length - 1) === '/') {
            pathname = pathname.slice(0, -1);
        }

        var pieces = pathname.split('/');
        if (pieces.length > 1 && pieces[0] !== '') {
            if (pieces[0] === 'hub') {
                return true;
            }
        }

        return false;
    };

    var highlightSection = function highlightSection () {
        // if we're inside /hub/product-learning or /hub/events, add active state to nav item
        var sections = ['events', 'product-learning'];

        for (var i = 0; i < sections.length; i++) {
            var section = sections[i];
            if (window.location.pathname.indexOf('/hub/' + section) === 0) {
                var $sectionAnchor = $('.nav-bar--dark a[href$="/hub/' + section + '/"]');
                $sectionAnchor.parent().addClass('active');
            }
        }
    };

    var isMobile = function isMobile () {
        var mobileMenuButton = document.querySelector('.header--primary__menu-button');
        return mobileMenuButton.offsetHeight;
    };

    var togglePrimaryNav = function togglePrimaryNav () {
        var collapsedClassName = 'header--primary--collapsed';
        var header = document.querySelector('.js-header-primary-collapse');
        var hubNav = document.querySelector('.nav-bar--dark');
        var menuButton = document.querySelector('.nav-bar__menu-button');

        if (!header || !hubNav) return false;

        if (header.className.match(collapsedClassName) !== null) {
            // reveal
            header.className = header.className.replace(collapsedClassName, '');

            if (menuButton) {
                menuButton.innerHTML = '';
                menuButton.className = (menuButton.className + ' icon--chevron-up').replace('icon--chevron-down', '');
            }

            $('.header__account').css('display', 'inline-block');
        } else {
            // collapse
            header.className = header.className + ' ' + collapsedClassName;

            if (menuButton) {
                menuButton.className = menuButton.className.replace('icon--chevron-up', '') + ' icon--chevron-down';
            }

            $('.header__account').css('display', 'none');
        }
    };

    var toggleMobileMenu = function toggleMobileMenu () {
        var mobileMenuBodyClass = 'mobile-nav--open';

        if (document.body.className.match(mobileMenuBodyClass) !== null) {
            document.body.className = document.body.className.replace(mobileMenuBodyClass, '');
        } else {
            document.body.className = document.body.className + ' ' + mobileMenuBodyClass;
        }
    };

    var toggle = function collapse () {
        if (isMobile()) {
            toggleMobileMenu();
        } else {
            togglePrimaryNav();
        }
    };

    var addHandler = function addHandler () {
        var menuButton = document.querySelector('.nav-bar__menu-button');
        if (!menuButton) return false;

        menuButton.addEventListener('click', function (e) {
            e.preventDefault();
            toggle();
        });
    };

    var init = function init () {
        if (isHubSubPage()) {
            togglePrimaryNav();
            highlightSection();
        }

        addHandler();
    };

    return {
        init: init
    };
})();

window.addEventListener('load', Redgate.Hub.Nav.init);