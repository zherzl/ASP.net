function Grad() {
    this.Naziv = ko.observable();
    this.DrzavaNaziv = ko.observable();
}

var GradoviModel = function () {
    var self = this;
    self.Gradovi = ko.observableArray([]);
    

    self.loadData = function () {
        $.getJSON('/api/Gradovi', function (data) {
            self.Gradovi(data.GradoviModel);
        });
    }

    self.loadDataDva = function () {
        alert('');
    }

    self.saveData = function () {
        var gradovi = { GradoviModel: ko.toJSON(self) };
        $.post("/api/Gradovi", gradovi, function (data) {
            alert("Your data has been posted to the server!");
        });
    }
}



var vm = new GradoviModel();
ko.applyBindings(vm);