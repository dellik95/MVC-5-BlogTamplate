$(document).ready(function() {
    $(".js-toggle-attendence").click(function(e) {
        let btn = $(e.target);
        $.post("/api/attendences", { gigId: btn.attr("data-gigId") })
            .done(function() {
                btn.removeClass("btn-default")
                    .addClass("btn-info")
                    .text("Going");
                toastr.success("Succeded");
            }).fail(function() {
                toastr.error("Some Wrong");

            });
    });
});