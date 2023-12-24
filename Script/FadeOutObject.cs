using System.Collections;
using UnityEngine;

public class FadeOutObject : MonoBehaviour
{
    public CanvasGroup uiElement; // 要渐隐的UI元素的CanvasGroup
    public float 持续时间 = 5f; // 渐隐持续时间
    void Start()
    {
        // 如果uiElement已经指定，则开始渐隐过程
        if (uiElement != null)
        {
            StartCoroutine(FadeOut(uiElement, 持续时间));
        }
    }

    IEnumerator FadeOut(CanvasGroup element, float duration)
    {
        float counter = 0;
        float startAlpha = element.alpha;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            element.alpha = Mathf.Lerp(startAlpha, 0, counter / duration);
            yield return null;
        }

        element.alpha = 0;
        element.gameObject.SetActive(false); // 可选：隐藏UI元素
    }
}
