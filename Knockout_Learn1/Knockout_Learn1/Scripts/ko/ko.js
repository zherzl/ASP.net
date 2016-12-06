function Product(name, price) {
    this.name = ko.observable(name);
    this.price = ko.observable(price);
    this.priceFormatted = ko.computed(function () {

        return formatValue(this.price().toString());
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

    this.visina = ko.observable(formatValue("180.53"));

    this.spremiPodatke = function () {
        spremiPodatke(this);
    };

    this.shoppingCart = ko.observableArray(
        [
            new Product("Pivo", 100000.999),
            new Product("Pecivo", 12.99),
            new Product("Patka", 8.99)
        ]);

    // remove metoda je korisna za real-time objekte...kod slanja na server može biti problem. 
    // Objašnjenje:
    //For example, consider the task of saving the shopping cart to a database every time the user added or deleted an item. 
    //With remove(), the item is removed immediately, so all you can do is send your server the new list in its entirety—it’s impossible to determine which items where added or removed. 
    //You either have to save the entire list, or manually figure out the difference between the previous version stored in the database and the new one passed in from the AJAX request. 
    this.removeProduct = function (proizvod) {
        //self.shoppingCart.remove(proizvod);
        // Dobar način u tom slučaju koji ne uklanja item iz liste zapravo:
        self.shoppingCart.destroy(proizvod);
        //alert(proizvod._destroy);
        //alert(self.shoppingCart().length + " " + proizvod.name());
        ispisiSve(self.shoppingCart());
    };


    this.dodajProizvod = function () {
        this.shoppingCart.push(new Product("Hlače", 15.35));
    };

    this.fullName = ko.computed(function () {
        return this.firstName() + ' ' + this.lastName();
    }, this);
};


function ispisiSve(cart) {

    for (var i = 0; i < cart.length; i++) {
        console.log(cart[i]._destroy);
    }
}


Product.prototype.formatMoney = function (c, d, t) {
    var n = this,
        c = isNaN(c = Math.abs(c)) ? 2 : c,
        d = d == undefined ? "." : d,
        t = t == undefined ? "," : t,
        s = n < 0 ? "-" : "",
        i = String(parseInt(n = Math.abs(Number(n) || 0).toFixed(c))),
        j = (j = i.length) > 3 ? j % 3 : 0;
    return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
};





function spremiPodatke(data) {
    alert(data.fullName());
}

var vm = new personModel();
ko.applyBindings(vm);
vm.firstName("Mirko");
