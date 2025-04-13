/*using UnityEngine;

public class ShyGuyController : MonoBehaviour
{
    private bool yaSeleccionado = false;

    private void OnMouseDown()
    {
        if (!yaSeleccionado && GameManager.instance.puedeSeleccionar)
        {
            int cantidadDonas = ContarDonas();
            GameManager.instance.ShyGuySeleccionado(this, cantidadDonas);
            yaSeleccionado = true;
        }
    }

    int ContarDonas()
    {
        int contador = 0;

        foreach (Transform hijo in transform)
        {
            if (hijo.CompareTag("Dona")) // Asegúrate que las donas tengan esta etiqueta
            {
                contador++;
            }
        }

        return contador;
    }
}
*/
using UnityEngine;

public class ShyGuyController : MonoBehaviour
{
    private bool yaSeleccionado = false;

    // Esta propiedad almacenará la cantidad de donas de este ShyGuy
    public int cantidadDonas { get; private set; }

    private void Start()
    {
        // Asignamos la cantidad de donas automáticamente al inicio del juego
        cantidadDonas = ContarDonas();
    }

    private void OnMouseDown()
    {
        if (!yaSeleccionado && GameManager.instance.puedeSeleccionar)
        {
            GameManager.instance.ShyGuySeleccionado(this); // Aquí se pasa el objeto
            yaSeleccionado = true;
        }
    }

    // Método para contar las donas de este ShyGuy
    int ContarDonas()
    {
        int contador = 0;

        foreach (Transform hijo in transform)
        {
            if (hijo.CompareTag("Dona")) // Asegúrate de que las donas tengan esta etiqueta
            {
                contador++;
            }
        }

        return contador;
    }
}
