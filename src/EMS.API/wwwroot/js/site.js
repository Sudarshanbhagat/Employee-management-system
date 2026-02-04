// Global API configuration
const API_BASE_URL = '/api';
const TOKEN_KEY = 'token';

// Helper function to get authorization header
function getAuthHeader() {
    const token = localStorage.getItem(TOKEN_KEY);
    return {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
    };
}

// Check if user is authenticated
function isAuthenticated() {
    return localStorage.getItem(TOKEN_KEY) !== null;
}

// Logout function
function logout() {
    localStorage.removeItem(TOKEN_KEY);
    localStorage.removeItem('userId');
    window.location.href = '/';
}

// Show alert message
function showAlert(message, type = 'info') {
    const alertHtml = `
        <div class="alert alert-${type} alert-dismissible fade show" role="alert">
            ${message}
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
        </div>
    `;
    const container = document.getElementById('alertContainer');
    if (container) {
        container.innerHTML = alertHtml;
    }
}

// Make API call
async function apiCall(endpoint, method = 'GET', data = null) {
    const options = {
        method,
        headers: getAuthHeader()
    };

    if (data) {
        options.body = JSON.stringify(data);
    }

    const response = await fetch(`${API_BASE_URL}${endpoint}`, options);
    
    if (response.status === 401) {
        logout();
        return null;
    }

    if (!response.ok) {
        const error = await response.json();
        throw new Error(error.message || 'An error occurred');
    }

    if (response.status === 204) {
        return true;
    }

    return await response.json();
}

// Redirect to login if not authenticated
if (!isAuthenticated() && !window.location.pathname.includes('/')) {
    window.location.href = '/';
}
