function Product(name, price, tags, discount) {
    this.name = ko.observable(name);
    this.price = ko.observable(price);
    tags = typeof (tags) !== 'undefined' ? tags : [];
    this.tags = ko.observableArray(tags);

    discount = typeof (discount) !== 'undefined' ? discount : 0;
    this.discount = ko.observable(discount);
    this.formattedDiscount = ko.computed(function () {
        return (this.discount() * 100) + '%';
    }, this);


}

function personModel() {
    // self je referencea koja se koristi za brisanje
    var self = this;
    this.firstName = ko.observable("John");
    this.lastName = ko.observable("Smith");
    this.obaviNesto = function () {
        alert('Stisnuo si ' + this.lastName());
    };

    this.spremiPodatke = function () {
        spremiPodatke(this);
    };

    this.shoppingCart = ko.observableArray(
        [
            new Product("Pivo", 10.99, null, 0.2),
            new Product("Pecivo", 12.99, ['Dubravica', 'Mlinar'], 0.0),
            new Product("Patka", 8.99, ['Pekinška', 'Pečena'])
        ]);

    // remove metoda je korisna za real-time objekte...kod slanja na na server može biti problem. 
    // Objašnjenje:
    //For example, consider the task of saving the shopping cart to a database every time the user added or deleted an item. 
    //With remove(), the item is removed immediately, so all you can do is send your server the new list in its entirety—it’s impossible to determine which items where added or removed. 
    //You either have to save the entire list, or manually figure out the difference between the previous version stored in the database and the new one passed in from the AJAX request. 
    this.removeProduct = function (proizvod) {
        //self.shoppingCart.remove(proizvod);
        // Dobar način u tom slučaju koji ne uklanja item iz liste zapravo:
        self.shoppingCart.destroy(proizvod);
        //console.log(self.shoppingCart().length);
        //alert(self.shoppingCart().length + " " + proizvod.name());
        
    };


    this.dodajProizvod = function () {
        this.shoppingCart.push(new Product("Hlače", 15.35));
    };

    this.fullName = ko.computed(function () {
        return this.firstName() + ' ' + this.lastName();
    }, this);

    // Eto, gledamo što je bilo obrisano
    this.provjeriStanjeListe = function () {
        for (var i = 0; i < self.shoppingCart().length; i++) {

            var obrisaniObj = self.shoppingCart()[i];
            if (obrisaniObj._destroy == true) {
                console.log("objekt " + obrisaniObj.name() + " je obrisan");
            }
        }
    }

    var featured = new Product("ACME", 4.99);
    this.featured = ko.observable(featured);
};

function spremiPodatke(data) {
    alert(data.fullName());
}

var vm = new personModel();
ko.applyBindings(vm);
vm.firstName("Mirko");


// Array funkcije u knockoutu (isto kao i u javascriptu):
// push()
// pop() 
// unshift()
// shift()
// slice()
// remove()
// removeAll()
// destroy()
// destroyAll()
// sort()
// reversed()
// indexOf()