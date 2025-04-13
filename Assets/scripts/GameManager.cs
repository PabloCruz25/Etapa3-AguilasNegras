/*using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text[] puntajesTextos;
    private int[] puntajes = new int[4]; // 4 jugadores
    public int jugadorActual = 0;
    public bool puedeSeleccionar = true;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void ShyGuySeleccionado(ShyGuyController shyGuy, int donas)
    {
        puntajes[jugadorActual] += donas;

        if (puntajesTextos[jugadorActual] != null)
        {
            puntajesTextos[jugadorActual].text = puntajes[jugadorActual].ToString();
        }

        puedeSeleccionar = false;
        Debug.Log($"Jugador {jugadorActual + 1} seleccionó a {shyGuy.name} con {donas} donas");

        // Aquí puedes invocar la siguiente fase o ronda si lo deseas
    }
    public void HabilitarSeleccion()
    {
        puedeSeleccionar = true;
    }

}*/

using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text[] puntajesTextos;
    private int[] puntajes = new int[4]; // 4 jugadores
    public int jugadorActual = 0;
    public bool puedeSeleccionar = true;

    public RoundManager roundManager; // Referencia al RoundManager para gestionar las rondas

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void ShyGuySeleccionado(ShyGuyController shyGuy)
    {
        int donas = shyGuy.cantidadDonas;
        puntajes[jugadorActual] += donas;

        if (puntajesTextos[jugadorActual] != null)
        {
            puntajesTextos[jugadorActual].text = puntajes[jugadorActual].ToString();
        }

        puedeSeleccionar = false;
        Debug.Log($"Jugador {jugadorActual + 1} seleccionó a {shyGuy.name} con {donas} donas");

        // Pasamos al siguiente jugador, o iniciamos la siguiente ronda
        jugadorActual++;

        // Si todos los jugadores han jugado, inicia la siguiente ronda
        if (jugadorActual >= puntajes.Length)
        {
            jugadorActual = 0; // Reseteamos al primer jugador

            // Llamamos al método para iniciar la siguiente ronda
            roundManager.IniciarRonda();  // Asegúrate de que esta llamada esté aquí
        }
    }

    // Método para habilitar la selección para el siguiente jugador
    public void HabilitarSeleccion()
    {
        puedeSeleccionar = true;
    }
}

