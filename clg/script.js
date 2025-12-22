document.addEventListener('DOMContentLoaded', () => {
    const togglePassword = document.querySelector('.toggle-password');
    const passwordInput = document.getElementById('password');

    if (togglePassword && passwordInput) {
        togglePassword.addEventListener('click', () => {
            if (passwordInput.type === 'password') {
                passwordInput.type = 'text';
                togglePassword.textContent = 'Hide';
            } else {
                passwordInput.type = 'password';
                togglePassword.textContent = 'Show';
            }
        });
    }

    const registerForm = document.getElementById('registerForm');
    if (registerForm) {
        registerForm.addEventListener('submit', (e) => {
            e.preventDefault();
            const email = document.getElementById('email').value;
            const password = document.getElementById('password').value;
            const mobile = document.getElementById('mobile').value;

            if (!validateEmail(email)) {
                alert('Invalid email format');
                return;
            }

            if (password.length !== 6 || !/\d{6}/.test(password)) {
                alert('Password must be 6 digits');
                return;
            }

            if (mobile.length !== 10 || !/\d{10}/.test(mobile)) {
                alert('Mobile number must be 10 digits');
                return;
            }

            // Simulate successful registration and redirect
            alert('Registration successful!');
            window.location.href = 'login.html';
        });
    }

    const loginForm = document.getElementById('loginForm');
    if (loginForm) {
        loginForm.addEventListener('submit', (e) => {
            e.preventDefault();
            // Simulate successful login and redirect
            alert('Login successful!');
            window.location.href = 'dashboard.html';
        });
    }
});

function validateEmail(email) {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}