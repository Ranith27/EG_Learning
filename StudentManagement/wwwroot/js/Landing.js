function ListViewModel() {
    var self = this
    self.Students = ko.observableArray([])
    const apiBase = 'http://localhost:5148/api/students';
    self.loadstudents = function () {
        $.ajax
            ({
                url: apiBase,
                type: 'GET',
                success: function (data) {
                    self.Students(data);
                }
            });
    };
    self.deleteStudent = function (student) {
        if (!confirm('Are you sure want to delete the student?')) return;
        $.ajax
            ({
                url: apiBase + '/' + student.id,
                type: 'DELETE',
                success: function () {
                    self.Students.remove(student)
                }
            });
    };
    self.loadstudents();
}
ko.applyBindings(new ListViewModel());