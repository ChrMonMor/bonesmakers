const boxes = document.querySelectorAll('.selectType');

boxes.forEach(box => {
    box.addEventListener('change', function () {
        this.parentElement.parentElement.className = this.value;
    });
});