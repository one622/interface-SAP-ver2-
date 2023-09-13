var dataTable;

$(document).ready(function () {
    loadDataTable();

});

function loadDataTable() {

 
    dataTable = $('#DT_load').DataTable({
  
        "ajax": {
            "url": "/api/Farmarea",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "my_location_id", "width": "20%" },
            { "data": "my_location_name", "width": "20%" },
            { "data": "dataareaid", "width": "20%" },
            { "data": "crop_year", "width": "20%" },
            {
                "data": "my_location_id",
                "render": function (data) {
                    return `<div class="text-center">
                       <a href="/BookList/Edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                            Edit
                        </a>
                        &nbsp;
                      
                        </div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}
