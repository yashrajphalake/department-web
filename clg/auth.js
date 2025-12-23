
function validateForm() {
    const password = document.getElementById("password");
    const mobile = document.getElementById("mobile");

    if (password.value.length !== 6 || isNaN(password.value)) {
        alert("Password must be a 6-digit number.");
        return false;
    }

    if (mobile.value.length !== 10 || isNaN(mobile.value)) {
        alert("Mobile number must be a 10-digit number.");
        return false;
    }

    return true;
}
