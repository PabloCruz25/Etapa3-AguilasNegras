using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject uiSeleccion;

    void Start()
    {
        StartCoroutine(MostrarUIConRetraso());
    }

    IEnumerator MostrarUIConRetraso()
    {
        yield return new WaitForSeconds(4f);
        uiSeleccion.SetActive(true);
    }

}
