
$( function () {
    $("#grid").jqGrid({
        url: "/Task/GetTodoList",
        datatype: "json",
        mtype: "GET",
        colNames: ["TaskId", "Name", "Priority", "Date", "Comment", "IsCompleted"],
        colModel: [
            { key: true, hidden: true, name: "TaskId", index: "TaskId", editable: true},
            { key: false, name: "Name", index: "Name", editable: true },
            { key: false, name: "Priority", index: "Priority", editable: true, edittype: "select", editoptions: { value: { "0": "Low", "1": "Medium", "2": "High" } } },
            { key: false, name: "Date", index: "Date", editable: true, formatter: "date", formatoptions: { newformat: "d/m/Y" } },
            { key: false, name: "Comment", index: "Comment", editable: true },
            { key: false, name: "IsCompleted", index: "IsCompleted", editable: true, edittype: "select", editoptions: { value: { "1": "Yes", "0": "No" } } }],
        pager: jQuery("#pager"),
        rowNum: 10,
        rowList: [10, 20, 30, 40],
        height: "100%",
        viewrecords: true,
        caption: "Todo List",
        emptyrecords: "No records to show",
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            id: "0"
        },
        autowidth: true,
        multiselect: false
    });
    
});
