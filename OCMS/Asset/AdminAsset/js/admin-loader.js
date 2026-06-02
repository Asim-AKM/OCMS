        function showTableLoader(containerId, message) {
            var msg = message || 'Loading data...';
            document.getElementById(containerId).innerHTML =
                '<div class="table-loader">' +
                '<div class="spinner"></div>' +
                '<p>' + msg + '</p>' +
                '</div>';
        }
    
        (function () {
            var loader = document.getElementById('adminPageLoader');

            function hideLoader() {
                if (!loader) return;
                loader.classList.add('fade-out');
                setTimeout(function () {
                    loader.classList.add('d-none');
                }, 300);
            }

            window.addEventListener('load', hideLoader);

            if (document.readyState === 'complete') {
                hideLoader();
            }

            window.addEventListener('pageshow', function (e) {
                hideLoader();
            });

            document.addEventListener('click', function (e) {
                var link = e.target.closest('a');
                if (!link) return;

                var href = link.getAttribute('href');
                if (!href) return;
                if (href === '#') return;
                if (href.startsWith('javascript')) return;
                if (href.startsWith('mailto') || href.startsWith('tel')) return;
                if (link.getAttribute('target') === '_blank') return;

                /* Bootstrap 3 modals/dropdowns ignore karo */
                if (link.hasAttribute('data-toggle')) return;
                if (link.hasAttribute('data-dismiss')) return;

                /* AJAX dropdown filters ignore karo */
                if (link.classList.contains('dropdown-item')) return;

                e.preventDefault();
                loader.classList.remove('d-none', 'fade-out');

                setTimeout(function () {
                    window.location.href = href;
                }, 100);
            });
        })();
    