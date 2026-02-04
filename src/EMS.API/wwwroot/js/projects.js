let projectModal = null;
let currentEditId = null;

document.addEventListener('DOMContentLoaded', function() {
    projectModal = new bootstrap.Modal(document.getElementById('projectModal'));
    loadProjects();
});

async function loadProjects() {
    try {
        const projects = await apiCall('/project');
        displayProjects(projects);
    } catch (error) {
        showAlert('Error loading projects: ' + error.message, 'danger');
    }
}

function displayProjects(projects) {
    const tbody = document.querySelector('#projectsTable tbody');
    tbody.innerHTML = '';

    projects.forEach(proj => {
        const row = `
            <tr>
                <td>${proj.projectName}</td>
                <td>${proj.departmentName}</td>
                <td><span class="badge bg-info">${proj.status}</span></td>
                <td>${new Date(proj.startDate).toLocaleDateString()}</td>
                <td>${proj.endDate ? new Date(proj.endDate).toLocaleDateString() : '-'}</td>
                <td>$${proj.budget.toFixed(2)}</td>
                <td>
                    <button class="btn btn-sm btn-info" onclick="editProject(${proj.id})">Edit</button>
                    <button class="btn btn-sm btn-danger" onclick="deleteProject(${proj.id})">Delete</button>
                </td>
            </tr>
        `;
        tbody.innerHTML += row;
    });
}

function openAddProjectModal() {
    currentEditId = null;
    document.getElementById('projectForm').reset();
    projectModal.show();
}

function editProject(id) {
    currentEditId = id;
    apiCall(`/project/${id}`).then(proj => {
        document.getElementById('projectName').value = proj.projectName;
        document.getElementById('description').value = proj.description;
        document.getElementById('startDate').value = proj.startDate.split('T')[0];
        document.getElementById('endDate').value = proj.endDate ? proj.endDate.split('T')[0] : '';
        document.getElementById('budget').value = proj.budget;
        projectModal.show();
    });
}

async function saveProject() {
    const formData = {
        projectName: document.getElementById('projectName').value,
        description: document.getElementById('description').value,
        startDate: document.getElementById('startDate').value,
        endDate: document.getElementById('endDate').value || null,
        budget: parseFloat(document.getElementById('budget').value) || 0,
        departmentId: 1
    };

    try {
        if (currentEditId) {
            await apiCall(`/project/${currentEditId}`, 'PUT', formData);
            showAlert('Project updated successfully', 'success');
        } else {
            await apiCall('/project', 'POST', formData);
            showAlert('Project created successfully', 'success');
        }
        projectModal.hide();
        loadProjects();
    } catch (error) {
        showAlert('Error saving project: ' + error.message, 'danger');
    }
}

async function deleteProject(id) {
    if (confirm('Are you sure you want to delete this project?')) {
        try {
            await apiCall(`/project/${id}`, 'DELETE');
            showAlert('Project deleted successfully', 'success');
            loadProjects();
        } catch (error) {
            showAlert('Error deleting project: ' + error.message, 'danger');
        }
    }
}
