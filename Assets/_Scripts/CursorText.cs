using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(RectTransform))]
public class CursorText : MonoBehaviour
{
    public static CursorText instance;
    TMP_Text textBox;
    CanvasGroup canvasGroup;
    RectTransform rectTransform;
    [SerializeField] Vector2 CursorOffset;
    [SerializeField]
    float textAlpha, fadeInTime, fadeOutTime;
    [SerializeField] InputActionReference mousePos;
    Coroutine currentFadeRoutine;
    void Awake()
    {
        
        if(instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        
        instance = this;
        
        textBox = GetComponent<TMP_Text>();

        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        transform.SetParent(FindFirstObjectByType<Canvas>().transform);
        transform.SetAsLastSibling();

        rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        Vector2 scaleValue = new Vector2(Screen.width/1920f, Screen.height / 1080f);
        Vector2 scaledOffset = new Vector2(scaleValue.x * CursorOffset.x, scaleValue.y * CursorOffset.y);
        transform.position = mousePos.action.ReadValue<Vector2>() + scaledOffset;
    }
    public void SetText(String text)
    {
        textBox.text = text;
        if(currentFadeRoutine != null) StopCoroutine(currentFadeRoutine);
        currentFadeRoutine = StartCoroutine(FadeInText());
    }

    public void FadeOut()
    {
        if(currentFadeRoutine != null) StopCoroutine(currentFadeRoutine);
        gameObject.SetActive(true);
        currentFadeRoutine = StartCoroutine(FadeOutText());
    }

    IEnumerator FadeInText()
    {

        canvasGroup.alpha = textAlpha;
        while(textAlpha < 1f)
        {
            yield return null;
            textAlpha += (1f/fadeInTime) * Time.deltaTime;
            canvasGroup.alpha = textAlpha;
        }
    }

    IEnumerator FadeOutText()
    {
        while(textAlpha > 0f)
        {
            yield return null;
            textAlpha -= (1f/fadeOutTime) * Time.deltaTime;
            canvasGroup.alpha = textAlpha;
        }
    }

    
}
