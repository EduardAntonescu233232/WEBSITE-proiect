function plusSlides(n, currentSlide) {
    var gallery = currentSlide.closest(".image-gallery");
    showSlides(getCurrentSlideIndex(currentSlide) + n, gallery);
}

function showSlides(n, gallery) {
    var slides = gallery.getElementsByClassName("Modelling-image");

    for (var i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }

    n = (n + slides.length) % slides.length;

    slides[n].style.display = "block";
}

function getCurrentSlideIndex(currentSlide) {
    var slides = currentSlide.closest(".image-gallery").getElementsByClassName("Modelling-image");

    for (var i = 0; i < slides.length; i++) {
        if (slides[i].style.display === "block") {
            return i;
        }
    }

    return 0;
}

document.querySelectorAll('.image-gallery').forEach(function (gallery) {
    showSlides(0, gallery);
});
