var dataTable;

$(document).ready(function () {
    alert('tblist');
    /*loadDataTable();*/
});

function loadDataTable() {


    function Delete(url) {
        swall({
            title: "Are you sure?",
            text: "Once deleted, you will not belive to recover",
            icon: "warning",
            dangerMode: true
        }).then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    type: "DELETE",
                    url: url,
                    success: function (data) {
                        if (data.success) {
                            toastr.success(message);
                            dataTable.ajax.reload();
                        }
                        else {
                            toastr.error(message);
                        }
                    }
                });
            }
        });
    }
}