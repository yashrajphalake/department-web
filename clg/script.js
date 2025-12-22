
document.addEventListener('DOMContentLoaded', () => {
    const menuBtn = document.getElementById('menuBtn');
    const sidebar = document.getElementById('sidebar') || document.querySelector('.sidebar');

    if (menuBtn && sidebar) {
        menuBtn.addEventListener('click', (e) => {
            e.stopPropagation();
            if (window.innerWidth <= 768) {
                sidebar.classList.toggle('active'); // Mobile slide-in
            } else {
                sidebar.classList.toggle('collapsed'); // Desktop shrink
            }
        });
    }

    // Auto-close sidebar on mobile when clicking content
    document.addEventListener('click', (e) => {
        if (window.innerWidth <= 768 && sidebar && !sidebar.contains(e.target)) {
            sidebar.classList.remove('active');
        }
    });

    // Ensure mobile state resets on resize
    window.addEventListener('resize', () => {
        if (window.innerWidth > 768 && sidebar) sidebar.classList.remove('active');
    });
});