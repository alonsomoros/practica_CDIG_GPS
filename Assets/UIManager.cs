using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public List<InputField> inputFields;
    //public Toggle claroOscuro;
    //public Slider slider;
    //public Scrollbar scrollbar;
    public List<Text> displayTexts;
    public Canvas canvasLogin, canvasRegistro, canvasCreditos, canvasNavegacion, canvasDestinosFav;
    public Button botonOlvidadoContrasena, botonLogin, botonRegistro, botonCreditos, botonVolverDeCreditos;

    void Start()
    {
        foreach (var input in inputFields)
        {
            //input.onValueChanged.AddListener(delegate { UpdateText(input); });
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

        botonOlvidadoContrasena.onClick.AddListener(Boton_Login_OlvidadoContrasena);
        botonCreditos.onClick.AddListener(Boton_Login_Creditos);
        botonVolverDeCreditos.onClick.AddListener(Boton_Creditos_Volver);
        botonLogin.onClick.AddListener(Boton_Login_Navegacion);
        botonRegistro.onClick.AddListener(Boton_Login_Registro);

        //claroOscuro.onValueChanged.AddListener(ToggleState);
        //slider.onValueChanged.AddListener(UpdateSlider);
        //scrollbar.onValueChanged.AddListener(UpdateScrollbar);
    }
    public void Boton_Login_Creditos()
    {
        canvasLogin.enabled=false;
        canvasRegistro.enabled=false;
        canvasCreditos.enabled=true;
        canvasNavegacion.enabled=false;
        canvasDestinosFav.enabled=false;
    }

    public void Boton_Login_Registro()
    {
        canvasLogin.enabled=false;
        canvasRegistro.enabled=true;
        canvasCreditos.enabled=false;
        canvasNavegacion.enabled=false;
        canvasDestinosFav.enabled=false;
    }

    public void Boton_Login_Navegacion()
    {
        canvasLogin.enabled=false;
        canvasRegistro.enabled=false;
        canvasCreditos.enabled=false;
        canvasNavegacion.enabled=true;
        canvasDestinosFav.enabled=false;
    }

    public void Boton_Login_OlvidadoContrasena()
    {
        canvasLogin.enabled=false;
        canvasRegistro.enabled=true;
        canvasCreditos.enabled=false;
        canvasNavegacion.enabled=false;
        canvasDestinosFav.enabled=false;
    }

    public void Boton_Creditos_Volver()
    {
        canvasLogin.enabled = true;
        canvasRegistro.enabled = false;
        canvasCreditos.enabled = false;
        canvasNavegacion.enabled = false;
        canvasDestinosFav.enabled = false;
    }

    /*void UpdateText(InputField input)
    {
        int index = inputFields.IndexOf(input); 
        if (index >= 0 && index < displayTexts.Count)
        {
            displayTexts[index].text = "Texto: " + input.text;
        }
    }*/
    void ConfirmText(string text)
    {
        Debug.Log("Texto final confirmado: " + text);
    }

    /*void ToggleState(bool isOn)
    {
        Debug.Log("Toggle está " + (isOn ? "Activado" : "Desactivado"));
    }*/

    /*void UpdateSlider(float value)
    {
        Debug.Log("Valor del slider: " + value);
    }*/

    /*void UpdateScrollbar(float value)
    {
        Debug.Log("Posición del scrollbar: " + value);
    }*/

}