let dashboardModal = null;

document.addEventListener('DOMContentLoaded', function() {
    loadDashboard();
});

async function loadDashboard() {
    try {
        const employees = await apiCall('/employee');
        const projects = await apiCall('/project');
        const leaves = await apiCall('/leave/pending');

        document.getElementById('totalEmployees').textContent = employees?.length || 0;
        document.getElementById('activeProjects').textContent = projects?.filter(p => p.status === 'In Progress').length || 0;
        document.getElementById('pendingLeaves').textContent = leaves?.length || 0;
        document.getElementById('totalDepartments').textContent = '3';

        // Load recent employees
        if (employees && employees.length > 0) {
            const recentEmployees = employees.slice(0, 5);
            loadRecentEmployees(recentEmployees);
        }

        // Load active projects
        if (projects && projects.length > 0) {
            const activeProjects = projects.filter(p => p.status === 'In Progress').slice(0, 5);
            loadActiveProjects(activeProjects);
        }
    } catch (error) {
        console.error('Error loading dashboard:', error);
    }
}

function loadRecentEmployees(employees) {
    const tbody = document.querySelector('#recentEmployeesTable tbody');
    tbody.innerHTML = '';
    
    employees.forEach(emp => {
        const row = `
            <tr>
                <td>${emp.firstName} ${emp.lastName}</td>
                <td>${emp.departmentName}</td>
                <td>${emp.email}</td>
            </tr>
        `;
        tbody.innerHTML += row;
    });
}

function loadActiveProjects(projects) {
    const tbody = document.querySelector('#activeProjectsTable tbody');
    tbody.innerHTML = '';
    
    projects.forEach(proj => {
        const row = `
            <tr>
                <td>${proj.projectName}</td>
                <td><span class="badge bg-success">${proj.status}</span></td>
                <td>${proj.departmentName}</td>
            </tr>
        `;
        tbody.innerHTML += row;
    });
}
