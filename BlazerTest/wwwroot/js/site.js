window.getCheckboxState = function (id) {
    const checkbox = document.getElementById(id);
    return checkbox ? checkbox.checked : false;
};