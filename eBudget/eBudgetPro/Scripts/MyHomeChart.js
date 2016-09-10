//Flot libraries included in layout

// Prijevode kupimo preko razora u index.cshtml load funkciji
var expenseTranslate;
var incomeTranslate;
var balanceTranslate;
var currency;
var min, max;               // min i max za graf uzimamo odmah pri učitavanju


// Extracting Epoch date from strange Date string
function DateFormat(jsonDate) {
    return jsonDate.substr(6, 10); // 13 znači mjesec, 12 = mjesec i dan, 11 samo vrijeme (zašto tako nisam ziher)
}



$(function () {

    $("input:button ").click(function ButtonClick() {
        DrawMyCharts("left", "chartPlaceholder", $(this).val(), false);     // Iscrtavamo grafove ovisno o valuti na gumbu 
    });
    
    DrawMyCharts("left", "chartPlaceholder", "kn", true);                   // Defaultno iscrtavamo graf za kune

    $(window).on("resize", function myfunction() {                          // Ovo sam ja dodao, inače ima plugin za resize na FLOTu
        //var wid = $("#chartPlaceholder").width();
        DrawMyCharts("left", "chartPlaceholder", "kn", false);
    });

    // Enable mouse hover to see data as tooltip
    $("<div id='tooltip'   ></div>")
    .css({                                                                  // css složen u site.css
        //position: "absolute",
        display: "none"
    })
        .appendTo("body");

    $("#chartPlaceholder").bind("plothover", function (event, pos, item) {
        PlotHover(eval, pos, item, "chartPlaceholder");
    });

    // Add the Flot version string to the footer
    $("#footer").prepend("Flot " + $.plot.version + " &ndash; ");
});



// Hover or click on series to display data
function PlotHover(event, pos, item, placeholder) {
    //if ($("#enablePosition:checked").length > 0) {
    //    var str = "(" + pos.x.toFixed(2) + ", " + pos.y.toFixed(2) + ")";
    //    $("#hoverdata").text(str);
    //}

    //if ($("#enableTooltip:checked").length > 0) {

    if (item) {
        var x = item.datapoint[0].toFixed(0),                               // Predstavlja index serije na kojoj se nalazimo
            y = item.datapoint[1].toFixed(2);                               // y = vrijednost
            
        $("#tooltip").html(item.series.label + "<br/>"
            + item.series.data[x][0] + " <br/>" + y + " " + currency)
            .css({ top: item.pageY + 5, left: item.pageX + 5 })
            .fadeIn(200);
    } else {
        $("#tooltip").hide();
    }
}



function euroFormatter(v, axis) {
    return v.toFixed(axis.tickDecimals) + " " + currency;
}


// Treći parametar (boolean) pri pozivanju grafova objašnjen u samoj metodi... privremeno rješenje
// Iscrtavamo graf samo za željenu valutu 

function DrawMyCharts(position, placeholder, myCurrency, changeActiveTab) {
    $.post('/Chart/GetAmountsJson', { myCurrency: myCurrency }, function (result) {

        var data, options, chart;
        var series1 = [];
        var series2 = [];
        var series3 = [];
        var series4 = [];

        currency = myCurrency;

        for (var key in result) {
            if (result.hasOwnProperty(key)) { // this will check if key is owned by data object and not by any of it's ancestors

                var valueExp = (result[key].Expense);
                var valueInc = (result[key].Income);
                var valueBal = (result[key].Balance);
                var valueBalCum = (result[key].BalanceCum);
                var dateFormatted = key; //result[key].DateOfAmount; // Umjesto datuma, grupiramo po mjesecima //DateFormat(result[key].DateOfAmount); S pravim datumom se čudno ponaša pa smo prebacili u string

                // Insert array of data into array
                series1.push([dateFormatted, valueExp]);
                series2.push([dateFormatted, valueInc]);
                series3.push([dateFormatted, valueBal]);
                series4.push([dateFormatted, valueBalCum]);
            }
        }

        data = [
                { data: series1, label: "-" + expenseTranslate, bars: { show: true, fill: true, barWidth: 0.8, align: "center" } },
                { data: series2, label: "-" + incomeTranslate,  bars: { show: true, fill: true, barWidth: 0.8, align: "center" }, points: { show: false }, yaxis: 1 },
                { data: series3, label: "-" + balanceTranslate, lines: { show: true, fill: false, align: "center" }, points: { show: true }, yaxis: 1 },
                { data: series4, label: "-" + balanceTranslate + "-cumulative", lines: { show: true, fill: true, align: "center" }, points: { show: true }, yaxis: 2 }
        ];

        options = ChrtXyzOptions(position);
        chartXYZ = $.plot($("#" + placeholder), data, options);


        // Koristimo pri prvom pokretanju -> nakon što se učitaju tabovi, graf se prikaže ispravno jer je veličina chart containera vidljiva
        // Zatim brzo vratimo prvi tab kao aktivni.... ako je parametar false, znači da smo došli na TAB ručno i ne trebaju se klase mijenjati
        if (changeActiveTab) {
            $("#aktivni1, #Income").addClass("active");
            $("#neaktivni1, #Charts").removeClass("active");
        }
    });
}

// Opcije grafa u posebnoj metodi
function ChrtXyzOptions(position) {
    
    var options = {
                    legend: { position: "nw" },
                    xaxes: [
                        {
                            mode: "categories",
                            tickLength: 0,
                            position: "bottom"
                        }],
                    yaxes: [
                        {
                            min: min, max: max, 
                            // align if we are to the right
                            alignTicksWithAxis: position == "right" ? 1 : null,
                            position: position,
                            tickFormatter: euroFormatter
                        },
                        {
                            // align if we are to the right
                            alignTicksWithAxis: position == "right" ? 1 : null,
                            position: position == "right" ? "left" : "right", // obratno od yaxes 1
                            tickFormatter: euroFormatter
                        }],
                    grid:
                        {
                            hoverable: true,
                            clickable: true,
                            //backgroundColor: { colors: ["#600000", "#000"] },
                            borderWidth: { top: 1, right: 1, bottom: 2, left: 2 }
                        }
                };

    return options;
}