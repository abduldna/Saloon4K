function step1() {
    if ($('#step1').css('display') == 'none') {
        removeClasses();
        $("#step1").show('slow');
        $("#ancstep1").addClass("stepActive");
    }
    return false;
}

function step2() {
    if ($('#step2').css('display') == 'none') {
        removeClasses();
        $("#step2").show('slow');
        $("#ancstep2").addClass("stepActive");
    }
    return false;
}
function step3() {
    if ($('#step3').css('display') == 'none') {
        removeClasses();
        $("#step3").show('slow');
        $("#ancstep3").addClass("stepActive");
    }
    return false;
}
function step4() {
    if ($('#step4').css('display') == 'none') {
        removeClasses();
        $("#step4").show('slow');
        $("#ancstep4").addClass("stepActive");
    }
    return false;
}

function removeClasses() {
    $("#step1").hide('slow');
    $("#step2").hide('slow');
    $("#step3").hide('slow');
    $("#step4").hide('slow');
    $("#ancstep1").removeClass("stepActive");
    $("#ancstep2").removeClass("stepActive");
    $("#ancstep3").removeClass("stepActive");
    $("#ancstep4").removeClass("stepActive");
}

function RemoveSelectPageActiveClass() {
    $("#body_btnHome").removeClass("btnPageActive");
    $("#body_btnDeals").removeClass("btnPageActive");
    $("#body_btnDirectory").removeClass("btnPageActive");
    $("#body_btnMySalon4k").removeClass("btnPageActive");
    $("#body_btnAboutUs").removeClass("btnPageActive");
    $("#body_btnContactUs").removeClass("btnPageActive");
    $("#body_btnPopup").removeClass("btnPageActive");
}
function RemoveCountryFlagClass() {
    $("#body_btnUae").removeClass("btnCountryFlagActive");
    $("#body_btnKuwait").removeClass("btnCountryFlagActive");
    $("#body_btnSaudiArabia").removeClass("btnCountryFlagActive");    
}