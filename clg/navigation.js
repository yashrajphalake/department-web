
document.addEventListener("DOMContentLoaded", function() {
    const menuBtn = document.getElementById("menuBtn");
    const sidebar = document.getElementById("sidebar");

    if (menuBtn && sidebar) {
        menuBtn.addEventListener("click", function() {
            sidebar.classList.toggle("collapsed");
        });
    }

    const currentPath = window.location.pathname.split("/").pop();
    const menuLinks = document.querySelectorAll(".menu a");

    menuLinks.forEach(link => {
        if (link.getAttribute("href") === currentPath) {
            link.classList.add("active");
        } else {
            link.classList.remove("active");
        }
    });
});
