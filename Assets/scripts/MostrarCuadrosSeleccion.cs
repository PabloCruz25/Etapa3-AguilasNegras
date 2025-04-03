using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MostrarCuadrosSeleccion : MonoBehaviour
{
    public GameObject panelSeleccion; // El contenedor de los cuadros de selección
    private bool seleccionRealizada = false; // Para evitar múltiples selecciones

    void Start()
    {
        // Ocultar los cuadros de selección al inicio
        panelSeleccion.SetActive(false);

        // Llamar a la corrutina para mostrar los cuadros después de 3 segundos
        StartCoroutine(MostrarDespuesDeTiempo(3f));
    }

    IEnumerator MostrarDespuesDeTiempo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo); // Espera el tiempo especificado
        panelSeleccion.SetActive(true); // Muestra el panel después del tiempo
    }

    void Update()
    {
        // Si el jugador presiona "A" y aún no ha seleccionado
        if (Input.GetKeyDown(KeyCode.A) && !seleccionRealizada)
        {
            seleccionRealizada = true; // Marcar que ya se hizo la selección
            panelSeleccion.SetActive(false); // Ocultar los cuadros de selección
            Debug.Log("Jugador seleccionado, ocultando cuadros...");
        }
    }
}
