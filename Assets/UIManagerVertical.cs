using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManagerVertical : MonoBehaviour
{
    public List<InputField> inputFields;
    public Canvas canvasLogin, canvasRegistro, canvasCreditos, canvasNavegacion, canvasDestinosFav;
    public Button IS_botonOlvidadoContrasena, IS_botonLogin, IS_botonRegistro, IS_botonCreditos, C_botonVolverDeCreditos;

    void Start()
    {
        foreach (var input in inputFields)
        {
            input.onEndEdit.AddListener(ConfirmText);
        }
        if (Application.isPlaying)
        {
            Debug.Log("Se está ejecutando.");
        }

        // Deshabilitar todos los Canvas inicialmente
        InicializarCanvas();

        // Configurar eventos para los botones
        ConfigurarEventosBotones();
    }

    private void InicializarCanvas()
    {
        canvasLogin.enabled = true;
        canvasRegistro.enabled = false;
        canvasCreditos.enabled = false;
        canvasNavegacion.enabled = false;
        canvasDestinosFav.enabled = false;
    }

    private void ConfigurarEventosBotones()
    {
        IS_botonOlvidadoContrasena.onClick.AddListener(IS_Boton_OlvidadoContraseña);
        IS_botonCreditos.onClick.AddListener(IS_Boton_InicioSesionCreditos);
        IS_botonRegistro.onClick.AddListener(IS_Boton_InicioSesionRegistro);
        IS_botonLogin.onClick.AddListener(IS_Boton_InicioSesionNavegacion);
        C_botonVolverDeCreditos.onClick.AddListener(C_Boton_Volver);
    }

    public void IS_Boton_InicioSesionCreditos()
    {
        cambiarCanvas(canvasCreditos);
    }

    public void IS_Boton_InicioSesionRegistro()
    {
        cambiarCanvas(canvasRegistro);
    }

    public void IS_Boton_InicioSesionNavegacion()
    {
        cambiarCanvas(canvasNavegacion);
    }

    public void IS_Boton_OlvidadoContraseña()
    {
        cambiarCanvas(canvasRegistro);
    }

    public void C_Boton_Volver()
    {
        cambiarCanvas(canvasLogin);
    }

    public void cambiarCanvas(Canvas canvas)
    {
        canvasLogin.enabled = false;
        canvasRegistro.enabled = false;
        canvasCreditos.enabled = false;
        canvasNavegacion.enabled = false;
        canvasDestinosFav.enabled = false;

        if (canvas != null)
        {
            canvas.enabled = true;
        }
    }

    void ConfirmText(string text)
    {
        Debug.Log("Texto final confirmado: " + text);
    }

}
