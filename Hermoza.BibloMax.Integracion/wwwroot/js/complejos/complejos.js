$(document).ready(function () {
    configurarControles();
});

function configurarControles() {

    llenarCombo();
    cargarData();

}

function llenarCombo() {

    var urlData = $("#__URL_SEDES").val();

    var data = {
    };

    realizarPost(urlData, data, 'json', sucesoLlenarCombo);

}

function sucesoLlenarCombo(data) {

    llenarSelect(data);

}

function llenarSelect(dataJson) {
    var options = dataJson;
    var modelList = document.getElementById("cboSede");
    for (var i in options.data) {
        var opt = document.createElement("option");
        opt.value = options.data[i].idSede;
        opt.textContent = options.data[i].nombre;
        modelList.options.add(opt);
    }
}



function cargarData() {

    $('#btnGuardar').click(function () {
        registro();
    });

    $('#btnLimpiar').click(function () {
        limpiar();
    });

    var urlData = $("#__URL_COMPLEJOS").val();

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
            { "data": "idSede" },
            { "data": "localidad" },
            { "data": "jefe" },
            {
                "data": "idComplejo",
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
        IdComplejo: $('#__ID_ACTUAL').val(),
        SedeCifrado: $('#cboSede').val(),
        Localidad: $('#txtLocalidad').val(),
        Jefe: $('#txtJefe').val(),
        AreaTotal: $('#txtAreas').val()
    };

    realizarPost(urlData, data, 'json', sucesoRegistro);

}

function sucesoRegistro(data) {

    if (!data.resultado.suceso) {
        if (!alert("No se encontraron datos del Complejo.")) { window.location.reload(); }
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
        if (!alert("No se encontraron datos del Complejo.")) { window.location.reload(); }
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

    $('#__ID_ACTUAL').val(datos.resultado.idComplejo);
    $('#cboSede').val(datos.resultado.sedeCifrado);
    $('#txtLocalidad').val(datos.resultado.localidad);
    $('#txtJefe').val(datos.resultado.jefe);
    $('#txtAreas').val(datos.resultado.areaTotal);

}

function limpiar() {
    $('#__ID_ACTUAL').val("");
    $("#cboSede option[value='0']").attr("selected", true);
    $('#txtLocalidad').val("");
    $('#txtJefe').val("");
    $('#txtAreas').val("");
}