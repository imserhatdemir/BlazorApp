$(".add-favorites").on("click", (e) => {
    let className = $(e.target).hasClass("selected");
    if (className) {
        $(e.target).removeClass("fa-solid");
        $(e.target).removeClass("selected");
        $(e.target).addClass("fa-regular");
    }
    else {
        $(e.target).removeClass("fa-regular");
        $(e.target).addClass("selected");
        $(e.target).addClass("fa-solid");
    }
});