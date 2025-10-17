function getQueryParam(param) {
    const urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(param);
}

function EditViewModel() {
    var self = this;
    const studentId = getQueryParam('id');

    self.name = ko.observable('');
    self.age = ko.observable('');
    self.phone = ko.observable('');

    const apiBase = 'http://localhost:5148/api/students';

    // Load student
    $.ajax({
        url: apiBase + '/' + studentId,
        type: 'GET',
        success: function (data) {
            self.name(data.name);
            self.age(data.age);
            self.phone(data.phonenumber);
        }
    });

    // Update student
    self.updateStudent = function () {
        var updated = {
            id: studentId,
            name: self.name(),
            age: parseInt(self.age()),
            phonenumber: self.phone()
        };
        $.ajax({
            url: apiBase + '/' + studentId,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(updated),
            success: function () {
                alert('Student updated!');
                window.location.href = '/Home/Index';
            }
        });
    };
}

ko.applyBindings(new EditViewModel());