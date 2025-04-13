using UnityEngine;
using System.Collections.Generic;

public class ShyGuyManager : MonoBehaviour
{
    public GameObject[] shyGuys; // Los 5 Shy Guys en la escena
    public GameObject donutPrefab; // Prefab de una dona
    public Sprite[] donutSprites; // Sprites disponibles de donas

    private void Start()
    {
        List<int> donutCounts = new List<int> { 1, 2, 3, 4, 5 };
        ShuffleList(donutCounts);

        for (int i = 0; i < shyGuys.Length; i++)
        {
            int count = donutCounts[i];
            GiveDonutsToShyGuy(shyGuys[i].transform, count);
        }
    }

    void GiveDonutsToShyGuy(Transform shyGuy, int count)
    {
        float yOffset = 6.9f;

        for (int i = 0; i < count; i++)
        {
            GameObject donut = Instantiate(donutPrefab, shyGuy);
            donut.transform.localPosition = new Vector3(0, yOffset + (i * 2.6f), 0);

            SpriteRenderer sr = donut.GetComponent<SpriteRenderer>();
            sr.sprite = donutSprites[Random.Range(0, donutSprites.Length)];
            sr.sortingOrder = 1 + i;
        }
    }

    void ShuffleList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(i, list.Count);
            (list[i], list[rnd]) = (list[rnd], list[i]);
        }
    }
    public void OcultarTodasLasDonas()
    {
        foreach (GameObject shyGuy in shyGuys)
        {
            foreach (Transform child in shyGuy.transform)
            {
                if (child.CompareTag("Dona"))
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }

}
