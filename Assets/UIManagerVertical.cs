using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIManagerVertical : MonoBehaviour
{
    public List<TMP_InputField> inputFields, R_inputFieldsObligatorios, IS_inputFieldsObligatorios;
    public TMP_Dropdown dropdownCombustible;
    public Canvas canvasLogin, canvasRegistro, canvasCreditos, canvasNavegacion, canvasDestinosFav;
    public List<Button> IS_Botones, C_Botones, R_Botones, N_Botones, DF_Botones;
    public GameObject N_panelInicio, N_panelViaje;

    public TMP_Text textoObligatorioNombre, textoObligatorioApellidos, textoObligatorioEmail, textoObligatorioContrasena, textoObligatorioRepetirContrasena,
        R_Text_ConsumoMetrica, N_TiempoEstimado;

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

        foreach (var input2 in R_inputFieldsObligatorios)
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

    void Update()
    {
        // Obtener la hora actual del sistema y sumar 5 minutos
        System.DateTime horaActual = System.DateTime.Now.AddMinutes(5);

        // Mostrar solo la hora y los minutos
        N_TiempoEstimado.text = horaActual.ToString("HH:mm");
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
        N_panelInicio.SetActive(true);
        N_panelViaje.SetActive(false);
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
            if (b.name == "IS_Boton_OlvidadoContraseña")
            {
                b.onClick.AddListener(ISaR_Boton_InicioSesion_OlvidadoContrasena_a_Registro);
            }
            else if (b.name == "IS_Boton_IniciarSesion")
            {
                b.onClick.AddListener(L_Botón_Login_Verificar_Campos);
            }
            else if (b.name == "IS_Boton_InicioSesionRegistro")
            {
                b.onClick.AddListener(ISaR_Boton_InicioSesion_a_Registro);
            }
            else if (b.name == "IS_Boton_InicioSesionCreditos")
            {
                b.onClick.AddListener(ISaC_Boton_InicioSesion_a_Creditos);
            }
        }
    }

    public void configurarEventosBotones_Creditos()
    {
        foreach (Button b in C_Botones)
        {
            if (b.name == "C_Boton_Volver")
            {
                b.onClick.AddListener(CaIS_Boton_Creditos_Volver_a_InicioSesion);
            }
        }
    }

    public void configurarEventosBotones_Registro()
    {
        foreach (Button b in R_Botones)
        {
            if (b.name == "R_Boton_Volver")
            {
                b.onClick.AddListener(RaIS_Boton_Registro_Volver_a_InicioSesion);
            }
            else if (b.name == "R_Boton_Confirmar")
            {
                b.onClick.AddListener(R_Boton_Confirmar);
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
            if (b.name == "N_Boton_AddFavoritos")
            {
                b.onClick.AddListener(N_Boton_AñadirFavorito);
            }
            else if (b.name == "N_Boton_NavegacionFavoritos")
            {
                b.onClick.AddListener(N_Boton_DestinosFavoritos);
            }
            else if (b.name == "N_Boton_IniciarViaje")
            {
                b.onClick.AddListener(N_Boton_IniciarViaje);
            }
            else if (b.name == "N_Boton_TerminarViaje")
            {
                b.onClick.AddListener(N_Boton_TerminarViaje);
            }
        }
    }

    public void ISaR_Boton_InicioSesion_OlvidadoContrasena_a_Registro()
    {
        cambiarCanvas(canvasRegistro);
    }

    public void ISaR_Boton_InicioSesion_a_Registro()
    {
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
        bool contraseñaCorrecta = true;

        foreach (var inputField in R_inputFieldsObligatorios)
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

        Debug.Log("Contaseñas: " + textoObligatorioContrasena.text + " , " + textoObligatorioRepetirContrasena.text );
        // Verificar que las contraseñas coincidan
        if (textoObligatorioContrasena.text != textoObligatorioRepetirContrasena.text)
        {
            contraseñaCorrecta = false;

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


        if (todosRellenados && contraseñaCorrecta)
        {
            cambiarCanvas(canvasLogin);
        }
        else if(!todosRellenados)
        {
            Debug.Log("Por favor, rellena todos los campos obligatorios.");
        }
    }

    private void L_Botón_Login_Verificar_Campos()
    {
        bool todosRellenados = true;

        foreach (var inputField in IS_inputFieldsObligatorios)
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

        if (todosRellenados)
        {
            cambiarCanvas(canvasNavegacion);
        }
        else
        {
            Debug.Log("Por favor, rellena todos los campos obligatorios.");
        }
    }

    public void R_Boton_Confirmar()
    {
        // Aquí puedes agregar la lógica para finalizar el registro o volver a la pantalla de inicio de sesión
        R_Botón_Siguiente_Verificar_Campos_Paso1();
        resetAll(); // Reiniciar todos los campos al finalizar el registro
    }


    public void N_Boton_DestinosFavoritos()
    {
        cambiarCanvas(canvasDestinosFav);
    }

    public void N_Boton_IniciarViaje()
    {
        N_panelInicio.SetActive(false);
        N_panelViaje.SetActive(true);

    }

    public void N_Boton_TerminarViaje()
    {
        N_panelInicio.SetActive(true);
        N_panelViaje.SetActive(false);
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

        foreach (var input2 in R_inputFieldsObligatorios)
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