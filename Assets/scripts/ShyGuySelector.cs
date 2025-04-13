
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Agrega esto arriba


public class ShyGuySelector : MonoBehaviour
{
    public TMP_Text[] puntajesTextos; // Enlaza los textos de UIPuntajes
    private int jugadorSeleccionado = 0; // Cambiar si implementas selección de personaje
    private bool sePuedeSeleccionar = true;

    void Update()
    {
        if (sePuedeSeleccionar && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("ShyGuy"))
            {
                GameObject shyGuy = hit.collider.gameObject;
                int donas = shyGuy.transform.childCount;
                Debug.Log($"¡Seleccionaste a {shyGuy.name} con {donas} donas!");

                // Sumar puntos al jugador seleccionado
                ActualizarPuntaje(jugadorSeleccionado, donas);

                sePuedeSeleccionar = false; // Para que no seleccione dos veces
            }
        }
    }

    void ActualizarPuntaje(int jugador, int puntos)
    {
        if (puntajesTextos == null || jugador >= puntajesTextos.Length || puntajesTextos[jugador] == null)
        {
            Debug.LogWarning("Puntaje no asignado correctamente en el inspector.");
            return;
        }

        int puntajeActual = int.Parse(puntajesTextos[jugador].text);
        puntajeActual += puntos;
        puntajesTextos[jugador].text = puntajeActual.ToString();
    }

}
