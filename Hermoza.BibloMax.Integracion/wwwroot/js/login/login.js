$(document).ready(function () {
    configurarControles();
});


function configurarControles() {
    //obtenerUsuario();

    $('#btnIngresar').click(function () {
        login();
    });

    $('#txtUsuario, #txtPass').keyup(function (e) {
        if (e.keyCode == 13) {
            login();
        }
    });

    function login() {

        bloquearPantalla("Ingresando...");

        $('#contenedorUsuarioInvalido').html('');
        
        var urlData = $("#__URL_LOGIN").val();

        var data = {
            Username: $('#txtUsuario').val(),
            Password: $('#txtPass').val()
        };

        realizarPost(urlData, data, 'json', sucesoLogin);

    }

    function sucesoLogin(datos) {
        desbloquearPantalla();

        if (!datos.completado) {
            if (!alert(datos.mensajes[0])) { window.location.reload(); }
            return;
        }

        location.href = $("#__URL_INDEX").val();

    }

}