using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public List<InputField> inputFields;
    //public Slider slider;
    //public Scrollbar scrollbar;
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

        canvasLogin.enabled=true;
        canvasRegistro.enabled=false;
        canvasCreditos.enabled=false;
        canvasNavegacion.enabled=false;
        canvasDestinosFav.enabled=false;

        IS_botonOlvidadoContrasena.onClick.AddListener(ISaR_Boton_InicioSesion_OlvidadoContrasena);
        IS_botonCreditos.onClick.AddListener(ISaC_Boton_InicioSesion_Creditos);
        IS_botonRegistro.onClick.AddListener(ISaR_Boton_InicioSesion_Registro);
        IS_botonLogin.onClick.AddListener(ISaN_Boton_InicioSesion_Navegacion);
        C_botonVolverDeCreditos.onClick.AddListener(CaIS_Boton_Creditos_Volver_InicioSesion);

    }
    public void ISaC_Boton_InicioSesion_Creditos()
    {
        canvasLogin.enabled=false;
        canvasRegistro.enabled=false;
        canvasCreditos.enabled=true;
        canvasNavegacion.enabled=false;
        canvasDestinosFav.enabled=false;
    }

    public void ISaR_Boton_InicioSesion_Registro()
    {
        canvasLogin.enabled=false;
        canvasRegistro.enabled=true;
        canvasCreditos.enabled=false;
        canvasNavegacion.enabled=false;
        canvasDestinosFav.enabled=false;
    }

    public void ISaN_Boton_InicioSesion_Navegacion()
    {
        canvasLogin.enabled=false;
        canvasRegistro.enabled=false;
        canvasCreditos.enabled=false;
        canvasNavegacion.enabled=true;
        canvasDestinosFav.enabled=false;
    }

    public void ISaR_Boton_InicioSesion_OlvidadoContrasena()
    {
        canvasLogin.enabled=false;
        canvasRegistro.enabled=true;
        canvasCreditos.enabled=false;
        canvasNavegacion.enabled=false;
        canvasDestinosFav.enabled=false;
    }

    public void CaIS_Boton_Creditos_Volver_InicioSesion()
    {
        canvasLogin.enabled = true;
        canvasRegistro.enabled = false;
        canvasCreditos.enabled = false;
        canvasNavegacion.enabled = false;
        canvasDestinosFav.enabled = false;
    }

    void ConfirmText(string text)
    {
        Debug.Log("Texto final confirmado: " + text);
    }

}