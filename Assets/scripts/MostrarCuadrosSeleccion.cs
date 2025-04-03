using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MostrarCuadrosSeleccion : MonoBehaviour
{
    public GameObject panelSeleccion; // El contenedor de los cuadros de selecci�n
    private bool seleccionRealizada = false; // Para evitar m�ltiples selecciones

    void Start()
    {
        // Ocultar los cuadros de selecci�n al inicio
        panelSeleccion.SetActive(false);

        // Llamar a la corrutina para mostrar los cuadros despu�s de 3 segundos
        StartCoroutine(MostrarDespuesDeTiempo(3f));
    }

    IEnumerator MostrarDespuesDeTiempo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo); // Espera el tiempo especificado
        panelSeleccion.SetActive(true); // Muestra el panel despu�s del tiempo
    }

    void Update()
    {
        // Si el jugador presiona "A" y a�n no ha seleccionado
        if (Input.GetKeyDown(KeyCode.A) && !seleccionRealizada)
        {
            seleccionRealizada = true; // Marcar que ya se hizo la selecci�n
            panelSeleccion.SetActive(false); // Ocultar los cuadros de selecci�n
            Debug.Log("Jugador seleccionado, ocultando cuadros...");
        }
    }
}
