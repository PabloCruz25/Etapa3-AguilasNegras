using UnityEngine;

public class SeleccionJugador : MonoBehaviour
{
    public GameObject startImage;
    public GameObject ronda1Image;
    public GameObject uiSeleccion;
    public GameObject uiPuntajes; // ← Nuevo: Grupo con los 4 cuadros

    private bool juegoIniciado = false;

    public void SeleccionarPersonaje()
    {
        if (juegoIniciado) return;

        juegoIniciado = true;

        uiSeleccion.SetActive(false);
        startImage.SetActive(true);

        Invoke("MostrarRonda1", 2f);
    }

    void MostrarRonda1()
    {
        startImage.SetActive(false);
        ronda1Image.SetActive(true);

        // MOSTRAR los cuadros de puntaje aquí
        uiPuntajes.SetActive(true);

        Invoke("IniciarJuego", 2f);
    }

    void IniciarJuego()
    {
        ronda1Image.SetActive(false);
        Debug.Log("¡Empieza la ronda 1!");

        // Ocultar donas desde ShyGuyManager
        FindObjectOfType<ShyGuyManager>().OcultarTodasLasDonas();
        FindObjectOfType<ShyGuyMixer>().EmpezarMezcla();

    }
}
