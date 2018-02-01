$(document).ready(function () {
    $(".js-toggle-attendence").click(function (e) {
        const btn = $(e.target);
        if (btn.hasClass("btn-default")) {
            $.post("/api/attendences", { gigId: btn.attr("data-gigId") })
                .done(function () {
                    btn.removeClass("btn-default")
                        .addClass("btn-info")
                        .text("Going");
                    toastr.success("Succeded");

                })
                .fail(function () {
                    toastr.error("Some Wrong");
                });
        } else {
            $.ajax({
                url: `/api/attendences/${btn.attr("data-gigId")}`,
                method: "DELETE"
            })
                .done(function () {
                    btn.removeClass("btn-info")
                        .addClass("btn-default")
                        .text("Going?");
                    toastr.success("Succeded");
                })
                .fail(function () {
                    toastr.error("Some Wrong");

                });
        }


    });
});
