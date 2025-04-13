/*using System.Collections;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public GameObject[] rondasUI; // Los letreros de ronda (por ejemplo, Ronda 1, Ronda 2, etc.)
    public GameManager gameManager; // Referencia al GameManager para gestionar las rondas

    public ShyGuyMixer shyGuyMixer; // Referencia al ShyGuyMixer para mezclar los ShyGuys
                                    // Referencia al ShyGuyManager para mezclar los ShyGuys

    private int rondaActual = 0; // Contador para las rondas

    private void Start()
    {
        // Iniciar la primera ronda automáticamente
        IniciarRonda();
    }

    public void IniciarRonda()
    {
        if (rondaActual >= rondasUI.Length)
        {
            Debug.Log("Fin del juego");
            return; // Si ya hemos llegado al final de las rondas, finalizar
        }

        // Mostrar el letrero de la ronda actual
        StartCoroutine(MostrarRondaYPreparar());
    }

    private IEnumerator MostrarRondaYPreparar()
    {
        // Mostrar el letrero de la ronda
        rondasUI[rondaActual].SetActive(true);

        // Esperar 2 segundos antes de ocultarlo
        yield return new WaitForSeconds(2f);

        // Ocultar el letrero de la ronda
        rondasUI[rondaActual].SetActive(false);

        // Mezclar los ShyGuys para la siguiente ronda usando ShyGuyMixer
        shyGuyMixer.EmpezarMezcla(); // Cambiado a EmpezarMezcla(), ya que llamas al método en ShyGuyMixer

        // Habilitar la selección para el jugador en la siguiente ronda
        gameManager.HabilitarSeleccion();

        // Aumentar el contador de rondas
        rondaActual++;
    }

}*/


using System.Collections;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public GameObject[] rondasUI; // Los letreros de ronda (por ejemplo, Ronda 1, Ronda 2, etc.)
    public GameManager gameManager; // Referencia al GameManager para gestionar las rondas

    public ShyGuyMixer shyGuyMixer; // Referencia al ShyGuyMixer para mezclar los ShyGuys

    private int rondaActual = 0; // Contador para las rondas

    private void Start()
    {
        // Iniciar la primera ronda automáticamente
        IniciarRonda();
    }

    public void IniciarRonda()
    {
        if (rondaActual >= rondasUI.Length)
        {
            Debug.Log("Fin del juego");
            return; // Si ya hemos llegado al final de las rondas, finalizar
        }

        // Mostrar el letrero de la ronda actual
        StartCoroutine(MostrarRondaYPreparar());
    }

    private IEnumerator MostrarRondaYPreparar()
    {
        // Mostrar el letrero de la ronda
        rondasUI[rondaActual].SetActive(true);

        // Esperar 2 segundos antes de ocultarlo
        yield return new WaitForSeconds(2f);

        // Ocultar el letrero de la ronda
        rondasUI[rondaActual].SetActive(false);

        // Mezclar los ShyGuys para la siguiente ronda
        shyGuyMixer.EmpezarMezcla(); // Mezclar ShyGuys

        // Habilitar la selección para el jugador en la siguiente ronda
        gameManager.HabilitarSeleccion(); // Activar la selección de nuevo

        // Aumentar el contador de rondas
        rondaActual++;
    }
}
