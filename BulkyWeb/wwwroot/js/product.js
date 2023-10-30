﻿var dataTable;

$(document).ready(function () {
    loadData();
});

function loadData() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'title' },
            { data: 'price' },
            { data: 'isbn' },
            { data: 'author' },
            { data: 'category.name' },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                                <a  href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2">
                                    <i class="bi bi-pencil-square">Edit</i>
                                <a onClick=Delete("/admin/product/delete?id=${data}") class="btn btn-danger mx-2">
                                    <i class="bi bi-trash">Delete</i>
                            </div>`
                }

            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}
