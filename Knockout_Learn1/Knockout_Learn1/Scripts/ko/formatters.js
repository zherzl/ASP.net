$(function () {
    //console.log(formatValue("10.99"));
});


function formatValue(price) {
    var n, x, s, c;
    n = 2;
    x = price;
    s = '.';
    c = ',';

    var re = '\\d(?=(\\d{' + (x || 3) + '})+' + (n > 0 ? '\\D' : '$') + ')',
    num = x.replace('.', ','); //x.toFixed(Math.max(0, ~~n));
        //num = x;
    return (c ? num.replace('.', c) : num).replace(new RegExp(re, 'g'), '$&' + (s || ','));
}