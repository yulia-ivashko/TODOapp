app.service("crudAJService", function ($http) {

    //get All Tasks
    this.getTasks = function () {
        var response = $http({
            method: "GET",
            url: "Task/GetAllTasks"
        });
        return response;
        //return $http.get("Task/GetAllTasks");
    };

    // get Task by taskId
    this.getTask = function (taskId) {
        var response = $http({
            method: "post",
            url: "Task/GetTaskById",
            params: {
                id: JSON.stringify(taskId)
            }
        });
        return response;
    }

    // Update Task 
    this.updateTask = function (task) {
        var response = $http({
            method: "post",
            url: "Task/UpdateTask",
            data: JSON.stringify(task),
            dataType: "json"
        });
        return response;
    }

    // Add Task
    this.AddTask = function (task) {
        var response = $http({
            method: "post",
            url: "Task/AddTask",
            data: JSON.stringify(task),
            dataType: "json"
        });
        return response;
    }

    //Delete Task
    this.DeleteTask = function (taskId) {
        var response = $http({
            method: "post",
            url: "Task/DeleteTask",
            params: {
                taskId: JSON.stringify(taskId)
            }
        });
        return response;
    }
});