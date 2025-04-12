using UnityEngine;

public class PunteroController : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        transform.position = mousePos;
    }
}