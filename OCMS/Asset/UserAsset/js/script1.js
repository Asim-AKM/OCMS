document.addEventListener('DOMContentLoaded', function () {

    function showLoader() {
        document.getElementById('ajaxLoader').classList.remove('d-none');
    }

    function hideLoader() {
        document.getElementById('ajaxLoader').classList.add('d-none');
    }

    // Page fully load hone par hide karo
    window.addEventListener('load', function () {
        hideLoader();
    });

    if (document.readyState === 'complete') {
        hideLoader();
    }

    // Har link click par show karo
    document.addEventListener('click', function (e) {
        var link = e.target.closest('a');
        if (!link) return;

        var href = link.getAttribute('href');
        if (!href || href === '#' || href.startsWith('javascript') || href.startsWith('mailto') || href.startsWith('tel')) return;
        if (link.getAttribute('target') === '_blank') return;
        if (link.hasAttribute('data-bs-dismiss') || link.hasAttribute('data-bs-toggle')) return;
        if (link.hasAttribute('data-dismiss') || link.hasAttribute('data-toggle')) return;

        e.preventDefault();
        showLoader();

        setTimeout(function () {
            window.location.href = href;
        }, 100);
    });

    // Back button par hide karo
    window.addEventListener('pageshow', function () {
        hideLoader();
    });

});

// User dropdown toggle
var userMenuToggle = document.getElementById('userMenuToggle');
var userDropdownMenu = document.getElementById('userDropdownMenu');

if (userMenuToggle && userDropdownMenu) {
    userMenuToggle.addEventListener('click', function (e) {
        e.preventDefault();
        e.stopPropagation();
        var isOpen = userDropdownMenu.classList.contains('open');
        userDropdownMenu.classList.toggle('open', !isOpen);
        userMenuToggle.classList.toggle('open', !isOpen);
    });

    document.addEventListener('click', function (e) {
        if (!userMenuToggle.contains(e.target) && !userDropdownMenu.contains(e.target)) {
            userDropdownMenu.classList.remove('open');
            userMenuToggle.classList.remove('open');
        }
    });
}

