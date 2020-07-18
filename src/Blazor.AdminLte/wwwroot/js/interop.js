function toggleMenu(el) {
    $(el).next().slideToggle('fast');
}

function hideMenu(el) {
    $(el).next().hide();
}

function toggleSideMenu(el) {
    $(el).slideToggle('fast');
    
}

function addClass(el, _class) {
    $(el).addClass(_class);
  //  $(el).collapse();
}

function pushMenu() {
    $('[data-toggle="push-menu"]').pushMenu('toggle')
}

function toggle() {
    $(el).toggle();
}

function removeClass(el, _class) {
    $(el).removeClass(_class);
}

function click(el) {
    $(el).click();
}