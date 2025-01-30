window.showToastWithMessage = (toastId, message) => {
    let toastElement = document.getElementById(toastId);
    if (toastElement) {
        let toastBody = toastElement.querySelector('.toast-body');
        toastBody.textContent = message; // Update message
        let toast = new bootstrap.Toast(toastElement);
        toast.show();
    }
};