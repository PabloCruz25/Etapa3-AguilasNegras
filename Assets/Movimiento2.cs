using UnityEngine;
using System.Collections.Generic;

public class ShyGuyManager : MonoBehaviour
{
    public static ShyGuyManager Instance;

    public List<ShyGuyMovement> shyGuys = new List<ShyGuyMovement>();
    private int readyCount = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void NotifyShyGuyReady()
    {
        readyCount++;

        if (readyCount >= shyGuys.Count)
        {
            foreach (var shyGuy in shyGuys)
            {
                shyGuy.ResumeMovement();
            }

            readyCount = 0;
        }
    }
}
