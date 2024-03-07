$(document).ready(function () {
    $('.js-delete').on('click', function () {

        var ntn = $(this);
        console.log("m");
        $.ajax({
            url: `/Game/Delete/${ntn.data('id')}`,
            method: 'DELETE',
            success: function () {
                alert('success');
            }
        });
    });

});
