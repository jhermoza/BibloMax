$(document).ready(function () {
    configurarControles();
});

function configurarControles() {

    cargarData();

}

function cargarData() {

    $('#btnGuardar').click(function () {
        registro();
    });

    $('#btnLimpiar').click(function () {
        limpiar();
    });

    var urlData = $("#__URL_SEDES").val();

    $('#example').DataTable({
        "bJQueryUI": true,
        //"processing": true,
        "serverSide": true,
        "bFilter": false,
        "bSort": false,
        "paging": false,
        //"bInfo": false,
        "ajax": {
            "url": urlData,
            "type": "POST"
        },
        "columns": [
            { "data": "nombre" },
            { "data": "ubicacion" },
            { "data": "nroComplejos" },
            {
                "data": "idSede",
                "render": function (data, type, row) {
                    return '<a onclick="detalle(\'' + data + '\')" href="javascript:void(0);" style="margin-right:3px; padding: 5px 10px; background-color: #343a40; border-radius:2px; font-size:14px;">Editar</a>'
                        + '<a onclick="eliminar(\'' + data + '\')" href="javascript:void(0);" style="margin-left:3px; padding: 5px 10px; background-color: #343a40; border-radius:2px; font-size:14px;">Eliminar</a>';

                }
            },
        ],
        "bDestroy": true
    });

}

function registro() {

    var urlData = $("#__URL_REGISTRO").val();

    var data = {
        IdSede: $('#__ID_ACTUAL').val(),
        Nombre: $('#txtNombre').val(),
        Ubicacion: $('#txtUbicacion').val(),
        NroComplejos: $('#txtComplejos').val(),
        Presupuesto: $('#txtPresupuesto').val()
    };

    realizarPost(urlData, data, 'json', sucesoRegistro);

}

function sucesoRegistro(data) {

    if (!data.resultado.suceso) {
        if (!alert("No se encontraron datos de la Sede.")) { window.location.reload(); }
    }

    if (!alert(data.resultado.mensaje)) { window.location.reload(); }

    $("#__ID_ACTUAL").val("");

}

function eliminar(id) {

    if (confirm("¿Desea eliminar el registro?")) {
        bloquearPantalla("Eliminando");
        var urlEliminar = $("#__URL_ELIMINAR").val();
        realizarPost(urlEliminar, {
            id: id
        }, 'json', fEliminarSuceso);
    }

}

function fEliminarSuceso(data) {
    desbloquearPantalla();

    if (!data.resultado.suceso) {
        if (!alert("No se encontraron datos de la Sede.")) { window.location.reload(); }
    }

    if (!alert(data.resultado.mensaje)) { window.location.reload(); }

}

function detalle(id) {

    bloquearPantalla("Leyendo dato");
    var urlDetalle = $("#__URL_DETALLE").val();
    realizarPost(urlDetalle, {
        id: id
    }, 'json', fDetalleSuceso);

}

function fDetalleSuceso(datos) {
    desbloquearPantalla();

    console.log(datos);

    $('#__ID_ACTUAL').val(datos.resultado.idSede);
    $('#txtNombre').val(datos.resultado.nombre);
    $('#txtUbicacion').val(datos.resultado.ubicacion);
    $('#txtComplejos').val(datos.resultado.nroComplejos);
    $('#txtPresupuesto').val(datos.resultado.presupuesto);

}

function limpiar() {
    $('#__ID_ACTUAL').val("");
    $('#txtNombre').val("");
    $('#txtUbicacion').val("");
    $('#txtComplejos').val("");
    $('#txtPresupuesto').val("");
}