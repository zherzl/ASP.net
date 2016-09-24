function Product(name, price) {
    this.name = ko.observable(name);
    this.price = ko.observable(price);
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
            new Product("Pivo", 10.99),
            new Product("Pecivo", 12.99),
            new Product("Patka", 8.99)
        ]);

    // remove metoda je korisna za real-time objekte...kod slanja na na server može biti problem. 
    // Objašnjenje:
    //For example, consider the task of saving the shopping cart to a database every time the user added or deleted an item. 
    //With remove(), the item is removed immediately, so all you can do is send your server the new list in its entirety—it’s impossible to determine which items where added or removed. 
    //You either have to save the entire list, or manually figure out the difference between the previous version stored in the database and the new one passed in from the AJAX request. 
    this.removeProduct = function (proizvod) {
        //self.shoppingCart.remove(proizvod);
        // Dobar način u tom slučaju koji ne uklanja item iz liste zapravo:
        //self.shoppingCart.destroy(proizvod);
        alert(self.shoppingCart().length + " " + proizvod.name());
        
    };


    this.dodajProizvod = function () {
        this.shoppingCart.push(new Product("Hlače", 15.35));
    };

    this.fullName = ko.computed(function () {
        return this.firstName() + ' ' + this.lastName();
    }, this);
};

function spremiPodatke(data) {
    alert(data.fullName());
}

var vm = new personModel();
ko.applyBindings(vm);
vm.firstName("Mirko");
