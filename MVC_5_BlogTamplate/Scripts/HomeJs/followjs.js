$(".js-toogle-follow").click(function(e) {
    const btn = $(e.target);

    $.post("/api/following", { followeeId: btn.attr("data-user-id") }).done(function() {
        btn.text("Follow");
        toastr.success("You are follow");
    }).fail(function() {
        toastr.error("Error");
    });
})