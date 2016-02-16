(function () {
    var pauseButton = document.getElementById("control-video");
    var vid = document.getElementById("bgvid");

    pauseButton.addEventListener("click", function () {
        vid.classList.toggle("stopfade");
        if (vid.paused) {
            vid.play();
            pauseButton.innerHTML = "Pause Video";
        } else {
            vid.pause();
            pauseButton.innerHTML = "Play Video";
        }
    })
})();