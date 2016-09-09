var idItem;
var amountType;
// Returned dictionary with sum of values converts to html
var tblOpen = "<table class='table'>";
var tblClose = "</table>";
var trOpen = "<tr>";
var trClose = "</tr>";
var tdOpen = "<td>";
var tdClose = "</td>";
var innerTable = "";


$(function () {

    //$("#Income").append("<h1> Ovdje neki tekst </h1>");

    // Modal dialog btn events
        $("#btnDelete").on("click", function DeleteItemBtnClick() {
            ajaxDelete(idItem, amountType);
            $("#modal-1").modal('hide');
        });

        $("#btnCancel").on("click", function DeleteItemBtnCancel() {
            idItem = 0;
            amountType = "";
        });


    });


// Row delete btn click event
function IncomeExpenseDelete(itemId, AmountType) {
    idItem = itemId;
    amountType = AmountType;
    
    $("#modal-1").modal('show');
}

// Delete row from database using Ajax and refresh sum amounts
function ajaxDelete(itemId, itemType) {

    $.ajax({

        type: 'POST',
        url: '/Data/DeleteItem', //'@Url.Action("DeleteItem", "Data")' -> doesn't understand in separate file ?!
        data: { idItem: itemId, itemType: itemType },
        success: function (result) {
            
            innerTable = "";

            for (var key in result) {
                if (result.hasOwnProperty(key)) { // this will check if key is owned by data object and not by any of it's ancestors
                    //alert(key + ': ' + result[key]); // this will show each key with it's value
                    var value = $(result[key]).val();
             
                    innerTable += (trOpen + tdOpen + result[key] + " " + key + tdClose + trClose);
                }
            }

            // Refresh sum amounts for tables
            var table = tblOpen + innerTable + tblClose;
            if (amountType == "Income") {
                $("#incomeSumDiv").html(table);
            } else if (amountType == "Expense") {
                $("#expenseSumDiv").html(table);
            } else {
                alert('No Amounts to sum. Amount type:' + amountType);
            }

            RefreshBalanceSum();

            // Remove row from table
            var redak = document.getElementById(itemId + " _row" + itemType);
            redak.remove();

            // Reset values just in case :-)
            idItem = 0;
            amountType = "";

        }, // success end
        error: function (xhr, ajaxOptions, error) {

            alert('Brisanje neuspješno')
        } // error end
    }); // ajax end
}


function RefreshBalanceSum() {
    $.ajax({
        type: 'POST',
        url: '/Data/GetBalanceSumJson',
        data: {},
        success: function (result) {

            innerTable = "";

            for (var key in result) {
                if (result.hasOwnProperty(key)) { // this will check if key is owned by data object and not by any of it's ancestors
                    //alert(key + ': ' + result[key]); // this will show each key with it's value
                    var value = $(result[key]).val();
                    innerTable += (trOpen + tdOpen + result[key] + " " + key + tdClose + trClose);
                }
            }

            var table = tblOpen + innerTable + tblClose;
            $("#balanceSumDiv").html(table);
        },
        error: function (xhr, ajaxOptions, error) {
            alert('Dohvaćanje sume balance ne valja');
        }
    });
}