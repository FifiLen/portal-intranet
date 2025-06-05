// Funkcja do obsługi efektu parallax
function handleParallax() {
    const scrollPosition = window.pageYOffset

    // Efekt parallax dla hero image
    const heroImage = document.querySelector(".hero-image")
    if (heroImage) {
        heroImage.style.transform = `scale(1.1) translateY(${scrollPosition * 0.1}px)`
    }

    // Efekt parallax dla lookbook sekcji
    const lookbookBg = document.querySelector("#lookbook .bg-fixed")
    if (lookbookBg) {
        lookbookBg.style.backgroundPositionY = `${-scrollPosition * 0.2}px`
    }

    // Animacje przy przewijaniu
    const animateElements = document.querySelectorAll(".product-card, .category-card")
    animateElements.forEach((element) => {
        const elementPosition = element.getBoundingClientRect().top
        const windowHeight = window.innerHeight

        if (elementPosition < windowHeight * 0.8) {
            element.classList.add("animate-fade-in")
        }
    })
}

// Nasłuchiwanie na przewijanie strony
window.addEventListener("scroll", handleParallax)

// Inicjalizacja po załadowaniu strony
document.addEventListener("DOMContentLoaded", () => {
    handleParallax()

    // Obsługa płynnego przewijania dla linków kotwicznych
    document.querySelectorAll('a[href^="#"]').forEach((anchor) => {
        anchor.addEventListener("click", function (e) {
            e.preventDefault()

            const targetId = this.getAttribute("href")
            if (targetId === "#") return

            const targetElement = document.querySelector(targetId)
            if (targetElement) {
                targetElement.scrollIntoView({
                    behavior: "smooth",
                })
            }
        })
    })

    // Dodawanie produktów do koszyka
    document.querySelectorAll('.add-to-cart-btn').forEach((btn) => {
        btn.addEventListener('click', async (e) => {
            e.preventDefault()
            const id = btn.getAttribute('data-product-id')
            if (!id) return
            await fetch('/Cart/Add', {
                method: 'POST',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                body: `productId=${id}&quantity=1`
            })
            window.location.href = '/Cart'
        })
    })

    // Search overlay
    const searchIcon = document.getElementById('search-icon')
    const overlay = document.getElementById('search-overlay')
    const searchInput = overlay ? overlay.querySelector('input[name="q"]') : null
    if (searchIcon && overlay && searchInput) {
        searchIcon.addEventListener('click', (e) => {
            e.preventDefault()
            overlay.classList.remove('hidden')
            searchInput.focus()
        })
        overlay.addEventListener('click', (e) => {
            if (e.target === overlay) overlay.classList.add('hidden')
        })
    }
})
