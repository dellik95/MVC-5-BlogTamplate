$(".js-toogle-follow").click(function (e) {
    const btn = $(e.target);
    if (btn.hasClass("btn-default")) {

        $.post("/api/following", { FolloweeId: btn.attr("data-user-id") })

            .done(function () {
                btn.removeClass("btn-default")
                    .addClass("btn-info")
                    .text("UnFollow");
                toastr.success("You are follow");
            }).fail(function () {
                toastr.error("Error");
            });
    } else {
        $.ajax({
            url: `/api/following/${btn.attr("data-user-id")}`,
            method: "DELETE"
        })
            .done(function () {
                btn.removeClass("btn-info")
                    .addClass("btn-default")
                    .text("Following?");
            });
    }
});