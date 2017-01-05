function Grad(IDGrad, Naziv, DrzavaID) {
    this.IDGrad = ko.observable(IDGrad);
    this.Naziv = ko.observable(Naziv);
    this.DrzavaID = ko.observable(DrzavaID);
    this.Prikaz = ko.computed(function () {
        return 'Grad ' + Naziv
    });
}

function AboutViewModel() {
    var self = this;
    self.gradovi = ko.observableArray([
        // new Grad(1, "Zagreb", 2)
    ]);

    self.loadData = function () {
        $.getJSON("/Home/Podaci", function (data) {
            self.gradovi(data);
            //$.each(artists, function (index, artist) {
            //    self.ArtistsSearched.push(new Artist(artist.ArtistId, artist.Name));
            //});
        });
    }
}

var gradVm = new AboutViewModel();
ko.applyBindings(gradVm);