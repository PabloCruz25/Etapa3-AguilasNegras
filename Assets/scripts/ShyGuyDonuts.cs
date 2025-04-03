using UnityEngine;

public class ShyGuyDonuts : MonoBehaviour
{
    public GameObject[] donutsVisuales; // Referencia a los objetos de donas
    private static int[] donutsDistribucion = { 1, 2, 3, 4, 5 }; // Cantidad de donuts por Shy Guy
    private static int indexDistribucion = 0; // Para asignar sin repetir

    void Start()
    {
        // Asegurar que no nos pasemos del arreglo
        if (indexDistribucion >= donutsDistribucion.Length)
        {
            Debug.LogError("Se intentó asignar más Shy Guys de los permitidos.");
            return;
        }

        int cantidadDonuts = donutsDistribucion[indexDistribucion]; // Asignar cantidad
        indexDistribucion++; // Mover al siguiente valor para otro Shy Guy

        // Mostrar solo la cantidad correcta de donuts
        MostrarDonuts(cantidadDonuts);
    }

    void MostrarDonuts(int cantidad)
    {
        // Asegurar que hay donuts asignadas
        if (donutsVisuales.Length == 0)
        {
            Debug.LogError(gameObject.name + " no tiene donuts asignadas en el array.");
            return;
        }

        // Ocultar todas las donas primero
        foreach (GameObject donut in donutsVisuales)
        {
            donut.SetActive(false);
        }

        // Activar solo la cantidad correcta de donuts
        for (int i = 0; i < cantidad; i++)
        {
            donutsVisuales[i].SetActive(true);
        }
    }
}
