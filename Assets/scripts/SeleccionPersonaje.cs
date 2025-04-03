using UnityEngine;

public class SeleccionPersonaje : MonoBehaviour
{
    public GameObject[] cuadrosSeleccion; // Los cuadros de selección
    public GameObject letreroComenzar; // El letrero "Comenzar"
    private bool personajeSeleccionado = false;

    void Start()
    {
        letreroComenzar.SetActive(false); // Ocultar el letrero al inicio
    }

    public void SeleccionarPersonaje()
    {
        Debug.Log("Personaje seleccionado"); // Para verificar en la consola

        if (!personajeSeleccionado)
        {
            personajeSeleccionado = true;

            // Ocultar cuadros de selección
            foreach (GameObject cuadro in cuadrosSeleccion)
            {
                cuadro.SetActive(false);
            }

            // Asegurarnos de que el letrero se active
            if (letreroComenzar != null)
            {
                letreroComenzar.SetActive(true);
                Debug.Log("Letrero 'Comenzar' activado");
            }
            else
            {
                Debug.LogError("No se ha asignado el letrero 'Comenzar' en el Inspector.");
            }
        }
    }

}
