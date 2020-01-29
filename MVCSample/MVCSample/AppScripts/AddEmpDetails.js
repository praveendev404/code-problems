$(document).ready(function () {
    var editUrl = "/KnockOut/AddEmpEdit?id=1";
    var EmployeeDetails = (function () {
        var self = this;
        self.EmployeeDetails = {};
        self.EmployeeDetails.FirstName = ko.observable();
        self.EmployeeDetails.LastName = ko.observable();
        self.EmployeeDetails.DateofBirth = ko.observable();
        self.EmployeeDetails.Address = ko.observable();

        var LoadData = (function () {
            
            var source = null;
            $.ajax({
                url: '/KnockOut/AddEmpEdit?id=1',
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                 data: ko.toJSON(self.EmployeeDetails),
                success: function (data) {
                    
                    self.EmployeeDetails.FirstName = data.FirstName;
                    self.EmployeeDetails.LastName = data.LastName;
                    self.EmployeeDetails.DateofBirth = data.DateofBirth;
                    self.EmployeeDetails.Address = data.Address;
                }
            }).fail(
                    function (xhr, textStatus, err) {
                        alert(err);
                    });

        });
        self.Save = function Save() {
            
            $.ajax({
                url: '/KnockOut/AddEmpDetails',
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(self.EmployeeDetails),
                success: function (data) {

                }
            }).fail(
            function (xhr, textStatus, err) {
                alert(err);
            });
        }
        return {
            LoadData: LoadData
        };
    })();
    
    EmployeeDetails.LoadData();
    ko.applyBindings(EmployeeDetails, document.getElementById("dvEmployeeDetails"));
})
