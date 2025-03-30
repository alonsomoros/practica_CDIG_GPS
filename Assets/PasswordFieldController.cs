using UnityEngine;
using UnityEngine.UI;

public class PasswordFieldController : MonoBehaviour
{
    [SerializeField] private InputField passwordField;
    [SerializeField] private Button showPasswordButton;
    [SerializeField] private Image showPasswordIcon; // Referencia a la imagen del botón (opcional)
    [SerializeField] private Sprite eyeOpenSprite; // Sprite para cuando la contraseña es visible
    [SerializeField] private Sprite eyeClosedSprite; // Sprite para cuando la contraseña está oculta

    private string actualPassword = "";
    private bool isPasswordVisible = false;

    void Start()
    {
        // Configurar el campo para que use caracteres de contraseña (asteriscos)
        passwordField.contentType = InputField.ContentType.Password;
        
        // Añadir listener al botón de mostrar/ocultar contraseña
        showPasswordButton.onClick.AddListener(TogglePasswordVisibility);
        
        // Añadir listener para capturar cambios en el texto
        passwordField.onValueChanged.AddListener(OnPasswordChanged);
    }

    private void OnPasswordChanged(string newText)
    {
        // Guardamos la contraseña real
        actualPassword = newText;
    }

    private void TogglePasswordVisibility()
    {
        isPasswordVisible = !isPasswordVisible;
        
        if (isPasswordVisible)
        {
            // Mostrar contraseña en texto plano
            passwordField.contentType = InputField.ContentType.Standard;
            
            // Cambiar el icono si es necesario
            if (showPasswordIcon != null && eyeOpenSprite != null)
            {
                showPasswordIcon.sprite = eyeOpenSprite;
            }
        }
        else
        {
            // Ocultar contraseña con asteriscos
            passwordField.contentType = InputField.ContentType.Password;
            
            // Cambiar el icono si es necesario
            if (showPasswordIcon != null && eyeClosedSprite != null)
            {
                showPasswordIcon.sprite = eyeClosedSprite;
            }
        }
        
        // Es necesario refrescar el campo para que se apliquen los cambios
        passwordField.ForceLabelUpdate();
        
        // Mantener el foco después de cambiar la visibilidad (opcional)
        passwordField.Select();
        passwordField.ActivateInputField();
    }
}