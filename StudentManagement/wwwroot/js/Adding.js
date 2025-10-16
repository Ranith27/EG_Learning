
    function AddViewModel() {
        var self = this;
        self.name = ko.observable('');
        self.age = ko.observable('');
        self.phone = ko.observable('');

        const apiBase = 'http://localhost:5148/api/students';

        self.addStudent = function () {
            var student = {
                name: self.name(),
                age: parseInt(self.age()),
                phonenumber: self.phone()
            };
            $.ajax({
                url: apiBase,
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(student),
                success: function () {
                    alert('Student added!');
                    window.location.href = '/Home/Index';
                }
            });
        };
    }
    ko.applyBindings(new AddViewModel());
}
