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
            if (hijo.CompareTag("Dona")) // Aseg�rate que las donas tengan esta etiqueta
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

    // Esta propiedad almacenar� la cantidad de donas de este ShyGuy
    public int cantidadDonas { get; private set; }

    private void Start()
    {
        // Asignamos la cantidad de donas autom�ticamente al inicio del juego
        cantidadDonas = ContarDonas();
    }

    private void OnMouseDown()
    {
        if (!yaSeleccionado && GameManager.instance.puedeSeleccionar)
        {
            GameManager.instance.ShyGuySeleccionado(this); // Aqu� se pasa el objeto
            yaSeleccionado = true;
        }
    }

    // M�todo para contar las donas de este ShyGuy
    int ContarDonas()
    {
        int contador = 0;

        foreach (Transform hijo in transform)
        {
            if (hijo.CompareTag("Dona")) // Aseg�rate de que las donas tengan esta etiqueta
            {
                contador++;
            }
        }

        return contador;
    }
}
