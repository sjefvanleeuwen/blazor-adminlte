

var prevMenu = null;

function toggleMenu(el) {
    $(el).next().slideToggle('fast');
}

function hideMenu(el) {
    $(el).next().hide();
}

function toggleSideMenu(el) {
    $(el).slideToggle('fast');
   }

var prevActiveMenu = null;

function activateSideMenu(el) {
    if (el == prevActiveMenu)
        return;
     $(prevActiveMenu).removeClass("active");
     $(el).addClass("active");
     prevActiveMenu = el;
}


function deactivateSideMenu() {
    $('aside').find("li").each(function () { $(this).find("a").removeClass("active") });
}



function addClass(el, _class) {
    $(el).addClass(_class);
  //  $(el).collapse();
}

function pushMenu() {
    $('[data-toggle="push-menu"]').pushMenu('toggle')
}

function toggle(el) {
    $(el).toggle();
}

function removeClass(el, _class) {
    $(el).removeClass(_class);
}

function click(el) {
    $(el).click();
}

function carousel(el) {
    $(el).carousel();
}

function dateRangePicker(dotnetRef, el, range, locale, settings) {
    moment.locale(locale.language);
    $(el).daterangepicker({
        /*timePicker: settings.ShowTimePicker,*/ // not in MVP right now
        startDate: range.From,
        endDate: range.To,
        locale: {
            format: locale.format,
            applyLabel: locale.applyLabel,
            cancelLabel: locale.cancelLabel,
        }
    },function (start, end, label) {
            dotnetRef.invokeMethodAsync('hasChanged',Date.parse(start),Date.parse(end),label);
    });
}

function setTitle(title) {
    document.title = title;
}

function overlay(isActive) {
    if (isActive) {
        $("body").css("overflow-y", "hidden");
    }
    else {
        $("body").css("overflow-y", "auto");
    }
}

function sideBarFixed(isFixed)
{
    if (isFixed) {
        $("body").addClass("layout-fixed");
        $("body").trigger("resize");
    }
    else
        $("body").removeClass("layout-fixed");
}

function navBarFixed(isFixed) {
    if (isFixed) {
        $("body").addClass("layout-navbar-fixed");
        $("body").trigger("resize");
    }
    else
        $("body").removeClass("layout-navbar-fixed");
}

function footerFixed(isFixed) {
    if (isFixed) {
        $("body").addClass("layout-footer-fixed");
        $("body").trigger("resize");
    }
    else
        $("body").removeClass("layout-footer-fixed");
}