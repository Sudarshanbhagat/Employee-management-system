let leaveModal = null;

document.addEventListener('DOMContentLoaded', function() {
    leaveModal = new bootstrap.Modal(document.getElementById('leaveModal'));
    loadMyLeaves();
    loadPendingLeaves();
    loadLeaveTypes();
});

async function loadMyLeaves() {
    try {
        const userId = localStorage.getItem('userId');
        const leaves = await apiCall(`/leave/employee/${userId}`);
        displayMyLeaves(leaves);
    } catch (error) {
        console.error('Error loading leaves:', error);
    }
}

async function loadPendingLeaves() {
    try {
        const leaves = await apiCall('/leave/pending');
        displayPendingLeaves(leaves);
    } catch (error) {
        console.error('Error loading pending leaves:', error);
    }
}

function displayMyLeaves(leaves) {
    const tbody = document.querySelector('#myLeavesTable tbody');
    tbody.innerHTML = '';

    leaves.forEach(leave => {
        const row = `
            <tr>
                <td>${leave.leaveTypeName}</td>
                <td>${new Date(leave.startDate).toLocaleDateString()}</td>
                <td>${new Date(leave.endDate).toLocaleDateString()}</td>
                <td><span class="badge bg-warning">${leave.status}</span></td>
                <td>${leave.reason}</td>
            </tr>
        `;
        tbody.innerHTML += row;
    });
}

function displayPendingLeaves(leaves) {
    const tbody = document.querySelector('#pendingLeavesTable tbody');
    tbody.innerHTML = '';

    leaves.forEach(leave => {
        const row = `
            <tr>
                <td>${leave.employeeName}</td>
                <td>${leave.leaveTypeName}</td>
                <td>${new Date(leave.startDate).toLocaleDateString()}</td>
                <td>${new Date(leave.endDate).toLocaleDateString()}</td>
                <td>
                    <button class="btn btn-sm btn-success" onclick="approveLeave(${leave.id})">Approve</button>
                    <button class="btn btn-sm btn-danger" onclick="rejectLeave(${leave.id})">Reject</button>
                </td>
            </tr>
        `;
        tbody.innerHTML += row;
    });
}

async function loadLeaveTypes() {
    const select = document.getElementById('leaveType');
    select.innerHTML = '<option value="">Select Leave Type</option>';
    select.innerHTML += '<option value="1">Sick Leave</option>';
    select.innerHTML += '<option value="2">Vacation</option>';
    select.innerHTML += '<option value="3">Personal Leave</option>';
    select.innerHTML += '<option value="4">Maternity Leave</option>';
}

function openApplyLeaveModal() {
    document.getElementById('leaveForm').reset();
    leaveModal.show();
}

async function applyForLeave() {
    const formData = {
        leaveTypeId: parseInt(document.getElementById('leaveType').value),
        startDate: document.getElementById('startDate').value,
        endDate: document.getElementById('endDate').value,
        reason: document.getElementById('reason').value
    };

    try {
        await apiCall('/leave/apply', 'POST', formData);
        showAlert('Leave request submitted successfully', 'success');
        leaveModal.hide();
        loadMyLeaves();
    } catch (error) {
        showAlert('Error applying for leave: ' + error.message, 'danger');
    }
}

async function approveLeave(id) {
    try {
        const dto = { isApproved: true, comments: '' };
        await apiCall(`/leave/${id}/approve`, 'POST', dto);
        showAlert('Leave approved successfully', 'success');
        loadPendingLeaves();
    } catch (error) {
        showAlert('Error approving leave: ' + error.message, 'danger');
    }
}

async function rejectLeave(id) {
    try {
        await apiCall(`/leave/${id}/reject`, 'POST');
        showAlert('Leave rejected successfully', 'success');
        loadPendingLeaves();
    } catch (error) {
        showAlert('Error rejecting leave: ' + error.message, 'danger');
    }
}
