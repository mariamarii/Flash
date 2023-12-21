/*<script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>*/
<script>
$(document).ready(function () {

    $('.radio-group .radio').click(function () {
        $('.radio').addClass('gray');
        $(this).removeClass('gray');
    });

    $('.plus-minus .plus').click(function () {
        var count = $(this).parent().prev().text();
        $(this).parent().prev().html(Number(count) + 1);
    });

    $('.plus-minus .minus').click(function () {
        var count = $(this).parent().prev().text();
        $(this).parent().prev().html(Number(count) - 1);
    });

});
</script >