using UnityEngine;

public class StartButtonController : MonoBehaviour
{
    public GameObject startButtonContainer;  // Contenedor del botón Start
    public float showDuration = 1f;          // Duración del tiempo en el que se muestra el botón

    // Activar el botón Start
    public void ShowStartButton()
    {
        if (startButtonContainer != null)
        {
            startButtonContainer.SetActive(true);  // Activa el contenedor del botón Start
            Invoke("HideStartButton", showDuration); // Después de la duración, oculta el botón Start
        }
    }

    // Desactivar el botón Start
    void HideStartButton()
    {
        if (startButtonContainer != null)
        {
            startButtonContainer.SetActive(false);  // Desactiva el contenedor del botón Start
        }
    }
}
