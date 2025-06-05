// ────────────── PARALLAX & SCROLL ANIMATIONS ──────────────
function handleParallax() {
    const scrollPosition = window.pageYOffset;

    /* Hero image parallax */
    const heroImage = document.querySelector('.hero-image');
    if (heroImage) {
        heroImage.style.transform = `scale(1.1) translateY(${scrollPosition * 0.1}px)`;
    }

    /* Lookbook parallax */
    const lookbookBg = document.querySelector('#lookbook .bg-fixed');
    if (lookbookBg) {
        lookbookBg.style.backgroundPositionY = `${-scrollPosition * 0.2}px`;
    }

    /* Fade-in animacje kart */
    const animateElements = document.querySelectorAll('.product-card, .category-card');
    animateElements.forEach((el) => {
        const elementPosition = el.getBoundingClientRect().top;
        const windowHeight    = window.innerHeight;
        if (elementPosition < windowHeight * 0.8) {
            el.classList.add('animate-fade-in');
        }
    });
}

window.addEventListener('scroll', handleParallax);

// ────────────── DOMContentLoaded ──────────────
document.addEventListener('DOMContentLoaded', () => {
    handleParallax();

    /* Smooth scroll dla kotwic */
    document.querySelectorAll('a[href^="#"]').forEach((anchor) => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            const targetId = this.getAttribute('href');
            if (targetId === '#') return;
            const targetEl = document.querySelector(targetId);
            if (targetEl) {
                targetEl.scrollIntoView({ behavior: 'smooth' });
            }
        });
    });

    /* Dodawanie do koszyka */
    document.querySelectorAll('.add-to-cart-btn').forEach((btn) => {
        btn.addEventListener('click', async (e) => {
            e.preventDefault();
            const id = btn.dataset.productId;
            if (!id) return;

            await fetch('/Cart/Add', {
                method: 'POST',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                body: `productId=${id}&quantity=1`
            });

            window.location.href = '/Cart';
        });
    });

    /* ────────────── SEARCH OVERLAY (nowość) ────────────── */
    const searchIcon  = document.getElementById('search-icon');
    const overlay     = document.getElementById('search-overlay');
    const searchInput = overlay ? overlay.querySelector('input[name="q"]') : null;

    if (searchIcon && overlay && searchInput) {
        /* otwarcie */
        searchIcon.addEventListener('click', (e) => {
            e.preventDefault();
            overlay.classList.remove('hidden');
            searchInput.focus();
        });

        /* zamknięcie kliknięciem poza box-em */
        overlay.addEventListener('click', (e) => {
            if (e.target === overlay) {
                overlay.classList.add('hidden');
            }
        });
    }
});
