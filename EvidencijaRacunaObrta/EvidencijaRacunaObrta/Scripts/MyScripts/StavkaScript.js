var tablica = "#stavkaTable";
var ddlStavke = "#ddlStavke";
var rowId = 1;


// Ovako moramo registrirati partial view evente - inače 0 bodova !!!!!
$(document).on('change', "input[name='Cijena']", function () {
    var id = $("#stavka :first-child").prop('id');
    //var lbl
    $(id).text(GetCijena());
});

$(function () {
    GetTop10Stavke();

    $("#btnGo").on('click', function () {
        var id = $(ddlStavke).find(":selected").val();
        var stavkaSplit = $(ddlStavke).find(":selected").text().split("|");
        DodajNovuStavkuURacun(id, stavkaSplit[0], stavkaSplit[1], stavkaSplit[2], stavkaSplit[3], stavkaSplit[4]);
    });

    $("input[type='submit']").on('click', function () {
        var iznos = $("#Racun_IznosRacuna").val().replace(',', '.');
        $("#Racun_IznosRacuna").val(iznos);
        alert($("#Racun_IznosRacuna").val())
    });
});


function GetStavka() {
    $.ajax({
        url: '/Racun/AddStavka',
        data: { 'id': 1 },
        method: 'POST'
    }).done(function (result) {
        $(tablica + " > tbody").html(result);
    });
}

function GetTop10Stavke() {
    $.ajax({
        url: '/Racun/Top10Stavke',
        data: {},
        method: 'POST'
    }).done(function (result) {
        for (var i = 0; i < result.Stavke.length; i++) {
            console.log(result.Stavke[i]);
            DodajNoviOption(result.Stavke[i]);
        }
    });
}

function DodajNoviOption(stavka) {
    var id = stavka.Id;
    var opis = stavka.UslugaOpis;
    var cijena = stavka.Cijena;
    var kol = stavka.Kolicina;
    var jed = stavka.Jedinica;
    var ukupno = cijena * kol;

    var tekst = opis + '|' + cijena + '|' + kol + '|' + jed + '|' + ukupno;
    var $option = $('<option>', { value: id, text: tekst });
    $(ddlStavke).append($option);
}

function DodajNovuStavkuURacun(id, opis, cijena, kol, jed, ukupno) {

    var $red = $("<tr>", { id: rowId });
    var $kolona1 = $("<td>", { "class": "" });
    var $kolona2 = $("<td>", { "class": "" });
    var $kolona3 = $("<td>", { "class": "" });
    var $kolona4 = $("<td>", { "class": "" });
    var $kolona5 = $("<td>", { "class": "" });
    var $kolona6 = $("<td>", { "class": "" }).append(GumbZaRemoveRetka($red));

    var $inputOpis = $('<input/>').attr({ type: 'text', id: id + '_' + 0, name: 'opis_', class: 'form-control text-box single-line' }).val(opis);
    var $inputCijena = $('<input/>').attr({ type: 'text', id: id + '_' + 1, name: 'cijena_', class: 'form-control text-box single-line' }).val(cijena);
    var $inputKol = $('<input/>').attr({ type: 'text', id: id + '_' + 2, name: 'kol_', class: 'form-control text-box single-line' }).val(kol);
    var $inputJed = $('<input/>').attr({ type: 'text', id: id + '_' + 3, name: 'jed_', class: 'form-control text-box single-line' }).val(jed);
    var $inputUkupno = $('<input/>').attr({ type: 'text', id: id + '_' + 4, name: 'ukupno_', class: 'form-control text-box single-line' }).val(ukupno);

    $kolona1.append($inputOpis);
    $kolona2.append($inputCijena);
    $kolona3.append($inputKol);
    $kolona4.append($inputJed);
    $kolona5.append($inputUkupno);

    $red.append($kolona1).append($kolona2).append($kolona3).append($kolona4).append($kolona5).append($kolona6);
    $(tablica).append($red);
    rowId++;
}

function GumbZaRemoveRetka($red) {
    var $a = $("<a>", { href: "#", class: 'btn btn-danger', text: '-' });
    //var $img = $("<img>", { src: "Slike/addRemove_del.png", alt: "Ukloni redak" });

    // Pravimo event za remove
    $a.click(function () {
        $red.remove();
    });

    //$a.append($img);
    return $a;
}




function GetCijena() {
    return $("#UslugaOpis").val();
}

function GetKolicina() {
    return $("#Kolicina").val();
}

$(function () {
    // Ovo ne radi ovako na partial
    //$("input[type='text']").change(function () {
    //    var id = $("#stavka").first();
    //    $('lblSuma_' + id).text(GetCijena());
    //});

    //$("#Kolicina").on('change', function () {
    //    var id = $("#stavka").first();
    //    $('lblSuma_' + id).text(GetKolicina());
    //});
});