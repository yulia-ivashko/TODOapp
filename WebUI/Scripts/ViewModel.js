var viewModel = function () {
    var self = this;

    self.TaskId = ko.observable("");
    self.Name = ko.observable("");
    self.Priority = ko.observable("0");
    self.Date = ko.observable("");


    self.Message = ko.observable("")
    self.DeptIds = ko.observableArray([]);

    self.getDeptIds = function () {
        $.ajax({
            type: 'POST',
            url: '/Home/GetDeptIds/',
            dataType: "json",
            async: true,
            success: function (data) {
                debugger;
                self.DeptIds(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                if (xhr.status != 403)
                    alert("Status: " + xhr.status + ", Error: " + thrownError, "Error");
            }
        });

    };
    self.getDeptIds();

    self.Update = function () {
        var Employee = {};
        Employee.EmpId = self.EmpId();
        Employee.EmpName = self.EmpName();
        Employee.Designation = self.Designation();
        Employee.DeptId = self.DeptId();

        $.ajax({
            url: '/Home/Save/',
            type: 'POST',
            data: Employee,
            success: function (result) {
                self.Message("Recorded inserted Sucessfully");

                self.EmpId("");
                self.EmpName("");
                self.Designation("");
                self.DeptId("")
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                debugger;
                alert("some error");
            }
        });
    };
}