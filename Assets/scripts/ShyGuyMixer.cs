/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShyGuyMixer : MonoBehaviour
{
    public GameObject[] shyGuys;
    public float mixDuration = 3f;
    public float moveSpeed = 5f;
    public int numIntercambios = 10;

    private Vector3[] posicionesOriginales;

    void Start()
    {
        posicionesOriginales = new Vector3[shyGuys.Length];
        for (int i = 0; i < shyGuys.Length; i++)
        {
            posicionesOriginales[i] = shyGuys[i].transform.position;
        }
    }

    public void EmpezarMezcla()
    {
        StartCoroutine(MezclarShyGuys());
    }

    IEnumerator MezclarShyGuys()
    {
        float tiempoTotal = 0f;
        int intercambiosRealizados = 0;

        while (intercambiosRealizados < numIntercambios)
        {
            int a = Random.Range(0, shyGuys.Length);
            int b;
            do
            {
                b = Random.Range(0, shyGuys.Length);
            } while (b == a);

            Vector3 posA = shyGuys[a].transform.position;
            Vector3 posB = shyGuys[b].transform.position;

            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime * moveSpeed;
                shyGuys[a].transform.position = Vector3.Lerp(posA, posB, t);
                shyGuys[b].transform.position = Vector3.Lerp(posB, posA, t);
                yield return null;
            }

            // Intercambio real en el array
            GameObject temp = shyGuys[a];
            shyGuys[a] = shyGuys[b];
            shyGuys[b] = temp;

            intercambiosRealizados++;
            yield return new WaitForSeconds(0.1f); // Pequeña pausa entre intercambios
        }

        Debug.Log("¡Shy Guys mezclados visiblemente!");
    }
}*/
using System.Collections;
using UnityEngine;

public class ShyGuyMixer : MonoBehaviour
{
    public GameObject[] shyGuys;
    public float mixDuration = 3f;
    public float moveSpeed = 5f;
    public int numIntercambios = 10;

    private Vector3[] posicionesOriginales;

    void Start()
    {
        posicionesOriginales = new Vector3[shyGuys.Length];
        for (int i = 0; i < shyGuys.Length; i++)
        {
            posicionesOriginales[i] = shyGuys[i].transform.position;
        }
    }

    public void EmpezarMezcla()
    {
        StartCoroutine(MezclarShyGuys());
    }

    IEnumerator MezclarShyGuys()
    {
        float tiempoTotal = 0f;
        int intercambiosRealizados = 0;

        while (intercambiosRealizados < numIntercambios)
        {
            int a = Random.Range(0, shyGuys.Length);
            int b;
            do
            {
                b = Random.Range(0, shyGuys.Length);
            } while (b == a);

            Vector3 posA = shyGuys[a].transform.position;
            Vector3 posB = shyGuys[b].transform.position;

            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime * moveSpeed;
                shyGuys[a].transform.position = Vector3.Lerp(posA, posB, t);
                shyGuys[b].transform.position = Vector3.Lerp(posB, posA, t);
                yield return null;
            }

            // Intercambio real en el array
            GameObject temp = shyGuys[a];
            shyGuys[a] = shyGuys[b];
            shyGuys[b] = temp;

            intercambiosRealizados++;
            yield return new WaitForSeconds(0.1f); // Pequeña pausa entre intercambios
        }

        Debug.Log("¡Shy Guys mezclados visiblemente!");
    }
}

