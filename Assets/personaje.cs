using UnityEngine;
using TMPro;

public class Personaje : MonoBehaviour
{
    public GameObject[] cuadrosSeleccion;
    public GameObject letreroComenzar;
    public TextMeshProUGUI textoPuntaje;
    private bool personajeSeleccionado = false;
    private int puntaje = 0;

    void Start()
    {
        letreroComenzar.SetActive(false);
        if (textoPuntaje != null)
        {
            textoPuntaje.text = "Puntuación: 0";
        }
    }

    public void SeleccionarPersonaje()
    {
        Debug.Log("Personaje seleccionado");

        if (!personajeSeleccionado)
        {
            personajeSeleccionado = true;

            foreach (GameObject cuadro in cuadrosSeleccion)
            {
                cuadro.SetActive(false);
            }

            if (letreroComenzar != null)
            {
                letreroComenzar.SetActive(true);
                Debug.Log("Letrero 'Comenzar' activado");
            }

            puntaje += 10;
            if (textoPuntaje != null)
            {
                textoPuntaje.text = "Puntuación: " + puntaje.ToString();
            }
        }
    }
     public void SumarPuntos(int cantidad)
    {
     puntaje += cantidad;
     textoPuntaje.text = "Puntuación: " + puntaje.ToString();
    }
    void OnMouseDown()
    {
    SeleccionarPersonaje();
    }
}