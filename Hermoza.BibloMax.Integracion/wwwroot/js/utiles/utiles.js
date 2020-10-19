var ModoSms = {
    Normal: 1,
    C2c: 2,
    C2w: 3,
    C2f: 4
};

function bloquearPantalla(mensaje) {
    miMensaje = '<div class="cargando">' +
        ' <div class="pre-cargando">' +
        ' <div class="spinner-layer pl-blue">' +
        ' <div class="circle-clipper left">' +
        ' <div class="circle"></div>' +
        ' </div>' +
        ' <div class="circle-clipper right">' +
        ' <div class="circle"></div>' +
        ' </div>' +
        ' </div>' +
        ' </div>' +
        ' </div>';
    if (mensaje) {
        miMensaje += '<p style="color:#03A9F4;font-size:14px;font-weight:bold;">' + mensaje + "</p>";
    } else {
        miMensaje += '<p style="color:#03A9F4;font-size:14px;font-weight:bold;"> ... </p>';
    }
    //miMensaje = '<div class="contenedor-cargando-espera" ><img src="' + $('#__HDN_LOADING_GIF').val() + '" class="esperar-imagen-carga" /> ';
    //if (mensaje) {
    //    miMensaje += '<div class="esperar-texto-carga">' + mensaje + "</div>";
    //} else {
    //    miMensaje += '<div class="esperar-texto-carga">Realizando operación</div>';
    //}

    miMensaje += "</div>";

    $.blockUI({
        baseZ: 3000,
        message: miMensaje,
        css: {
            top: ($(window).height() - 101) / 2 + 'px',
            left: ($(window).width() - 128) / 2 + 'px',
            width: '128px',
            border: 'none'
        }
    });
}


function llamando(mensaje) {
    miMensaje = '<div style="background:rgba(0, 0, 0, 0.00)"><img src="' + $('#__HDN_LLAMANDO_GIF').val() + '" width="40px"/> ';
    if (mensaje) {
        miMensaje += '<div>' + mensaje + '</div>'
    }

    miMensaje += "</div>";

    $.blockUI({
        baseZ: 3000,
        message: miMensaje,
        css: {
            top: ($(window).height() - 101) / 2 + 'px',
            left: ($(window).width() - 128) / 2 + 'px',
            width: '128px',
            border: 'none'
        }
    });
}

function desbloquearPantalla() {
    $.unblockUI();
}

function realizarPost(url, datos, tipoRespuesta, fSuceso, fError, timeoutAjax, noRedireccionar) {

    var timeoutDefecto = 1000 * 60;
    if (timeoutAjax) {
        timeoutDefecto = 1000 * timeoutAjax;
    }
    //console.log(timeoutDefecto);

    var xhr = $.ajax({
        type: "POST",
        url: url,
        dataType: tipoRespuesta,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datos),
        success: function (data) {
            if (fSuceso) {
                fSuceso(data);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ': ' + errorThrown);
            desbloquearPantalla();

            if (jqXHR.status == 403) {
                alert("Su sesión acaba de expirar. Por favor ingrese de nuevo su login");
                var respuestaRedireccion = JSON.parse(jqXHR.responseText);
                location.href = respuestaRedireccion.urlLogin;
            }

            if (fError) {
                fError(jqXHR, textStatus, errorThrown);
            }

        },
        timeout: timeoutDefecto
    });
    return xhr;
}

function realizarPost2(url, datos, tipoRespuesta, fSuceso, fError, timeoutAjax, noRedireccionar) {

    var timeoutDefecto = 1000 * 60;
    if (timeoutAjax) {
        timeoutDefecto = 1000 * timeoutAjax;
    }
    //console.log(timeoutDefecto);

    var xhr = $.ajax({
        type: "POST",
        url: url,
        dataType: tipoRespuesta,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datos),
        success: function (data) {
            if (fSuceso) {
                fSuceso(data);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ': ' + errorThrown);
            desbloquearPantalla();

            if (fError) {
                fError(jqXHR, textStatus, errorThrown);
            }

        },
        timeout: timeoutDefecto
    });
    return xhr;
}

function llenarCombo(url, datos, idCombo) {
    $.ajax({
        type: "POST",
        url: url,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datos),
        success: function (data) {
            $('#' + idCombo)
                .find('option')
                .remove()
                .end();

            for (i = 0; i < data.length; i++) {
                var option = data[i];
                $('#' + idCombo)
                    .append('<option value="' + option.valor + '">' + option.texto + '</option>');
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ': ' + errorThrown);
            if (fError) {
                fError(jqXHR, textStatus, errorThrown);
            }

        }
    });
}

function soloNumeros(e) {
    tecla = (document.all) ? e.keyCode : e.which;

    //Tecla de retroceso para borrar, siempre la permite
    if (tecla == 8) {
        return true;
    }

    // Patron de entrada, en este caso solo acepta numeros
    patron = /[0-9]/;
    tecla_final = String.fromCharCode(tecla);
    return patron.test(tecla_final);
}

function soloLetras(e) {
    tecla = (document.all) ? e.keyCode : e.which;

    if (tecla == 8) return true;

    patron = /[A-Za-z]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}


function validarError(xhr) {
    if (xhr.status === 403) {
        var datoError = $.parseJSON(xhr.responseText);
        location.href = datoError.urlLogin;
    } else {
        alert('Ocurrio un error, contactar con soporte');
    }
}

function validarErrorGrilla(xhr, textStatus, error) {
    validarError(xhr);
}

function configurarDatatableSimpleComparacion() {
    jQuery.fn.dataTableExt.oSort["simple-compare-pre"] = function (a) {
        var matches = a.match(/\[(.*?)\]/);
        return parseInt(matches[1]);
    };

    jQuery.fn.dataTableExt.oSort["simple-compare-desc"] = function (x, y) {
        return y - x;
    };

    jQuery.fn.dataTableExt.oSort["simple-compare-asc"] = function (x, y) {
        return x - y;
    };
}

function ponerParaIngresarSoloPlaca(idItem) {
    $('#' + idItem).keydown(function (e) {
        if (e.shiftKey || e.ctrlKey || e.altKey) {
            e.preventDefault();
        } else {
            var key = e.keyCode;
            if (!((key == 8) || (key == 32) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105))) {
                e.preventDefault();
            }

            if (key === 32) {
                e.preventDefault();
            }
        }
    });
}

function obtenerValorOVacio(valor) {
    if (!valor) {
        return "";
    }

    return valor;
}

function obtenerValorONumero(valor) {
    if (!valor) {
        return 0;
    }

    return valor;
}


function obtenerEstadoNombreSms(idEstado) {
    var estado = "";
    switch (idEstado) {
        case 1:
            estado = "Creado";
            break;
        case 2:
            estado = "Procesado";
            break;
        case 3:
            estado = "Enviado";
            break;
        case 4:
            estado = "Recibido";
            break;
        case 5:
            estado = "Invalido";
            break;
        case 6:
            estado = "Clickeado";
            break;
    }

    return estado;
}

function obtenerEstadoNombreIvr(idEstado) {
    var estado = "";
    switch (idEstado) {
        case 0:
            estado = "Pendiente";
            break;
        case 1:
            estado = "Creado";
            break;
        case 2:
            estado = "Procesado";
            break;
        case 3:
            estado = "Enviado";
            break;
        case 4:
            estado = "No Contestado";
            break;
        case 5:
            estado = "Invalido";
            break;
        case 6:
            estado = "Clickeado";
            break;
        case 7:
            estado = "Contestado";
            break;
    }

    return estado;
}

function numeroConComas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

function goBack() {
    window.history.back();
}