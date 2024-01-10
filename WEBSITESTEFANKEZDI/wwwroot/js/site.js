const navSlide = () => {
    const burger = document.querySelector('.burger');
    const mainnav = document.querySelector('.mainnav');
    const sessionUsername = document.getElementById("session-data").getAttribute("data-username");

    burger.addEventListener('click', () => {
        burger.classList.toggle('burger-active');
        if (sessionUsername === "Stefan") {
            mainnav.classList.toggle('mainnav-active-admin');
        } else {
            mainnav.classList.toggle('mainnav-active');
        } 
    });

    document.addEventListener('click', () => {
        if (!event.target.closest('.burger') && !event.target.closest('.mainnav') && !event.target.closest('.header') && mainnav.classList.contains('mainnav-active')) {
            mainnav.classList.remove('mainnav-active');
            burger.classList.remove('burger-active');
        }
    });

}

navSlide();



function changeNavbarText(mq) {
    const contactLink = document.querySelector('.navbar-brand');
    const baseUrl = window.location.origin;
    if (contactLink) {
        if (mq.matches) {
            contactLink.textContent = 'Overview';
            contactLink.href = baseUrl + "/Home/Index";
        } else {
            contactLink.textContent = 'Stefan David Kezdi';
            contactLink.href = baseUrl + "/Home/About";
        }
    }
}


const mediaQuery = window.matchMedia('(max-width: 1280px)');
changeNavbarText(mediaQuery);

mediaQuery.addEventListener('change', () => {
    changeNavbarText(mediaQuery);
});





