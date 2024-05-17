using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] private Image imageToFade;
    [SerializeField] private float waitDuration = 2f;
    [SerializeField] private float fadeDuration = 1f;

    // Optimize süreler: Wait 2 sn, Fade 1 sn. -Samet

    void Start()
    {
        StartCoroutine(StartFade(imageToFade, fadeDuration, waitDuration));
    }

    IEnumerator StartFade(Image image, float duration, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(FadeOut(image, duration));
    }

    IEnumerator FadeOut(Image image, float duration)
    {
        Color color = image.color;
        float startAlpha = color.a;

        float rate = 1.0f / duration;

        for (float i = 0; i < 1.0f; i += Time.deltaTime * rate)
        {
            color.a = Mathf.Lerp(startAlpha, 0, i);
            image.color = color;
            yield return null;
        }

        color.a = 0;
        image.color = color;

        image.gameObject.SetActive(false);
    }
}