using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

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

        transform.SetParent(FindFirstObjectByType<Canvas>().transform);
        transform.SetAsLastSibling();

        rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        transform.position = (mousePos.action.ReadValue<Vector2>() + CursorOffset);
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
