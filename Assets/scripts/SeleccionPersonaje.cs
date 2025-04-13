using UnityEngine;

public class SeleccionPersonaje : MonoBehaviour
{
    public GameObject[] cuadrosSeleccion;     // Cuadros de selección (los personajes)
    public GameObject letreroComenzar;        // Letrero que aparece cuando seleccionan
    public AudioClip sonidoSeleccion;         // Sonido que se reproduce al seleccionar

    private AudioSource audioSource;          // Reproductor de sonido
    private bool personajeSeleccionado = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        letreroComenzar.SetActive(false); // Ocultar el letrero al inicio
    }

    public void SeleccionarPersonaje()
    {
        Debug.Log("Personaje seleccionado");

        if (!personajeSeleccionado)
        {
            personajeSeleccionado = true;

            // Ocultar los demás cuadros
            foreach (GameObject cuadro in cuadrosSeleccion)
            {
                cuadro.SetActive(false);
            }

            // Mostrar el letrero de comenzar
            if (letreroComenzar != null)
            {
                letreroComenzar.SetActive(true);
            }

            // Reproducir el sonido si está asignado
            if (sonidoSeleccion != null)
            {
                audioSource.PlayOneShot(sonidoSeleccion);
            }
            else
            {
                Debug.LogWarning("No hay sonido asignado para la selección.");
            }
        }
    }
}
