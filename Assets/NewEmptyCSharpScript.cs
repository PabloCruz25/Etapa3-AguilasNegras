using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonManager : MonoBehaviour
{
    public GameObject startButtonContainer; // Contenedor del botón Start
    public Button[] characterButtons; // Botones de los personajes
    private int charactersSelected = 0;

    void Start()
    {
        // Aseguramos que el Start Button esté oculto al principio
        startButtonContainer.SetActive(false);

        // Hacemos que los botones de personajes estén activos al inicio
        foreach (Button button in characterButtons)
        {
            button.gameObject.SetActive(true);  // Aseguramos que estén visibles al inicio
        }
    }

    public void OnCharacterSelected()
    {
        charactersSelected++;

        // Cuando se seleccionan los 4 personajes, ocultamos los botones
        if (charactersSelected == 4)
        {
            // Ocultamos los botones de los personajes
            foreach (Button button in characterButtons)
            {
                button.gameObject.SetActive(false);
            }

            // Esperamos 1 segundo antes de mostrar el botón Start
            StartCoroutine(ShowStartButton());
        }
    }

    private IEnumerator ShowStartButton()
    {
        // Esperamos un segundo
        yield return new WaitForSeconds(1f);

        // Mostramos el Start Button
        startButtonContainer.SetActive(true);
    }
}
