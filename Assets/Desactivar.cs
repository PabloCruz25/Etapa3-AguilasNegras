using System.Collections;
using UnityEngine;

public class StartButtonControl : MonoBehaviour
{
    public GameObject startButtonContainer;  // El contenedor del botón Start
    public float delayBeforeStart = 1f;      // Tiempo de espera antes de que el botón Start desaparezca
    public float delayBeforeHideStart = 1f;  // Tiempo de espera después de activar Start antes de ocultarlo

    private void OnEnable()
    {
        // Llamar al método que controlará el botón Start
        StartCoroutine(ControlStartButton());
    }

    private IEnumerator ControlStartButton()
    {
        // Espera antes de mostrar el botón Start
        yield return new WaitForSeconds(delayBeforeStart);

        // Mostrar el botón Start
        if (startButtonContainer != null)
        {
            startButtonContainer.SetActive(true);
        }

        // Esperar un segundo y luego ocultar el botón
        yield return new WaitForSeconds(delayBeforeHideStart);

        // Desactivar el botón Start
        if (startButtonContainer != null)
        {
            startButtonContainer.SetActive(false);
        }
    }
}
