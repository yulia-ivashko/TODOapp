app.controller("mvcCRUDCtrl", function ($scope, crudAJService) {
    $scope.divTask = false;
    GetAllTasks();
    //To Get all task records  
    function GetAllTasks() {
        debugger;
        var getTaskData = crudAJService.getTasks();
        getTaskData.then(function (task) {
            $scope.tasks = task.data;
        }, function () {
            alert('Error in getting task records');
        });
    }

    $scope.editTask = function (task) {
        var getTaskData = crudAJService.getTask(task.TaskId);
        getTaskData.then(function (_task) {
            $scope.task = _task.data;
            $scope.taskId = task.TaskId;
            $scope.taskName = task.Name;
            $scope.taskPriority = task.Priority;
            $scope.taskDate = task.Date;
            $scope.taskComment = task.Comment;
            $scope.taskIsCompleted = task.IsCompleted;
            $scope.Action = "Update";
            $scope.divTask = true;
        }, function () {
            alert('Error in getting task records');
        });
    }

    $scope.AddUpdateTask = function () {
        var Task = {
            Name: $scope.taskName,
            Priority: $scope.taskPriority,
            Date: $scope.taskDate,
            Comment: $scope.taskComment,
            IsCompleted: $scope.IsCompleted
        };
        var getTaskAction = $scope.Action;

        if (getTaskAction == "Update") {
            Task.Id = $scope.taskId;
            var getTaskData = crudAJService.updateTask(Task);
            getTaskData.then(function (msg) {
                GetAllTasks();
                alert(msg.data);
                $scope.divTask = false;
            }, function () {
                alert('Error in updating task record');
            });
        } else {
            var getTaskData = crudAJService.AddTask(Task);
            getTaskData.then(function (msg) {
                GetAllTasks();
                alert(msg.data);
                $scope.divTask = false;
            }, function () {
                alert('Error in adding task record');
            });
        }
    }

    $scope.AddTaskDiv = function () {
        ClearFields();
        $scope.Action = "Add";
        $scope.divTask = true;
    }

    $scope.deleteTask = function (task) {
        var getTaskData = crudAJService.DeleteTask(task.Id);
        getTaskData.then(function (msg) {
            alert(msg.data);
            GetAllTasks();
        }, function () {
            alert('Error in deleting task record');
        });
    }

    function ClearFields() {
        $scope.taskId = "";
        $scope.taskName = "";
        $scope.taskPriority = "";
        $scope.taskDate = "";
        $scope.taskComment = "";
        $scope.taskIsCompleted = "";
    }
    $scope.Cancel = function () {
        $scope.divTask = false;
    };
});