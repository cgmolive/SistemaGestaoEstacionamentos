var campoFilto = document.querySelector("#filtro");

campoFilto.addEventListener("input", function () {
    console.log(this.value);
    var carros = document.querySelectorAll(".carro");
    for (var i = 0; i < carros.length; i++) {
        var carro = carros[i];
        var tdPlaca = carro.querySelector(".placa");
        var placa = tdPlaca.textContent;
        var expressao = new RegExp(this.value, "i");

        if (!expressao.test(placa)) {
            carro.classList.add("some")
        } else {
            carro.classList.remove("some")
        }

        if (campoFilto.value == "") {
            carro.classList.remove("some")
        }
    }
});