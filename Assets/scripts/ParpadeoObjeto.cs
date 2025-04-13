using UnityEngine;

public class ParpadeoObjeto : MonoBehaviour
{
    public float velocidadParpadeo = 0.5f; // Tiempo entre parpadeos
    private Renderer renderizador;
    private float tiempoSiguienteCambio = 0f;

    void Start()
    {
        renderizador = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Time.time >= tiempoSiguienteCambio)
        {
            renderizador.enabled = !renderizador.enabled; // Alterna visibilidad
            tiempoSiguienteCambio = Time.time + velocidadParpadeo;
        }
    }
}
