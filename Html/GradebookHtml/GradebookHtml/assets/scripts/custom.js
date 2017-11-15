//sidebar menu open close


function openDrop() {
    document.getElementById("sideNavDropdown").classList.toggle("show-lite");
}

// Close the dropdown if the user clicks outside of it
window.onclick = function(event) {
    if (!event.target.matches('.fa-file-text')) {

        var dropdowns = document.getElementsByClassName("dropdown-content-lite");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show-lite')) {
                openDropdown.classList.remove('show-lite');
            }
        }
    }
}