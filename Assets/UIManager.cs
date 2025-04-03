using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public List<TMP_InputField> inputFields, inputFieldsObligatorios;
    public TMP_Dropdown dropdownCombustible;
    public Canvas canvasLogin, canvasRegistro, canvasCreditos, canvasNavegacion, canvasDestinosFav;
    public List<Button> IS_Botones, C_Botones, R_Botones, N_Botones, DF_Botones;
    /*public Button C_botonVolverDeCreditos, 
    R_botonVolverDeRegistro, R_botonSiguientePaso1, R_botonVolverPaso2, R_botonSiguientePaso2, R_botonVolverPaso3, R_botonTerminarPaso3,

    N_botonDestinosFavoritos, N_IniciarViaje, N_AñadirFavorito, N_botonLogo,
    DF_botonVolverDeDestinoFavorito, DF_botonCasa, DF_botonTrabajo, DF_botonDestinoFav1, DF_botonDestinoFav2, DF_botonDestinoReciente1, DF_botonDestinoReciente2;*/

    public GameObject R_panelPaso1, R_panelPaso2, R_panelPaso3;

    public TMP_Text textoObligatorioNombre, textoObligatorioApellidos, textoObligatorioEmail, textoObligatorioContrasena, textoObligatorioRepetirContrasena,
    indicePaso1, indicePaso2, indicePaso3,
    R_Text_ConsumoMetrica;

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

        foreach (var input2 in inputFieldsObligatorios)
        {
            input2.onEndEdit.AddListener(ConfirmText);
        }
        if (Application.isPlaying)
        {
            Debug.Log("Se está ejecutando.");
        }

        // Asegúrate de que el dropdown y el texto estén asignados
        if (dropdownCombustible != null && R_Text_ConsumoMetrica != null)
        {
            // Suscribirse al evento onValueChanged del dropdown
            dropdownCombustible.onValueChanged.AddListener(OnDropdownValueChanged);
        }

        // Deshabilitar todos los Canvas inicialmente
        InicializarCanvas();
        InicializarPaneles();

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

    private void InicializarPaneles()
    {
        R_panelPaso1.SetActive(true);
        R_panelPaso2.SetActive(false);
        R_panelPaso3.SetActive(false);
    }

    private void ConfigurarEventosBotones() 
    {
        configurarEventosBotones_InicioSesion();
        configurarEventosBotones_Registro();
        configurarEventosBotones_Creditos();
        configurarEventosBotones_Navegacion();
        configurarEventosBotones_DestinosFavoritos();
    }

    public void configurarEventosBotones_InicioSesion()
    {
        foreach (Button b in IS_Botones)
        {
            if (b.name == "IS_Botón_OlvidadoContraseña")
            {
                b.onClick.AddListener(ISaR_Boton_InicioSesion_OlvidadoContrasena_a_Registro);
            }
            else if (b.name == "IS_Botón_IniciarSesión-Navegación")
            {
                b.onClick.AddListener(ISaN_Boton_InicioSesion_a_Navegacion);
            }
            else if (b.name == "IS_Boton_Regístrate")
            {
                b.onClick.AddListener(ISaR_Boton_InicioSesion_a_Registro);
            }
            else if (b.name == "IS_Botón_IniciarSesión-Créditos")
            {
                b.onClick.AddListener(ISaC_Boton_InicioSesion_a_Creditos);
            }
        }        
    }

    public void configurarEventosBotones_Creditos()
    {
        foreach (Button b in C_Botones)
        {
            if (b.name == "C_Button_Volver_a_Login")
            {
                b.onClick.AddListener(CaIS_Boton_Creditos_Volver_a_InicioSesion);
            }
        }   
    }

    public void configurarEventosBotones_Registro()
    {
        foreach (Button b in R_Botones)
        {
            if (b.name == "R_Button_Volver_a_Login")
            {
                b.onClick.AddListener(RaIS_Boton_Registro_Volver_a_InicioSesion);
            }
            else if (b.name == "R_Button_Siguiente_Paso1")
            {
                b.onClick.AddListener(R_Botón_Siguiente_Verificar_Campos_Paso1);
            }
            else if (b.name == "R_Button_Volver_Paso2")
            {
                b.onClick.AddListener(R_Boton_Volver_Paso2);
            }
            else if (b.name == "R_Button_Siguiente_Paso2")
            {
                b.onClick.AddListener(R_Boton_Siguiente_Paso2);
            }
            else if (b.name == "R_Button_Volver_Paso3")
            {
                b.onClick.AddListener(R_Boton_Volver_Paso3);
            } 
            else if (b.name == "R_Button_Terminar_Paso3")
            {
                b.onClick.AddListener(R_Boton_Terminar_Paso3);
            }
        }       
    }

    public void configurarEventosBotones_DestinosFavoritos()
    {
        foreach (Button b in DF_Botones)
        {
            b.onClick.AddListener(DF_Boton_Volver_a_Navegación);
        }
    }

    public void configurarEventosBotones_Navegacion()
    {
        foreach (Button b in N_Botones)
        {
            if (b.name == "N_Button_AñadirFav")
            {
                b.onClick.AddListener(N_Boton_DestinosFavoritos);
            }
            else if (b.name == "N_Button_DetinosFav")
            {
                b.onClick.AddListener(N_Boton_IniciarViaje);
            }
            else if (b.name == "N_Button_IniciarViaje")
            {
                b.onClick.AddListener(N_Boton_AñadirFavorito);
            }
            else if (b.name == "N_Button_Logo")
            {
                b.onClick.AddListener(CaIS_Boton_Creditos_Volver_a_InicioSesion);
            }
        }        
    }

    public void ISaR_Boton_InicioSesion_OlvidadoContrasena_a_Registro()
    {
        R_panelPaso1.SetActive(true);
        indicePaso1.color = Color.green;
        indicePaso2.color = Color.white;
        indicePaso3.color = Color.white;
        cambiarCanvas(canvasRegistro);
    }

    public void ISaN_Boton_InicioSesion_a_Navegacion()
    {
        cambiarCanvas(canvasNavegacion);
    }
    
    public void ISaR_Boton_InicioSesion_a_Registro()
    {
        R_panelPaso1.SetActive(true);
        indicePaso1.color = Color.green;
        indicePaso2.color = Color.white;
        indicePaso3.color = Color.white;
        cambiarCanvas(canvasRegistro);
    }

    public void ISaC_Boton_InicioSesion_a_Creditos()
    {
        cambiarCanvas(canvasCreditos);
    }


    public void CaIS_Boton_Creditos_Volver_a_InicioSesion()
    {
        cambiarCanvas(canvasLogin);
    }


    public void RaIS_Boton_Registro_Volver_a_InicioSesion()
    {
        cambiarCanvas(canvasLogin);
    }

    private void R_Botón_Siguiente_Verificar_Campos_Paso1()
    {
        bool todosRellenados = true;

        foreach (var inputField in inputFieldsObligatorios)
        {

            Debug.Log("Procesando campo: " + inputField.name);

            if (string.IsNullOrWhiteSpace(inputField.text)) // Comprobar si el campo está vacío
            {
                todosRellenados = false;

                // Cambiar el color del borde o texto del InputField a rojo
                if (ColorUtility.TryParseHtmlString("#FFCCCC", out Color softRed))
                {
                    inputField.image.color = softRed; // Cambiar el fondo a un rojo suave
                }
            }
            else
            {
                // Restaurar el color original si el campo está rellenado
                inputField.image.color = Color.white; // Cambia al color original
            }
        }

        // Verificar que las contraseñas coincidan
        if (textoObligatorioContrasena.text != textoObligatorioRepetirContrasena.text)
        {
            todosRellenados = false;

            // Cambiar el color de los campos de contraseña a rojo
            if (ColorUtility.TryParseHtmlString("#bf4934", out Color softRed_v2))
            {
                textoObligatorioContrasena.color = softRed_v2;
                textoObligatorioRepetirContrasena.color = softRed_v2;
            }

            Debug.Log("Las contraseñas no coinciden.");

        }
        else
        {
            // Restaurar el color original si las contraseñas coinciden
            textoObligatorioContrasena.color = Color.black;
            textoObligatorioRepetirContrasena.color = Color.black;
        }
        

        if (todosRellenados)
        {
            // Avanzar al siguiente panel si todos los campos están rellenados
            R_panelPaso1.SetActive(false);
            R_panelPaso2.SetActive(true);
            indicePaso2.color = Color.green;
            indicePaso1.color = Color.white;
        }
        else
        {
            Debug.Log("Por favor, rellena todos los campos obligatorios.");
        }
    }

    public void R_Boton_Volver_Paso2()
    {
        R_panelPaso1.SetActive(true);
        R_panelPaso2.SetActive(false);
        indicePaso1.color = Color.green;
        indicePaso2.color = Color.white;
    }

    public void R_Boton_Siguiente_Paso2()
    {
        R_panelPaso2.SetActive(false);
        R_panelPaso3.SetActive(true);
        indicePaso2.color = Color.white;
        indicePaso3.color = Color.green;
    }

    public void R_Boton_Volver_Paso3()
    {
        R_panelPaso2.SetActive(true);
        R_panelPaso3.SetActive(false);
        // Cambiar el color a verde
        indicePaso2.color = Color.green;
        indicePaso3.color = Color.white;
    }

    public void R_Boton_Terminar_Paso3()
    {
        R_panelPaso3.SetActive(false);
        // Aquí puedes agregar la lógica para finalizar el registro o volver a la pantalla de inicio de sesión
        cambiarCanvas(canvasLogin);
        resetAll(); // Reiniciar todos los campos al finalizar el registro
    }


    public void N_Boton_DestinosFavoritos()
    {
        cambiarCanvas(canvasDestinosFav);
    }

    public void N_Boton_IniciarViaje()
    {
        cambiarCanvas(canvasDestinosFav);
    }

    public void N_Boton_AñadirFavorito()
    {
        Debug.Log("<[ Añadido a Favoritos ]>");
    }

    public void DF_Boton_Volver_a_Navegación()
    {
        cambiarCanvas(canvasNavegacion);
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

    public void resetAll()
    {
        foreach (var input in inputFields)
        {
            input.text = string.Empty;
            input.image.color = Color.white; // Cambia al color original
        }

        foreach (var input2 in inputFieldsObligatorios)
        {
            input2.text = string.Empty;
            input2.image.color = Color.white; // Cambia al color original
        }
    }

    void OnDropdownValueChanged(int value)
    {
        // Cambiar el texto dependiendo del valor seleccionado
        switch (value)
        {
            case 0:
                R_Text_ConsumoMetrica.text = "[ L/100 km ]";
                break;
            case 1:
                R_Text_ConsumoMetrica.text = "[ L/100 km ]";
                break;
            case 2:
                R_Text_ConsumoMetrica.text = "[ KWh/100 km ]";
                break;
            default:
                R_Text_ConsumoMetrica.text = "";
                break;
        }
    }
}