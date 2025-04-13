using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonWobble : MonoBehaviour, IPointerClickHandler
{
    public float wobbleAmount = 15f;
    public float wobbleDuration = 0.3f;
    public float flashDuration = 0.5f;

    public Sprite defaultSprite;
    public Sprite selectedSprite;

    private bool isWobbling = false;
    private bool isSelected = false;
    private bool isLocked = false;

    private Quaternion originalRotation;
    private UnityEngine.UI.Image image;
    private Color originalColor;

    // Contador estático para todos los botones
    public static int totalSelected = 0;

    // Referencia al contenedor del botón Start (asignar en el Inspector)
    public GameObject startButtonContainer;

    // Lista de botones de personaje a ocultar cuando se seleccionen 4
    public GameObject[] characterButtons;

    // UI Image que debe aparecer después de la selección
    public GameObject uiImage;

    void Start()
    {
        originalRotation = transform.rotation;
        image = GetComponent<UnityEngine.UI.Image>();

        if (image != null)
        {
            originalColor = image.color;
            if (defaultSprite != null)
                image.sprite = defaultSprite;
        }

        // Asegurarse de que el botón Start esté oculto al inicio
        if (startButtonContainer != null)
        {
            startButtonContainer.SetActive(false);
        }

        // Asegúrese de que la UI imagen esté desactivada al inicio
        if (uiImage != null)
        {
            uiImage.SetActive(false);
        }

        // Mostrar todos los botones al inicio
        foreach (GameObject button in characterButtons)
        {
            button.SetActive(true);
        }

        // Depuración para asegurarnos de que el UI no está activo al principio
        Debug.Log("UI Image Activada al inicio: " + uiImage.activeSelf);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isLocked) return;

        if (!isWobbling)
        {
            StartCoroutine(Wobble());
            StartCoroutine(FlashWhite());
        }

        ToggleSprite();
        isLocked = true;

        totalSelected++;
        Debug.Log("Personajes seleccionados: " + totalSelected);

        // Solo activar Start y UI después de seleccionar los 4 personajes
        if (totalSelected == 4)
        {
            Debug.Log("4 personajes seleccionados. Activando Start y UI Image.");

            // Mostrar el botón Start después de 1 segundo
            Invoke("ActivateStartButton", 1f);

            // Ocultar los botones de personaje
            HideCharacterButtons();

            // Activar la UI Image después de seleccionar los 4 personajes
            ActivateUIImage();
        }
    }

    void ToggleSprite()
    {
        if (image == null || selectedSprite == null || defaultSprite == null) return;

        isSelected = true;
        image.sprite = selectedSprite;
    }

    IEnumerator Wobble()
    {
        isWobbling = true;

        float elapsed = 0f;
        while (elapsed < wobbleDuration)
        {
            float angle = Mathf.Sin(elapsed * 40f) * wobbleAmount;
            transform.rotation = originalRotation * Quaternion.Euler(0, 0, angle);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = originalRotation;
        isWobbling = false;
    }

    IEnumerator FlashWhite()
    {
        if (image == null) yield break;

        image.color = new Color(1f, 1f, 1f, 0.6f);
        yield return new WaitForSeconds(flashDuration);
        image.color = originalColor;
    }

    void ActivateStartButton()
    {
        if (startButtonContainer != null)
        {
            startButtonContainer.SetActive(true);
            Debug.Log("Botón Start Activado.");
        }
    }

    void HideCharacterButtons()
    {
        foreach (GameObject button in characterButtons)
        {
            button.SetActive(false);
        }
    }

    // Activa la UI imagen después de que los 4 personajes hayan sido seleccionados
    void ActivateUIImage()
    {
        if (uiImage != null)
        {
            uiImage.SetActive(true);
            Debug.Log("UI Image Activada.");
        }
    }
}
