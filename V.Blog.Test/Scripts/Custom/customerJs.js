$(document).ready(function () {
    LoadcustomerData();
});
function LoadcustomerData() {
    var dataCustomerList = $('#tblCustomer').dataTable({
        "bServerSide": true,
        "bLengthChange": false,
        "sAjaxSource": "../../home/CustomerData",
        "sServerMethod": "POST",
        "iDisplayLength": 10,
        "iDisplayStart": 0,
        "aaSorting": [[8, "desc"]],
        "bInfo": true,
        "bJQueryUI": false,
        sPaginationType: "full_numbers",
        "oLanguage": {
            "sLengthMenu": "# Records to display: _MENU_",
            "sInfo": "Showing: _START_ - _END_ of _TOTAL_"
        },
        "fnInitComplete": function (option) {
            //$("#recordsCount").text(option.fnRecordsDisplay() + " records found");
        },
        "fnDrawCallback": function () {
            // $("#recordsCount").text(dataUserSReportList.dataTable.settings[0].fnRecordsDisplay() + " records found");
            //$("#ShowingRecords").text($("#tblUserSReport_info").text().split('(')[0]);
        },
        "aoColumns": GetCustomerColumns()
        //"aoColumnDefs": [{ "bVisible": false, "aTargets": [8] }],
        //filterOptions: { searchButton: "Search", clearSearchButton: "ClearSearch", searchContainer: "SearchContainerUsersReport", filterButton: "FilterSearch" }
    });

    tblCustomer = dataCustomerList;
    alert(dataCustomerList.aaData);
}

function GetCustomerColumns() {
    var columns = [
            {
                "mData": "CustomerID",
                // "bSortable": true,
                //"bUseRendered": false,
                "sWidth": "10%"
            },
            {
                "mData": "ContactName",
                //"bSortable": true,
                //"bUseRendered": false,
                "sWidth": "10%"
            },
            {
                "mData": "CompanyName",
                //"bSortable": true,
                // "bUseRendered": false,
                "sWidth": "10%"
            },
             {
                 "mData": "Address",
                 //"bSortable": true,
                 //"bUseRendered": false,
                 "sWidth": "10%"
             },

           {
               "mData": "City",
               // "bSortable": true,
               // "bUseRendered": false,
               "sWidth": "20%"
           }
    ]
    return columns;
}