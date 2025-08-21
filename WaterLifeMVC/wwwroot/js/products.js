const input = document.getElementById("img-input");
const image_display = document.getElementById("img-display");

input.addEventListener("change", updateImage);

function updateImage() {
    const file = this.files[0]
    if (!file) return;

    const reader = new FileReader();
    reader.onload = function (e) {
        image_display.src = e.target.result;
    };
    reader.readAsDataURL(file)
}