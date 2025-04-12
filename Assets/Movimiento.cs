using System.Collections;
using UnityEngine;

public class ShyGuyMovement : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 5f;
    public float roundTime = 12f;
    public float minDistanceToCamera = 10f;
    public float cameraEdgeMargin = 0.1f;

    public Camera mainCamera;
    public GameObject uiImage;

    private Vector3 startPosition;
    private bool isWaiting = false;

    // Nuevo: para detectar clics cuando vuelve a su posición
    public bool isClickable = false;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        startPosition = transform.position;

        isWaiting = true;
        StartCoroutine(WaitForUIImageAndStartMovement());
    }

    IEnumerator WaitForUIImageAndStartMovement()
    {
        while (uiImage != null && !uiImage.activeSelf)
        {
            yield return null;
        }

        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine()
    {
        while (true)
        {
            float elapsedTime = 0f;

            while (elapsedTime < roundTime)
            {
                Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
                Vector3 targetPosition = transform.position + randomDirection * moveDistance;

                if (IsInCameraView(targetPosition) && IsFarEnoughFromCamera(targetPosition))
                {
                    while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                        yield return null;
                    }

                    transform.position = targetPosition;
                    elapsedTime += moveDistance / moveSpeed;
                }
                else
                {
                    yield return null;
                }
            }

            // Regresa a su posición inicial
            while (Vector3.Distance(transform.position, startPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            transform.position = startPosition;

            // Ahora se puede hacer clic
            isClickable = true;

            if (!isWaiting)
            {
                isWaiting = true;
                ShyGuyManager.Instance.NotifyShyGuyReady();
            }

            while (isWaiting)
            {
                yield return null;
            }
        }
    }

    public void ResumeMovement()
    {
        isWaiting = false;
        isClickable = false; // Ya no se puede hacer clic mientras se mueve
    }

    bool IsInCameraView(Vector3 worldPosition)
    {
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(worldPosition);

        return viewportPoint.z > 0 &&
               viewportPoint.x >= cameraEdgeMargin && viewportPoint.x <= 1f - cameraEdgeMargin &&
               viewportPoint.y >= cameraEdgeMargin && viewportPoint.y <= 1f - cameraEdgeMargin;
    }

    bool IsFarEnoughFromCamera(Vector3 worldPosition)
    {
        Vector3 toCamera = mainCamera.transform.position - worldPosition;
        toCamera.y = 0f;
        return toCamera.magnitude > minDistanceToCamera;
    }

    // Nuevo: Detectar clic en el personaje
    void OnMouseDown()
    {
        if (isClickable)
        {
            Debug.Log(gameObject.name + " fue clickeado!");
            // Aquí puedes poner más lógica si quieres que haga algo
        }
    }
}
