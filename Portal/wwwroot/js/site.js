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
})
