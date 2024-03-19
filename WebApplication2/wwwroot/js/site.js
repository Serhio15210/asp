const menuState = {
    isOpen: false
};

function toggleMenu() {
    menuState.isOpen = !menuState.isOpen;
    updateMenuState();
}
function updateMenuState() {
    const mobileMenu = document.querySelector('.mobileMenu');
    if (menuState.isOpen) {
        mobileMenu.classList.add('active');
    } else {
        mobileMenu.classList.remove('active');
    }
}