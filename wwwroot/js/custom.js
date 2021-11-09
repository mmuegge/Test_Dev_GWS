// Alert-Box, noch nicht benutzt
function functionAlert(msg, myYes) {
    var confirmBox = $("#confirm");
    confirmBox.find(".message").text(msg);
    confirmBox.find(".yes").unbind().click(function () {
        confirmBox.hide();
    });
    confirmBox.find(".yes").click(myYes);
    confirmBox.show();
}


// Pruefen ob Ablesesdatum in der Zukunft liegt, wenn ja Rückgabe=true sonst false
function pruefeDatum(heute, ablesedatum) {
    var datumAblesen = new Date(ablesedatum);                              // Datum-String in Datum wandeln

    var jahrHeute = parseInt(heute.getFullYear());
    var monatHeute = parseInt(heute.getMonth()) +1;                        // hier +1 da getMonth bei 0 anfängt (Januar=0)
    var tagHeute = parseInt(heute.getDate());                              // getDate --> getDay gibt Tag der Woche  an

    var jahrAblesen = parseInt(datumAblesen.getFullYear());
    var monatAblesen = parseInt(datumAblesen.getMonth()) + 1;              // hier +1 da getMonth bei 0 anfängt (Januar=0)
    var tagAblesen = parseInt(datumAblesen.getDate());

    if (jahrHeute >  jahrAblesen) {          
        return false;
    }
    else if (monatHeute > monatAblesen) {           
        return false;
    }
    else if (tagHeute >= tagAblesen) {               
        return false;
    }
    else {
        /*zeigeFehlermeldung("Ablesedatum liegt in der Zukunft!");*/
        toastr.error("Ablesedatum liegt in der Zukunft!");
        return true;                                               // Datum liegt nicht in der Zunkunft
    }
}

// Fehlermeldungen anzeigen (ist noch nicht ganz fertig)
function zeigeFehlermeldung(meldung) {
    alert(meldung);
}

//Numerische Eingabefelder Hintergrund gelb & löschen von "0"
function emptyInput(x) {
    x.style.background = "yellow";
    if (x.value = "0") {
        x.value = "";
    }
}

// prüfen ob Eingabe eine Zahl ist
function isNumber(eingabe) {
    var zahl = parseFloat(eingabe);
    if (isNaN(zahl)) {
        return false;
    }
    return true;
}

// Dezimalpunkt gegen Dezimalkomma ersetzen
function replaceDecimalPoint(eingabe) {
    if (eingabe.indexOf('.' > -1)) {
        let inputStr = eingabe;
        inputStr = inputStr.replace(".", ",");
        return inputStr;
    }
}

function filterInput(decSeparator, input, event) {
    let zahlenStr = '0123456789';
    if (event.key == 'Delete' || event.key == 'Backspace' || event.key == ',' || event.key == 'ArrowLeft' || event.key == 'ArrowRight') {
        if (event.key == decSeparator) {
            // ist das erste Zeichen ein Dezimalkomma?
            if (input.length == 0) {
                event.preventDefault();
            }
            // gibt es schon ein Dezimalkomma
            if (input.lastIndexOf(decSeparator) != -1) {
                event.preventDefault();
            }
        }
        return;
    }
    else {
        // prüfen ob Eingabezeichen Teil des zahlenStr ist
        if (zahlenStr.indexOf(event.key) <= -1) {
            event.preventDefault();
        }
    }
}


