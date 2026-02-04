let employeeModal = null;
let currentEditId = null;

document.addEventListener('DOMContentLoaded', function() {
    employeeModal = new bootstrap.Modal(document.getElementById('employeeModal'));
    loadEmployees();
    loadDepartments();
    loadRoles();
});

async function loadEmployees() {
    try {
        const employees = await apiCall('/employee');
        displayEmployees(employees);
    } catch (error) {
        showAlert('Error loading employees: ' + error.message, 'danger');
    }
}

function displayEmployees(employees) {
    const tbody = document.querySelector('#employeesTable tbody');
    tbody.innerHTML = '';

    employees.forEach(emp => {
        const row = `
            <tr>
                <td>${emp.firstName} ${emp.lastName}</td>
                <td>${emp.email}</td>
                <td>${emp.departmentName}</td>
                <td>${emp.roleName}</td>
                <td>${emp.phoneNumber}</td>
                <td>
                    <button class="btn btn-sm btn-info" onclick="editEmployee(${emp.id})">Edit</button>
                    <button class="btn btn-sm btn-danger" onclick="deleteEmployee(${emp.id})">Delete</button>
                </td>
            </tr>
        `;
        tbody.innerHTML += row;
    });
}

async function loadDepartments() {
    const select = document.getElementById('department');
    select.innerHTML = '<option value="">Select Department</option>';
    select.innerHTML += '<option value="1">IT</option>';
    select.innerHTML += '<option value="2">HR</option>';
    select.innerHTML += '<option value="3">Finance</option>';
}

async function loadRoles() {
    const select = document.getElementById('role');
    select.innerHTML = '<option value="">Select Role</option>';
    select.innerHTML += '<option value="1">Admin</option>';
    select.innerHTML += '<option value="2">HR</option>';
    select.innerHTML += '<option value="3">Manager</option>';
    select.innerHTML += '<option value="4">Employee</option>';
}

function openAddEmployeeModal() {
    currentEditId = null;
    document.getElementById('employeeForm').reset();
    employeeModal.show();
}

function editEmployee(id) {
    currentEditId = id;
    apiCall(`/employee/${id}`).then(emp => {
        document.getElementById('firstName').value = emp.firstName;
        document.getElementById('lastName').value = emp.lastName;
        document.getElementById('email').value = emp.email;
        document.getElementById('phone').value = emp.phoneNumber;
        document.getElementById('department').value = emp.departmentId;
        document.getElementById('role').value = emp.roleId;
        employeeModal.show();
    });
}

async function saveEmployee() {
    const formData = {
        firstName: document.getElementById('firstName').value,
        lastName: document.getElementById('lastName').value,
        email: document.getElementById('email').value,
        phoneNumber: document.getElementById('phone').value,
        departmentId: parseInt(document.getElementById('department').value),
        roleId: parseInt(document.getElementById('role').value),
        salary: 0,
        dateOfBirth: new Date(),
        hireDate: new Date()
    };

    try {
        if (currentEditId) {
            await apiCall(`/employee/${currentEditId}`, 'PUT', formData);
            showAlert('Employee updated successfully', 'success');
        } else {
            await apiCall('/employee', 'POST', formData);
            showAlert('Employee created successfully', 'success');
        }
        employeeModal.hide();
        loadEmployees();
    } catch (error) {
        showAlert('Error saving employee: ' + error.message, 'danger');
    }
}

async function deleteEmployee(id) {
    if (confirm('Are you sure you want to delete this employee?')) {
        try {
            await apiCall(`/employee/${id}`, 'DELETE');
            showAlert('Employee deleted successfully', 'success');
            loadEmployees();
        } catch (error) {
            showAlert('Error deleting employee: ' + error.message, 'danger');
        }
    }
}
