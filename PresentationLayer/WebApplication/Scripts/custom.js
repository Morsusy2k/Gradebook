$(document).ready(function () {
    /* Grades colapsing */
    $('.main-grades-collapse').click(function () {
        var div = $(this).parent().siblings('.main-grades-more');
        var icon = $(this).children('.zmdi');
        if (!div.hasClass('main-shown')) {
            div.css('display', 'inline-block');
            var height = div.height();
            div.css('display', 'block').css('height', '0').animate({ height: height }, 250).addClass('main-shown');
            icon.removeClass('zmdi-plus-square').addClass('zmdi-minus-square');
        } else {
            div.animate({ height: 0 }, 250, function () {
                div.removeClass('main-shown').css('display', 'none').css('height', 'auto');
                icon.removeClass('zmdi-minus-square').addClass('zmdi-plus-square');
            });
        }
    });

    /* Final grade separation */
    $('.mark-final').parent().addClass('mark-separator');
    $('.mark-final').parent().appendTo().parent();

    /* Student calculated average */
    $('.main-collapse').each(function () {
        var n = 0;
        var s = 0;
        $(this).find('.mark-final').each(function () {
            s += parseInt($(this).text());
            n++;
        });
        var a = s / n;
        $(this).find('.main-grades-grade').append(" (" + a.toFixed(2) + ")");

    });

    /* Search function */
    function Equals(a, b) {
        if (a.indexOf(b) != -1) {
            return true;
        } else {
            return false;
        }
    }
    $("#search").keyup(function () {
        var search = $("#search").val().toLowerCase();
        $(".main-table-row").each(function () {
            $(this).children().each(function () {
                if (!Equals($(this).text().toLowerCase(), search)) {
                    $(this).parent().hide();
                } else {
                    $(this).parent().show();
                    return false;
                }
            });
        });
    });

    /* Lavalamp menu */
    $('#nav-lava').lavalamp({
        easing: 'easeOutBack',
        duration: 200,
        deepFocus: true
    });

    /* Dropdown menu field */
    $('.dropdown-lite').mouseenter(function () {
        $(this).children('.dropdown-content-lite').show();
    }).mouseleave(function () {
        $(this).children('.dropdown-content-lite').hide();
    });

    /* Confirmation upon delete */
    $(function () {
        $('.delete-button').click(function () {
            return confirm("Are you sure you want to delete?");
        });
    });

    /* Field of study subjects checkbox colector */
    $(".main-subject-cbox").change(function () {
        var values = "";
        $(".main-subject-cbox:checked").each(function () {
            values += $(this).attr("name") + "/";
        });
        $("#SubjectString").val(values);
        $("#RolesString").val(values);
    });
});