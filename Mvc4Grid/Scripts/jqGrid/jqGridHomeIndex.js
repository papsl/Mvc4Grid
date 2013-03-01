$(document).ready(function () {
    $('#grid').jqGrid({
        colNames: ['Online', 'Computer', 'IP', 'User'],
        colModel: [
                    { name: 'IsOnline', width: 100, index: 'IsOnline', searchoptions: { sopt: ['eq', 'ne']} },
                    { name: 'Name', index: 'Name', searchoptions: { sopt: ['eq', 'ne', 'cn']} },
                    { name: 'IP', index: 'IP', searchoptions: { sopt: ['eq', 'ne', 'cn']} },
                    { name: 'User', index: 'User', searchoptions: { sopt: ['eq', 'ne', 'cn']} }
                  ],
        pager: jQuery('#pager'),
        sortname: 'Name',
        rowNum: 10,
        rowList: [10, 20, 50],
        sortorder: "asc",
       /* width: 600,
        height: 250,*/
        datatype: 'json',
        caption: 'Result of scanning',
        viewrecords: true,
        mtype: 'GET',

        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            userdata: "userdata"
        },
        //or ondblClickRow
        onSelectRow: function (id) {
            var row = $('#grid').getRowData(id);
            //GetInfo(row['Computer_Name'], row['Computer_IP']);
        },
        url: "/Home/GetData"
    }).navGrid('#pager', { view: false, del: false, add: false, edit: false },
       {}, // default settings for edit
       {}, // default settings for add
       {}, // delete instead that del:false we need this
       {closeOnEscape: true, multipleSearch: true, closeAfterSearch: true }, // search options
       {} /* view parameters*/
     );
     
});