function handleParallax() {
    const scrollPosition = window.pageYOffset;

    const heroImage = document.querySelector('.hero-image');
    if (heroImage)
        heroImage.style.transform = `scale(1.1) translateY(${scrollPosition * 0.1}px)`;

    const lookbookBg = document.querySelector('#lookbook .bg-fixed');
    if (lookbookBg)
        lookbookBg.style.backgroundPositionY = `${-scrollPosition * 0.2}px`;

    document.querySelectorAll('.product-card, .category-card').forEach((el) => {
        const elementPosition = el.getBoundingClientRect().top;
        const windowHeight    = window.innerHeight;

        if (elementPosition < windowHeight * 0.8)
            el.classList.add('animate-fade-in');
    });
}

window.addEventListener('scroll', handleParallax);

document.addEventListener('DOMContentLoaded', () => {
    handleParallax();

    document.querySelectorAll('a[href^="#"]').forEach((anchor) => {
        anchor.addEventListener('click', (e) => {
            e.preventDefault();
            const targetId = anchor.getAttribute('href');
            if (targetId === '#') return;
            const targetEl = document.querySelector(targetId);
            if (targetEl) targetEl.scrollIntoView({ behavior: 'smooth' });
        });
    });

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

    const searchIcon  = document.getElementById('search-icon');
    const overlay     = document.getElementById('search-overlay');
    const searchInput = overlay ? overlay.querySelector('input[name="q"]') : null;

    if (searchIcon && overlay && searchInput) {
        searchIcon.addEventListener('click', (e) => {
            e.preventDefault();
            overlay.classList.remove('hidden');
            searchInput.focus();
        });

        overlay.addEventListener('click', (e) => {
            if (e.target === overlay) overlay.classList.add('hidden');
        });
        document.addEventListener('keydown', (e) => {
            if (e.key === 'Escape') overlay.classList.add('hidden');
        });
    }
});
