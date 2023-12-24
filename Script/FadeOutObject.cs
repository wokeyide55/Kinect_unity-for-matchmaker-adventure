using System.Collections;
using UnityEngine;

public class FadeOutObject : MonoBehaviour
{
    public CanvasGroup uiElement; // Ҫ������UIԪ�ص�CanvasGroup
    public float ����ʱ�� = 5f; // ��������ʱ��
    void Start()
    {
        // ���uiElement�Ѿ�ָ������ʼ��������
        if (uiElement != null)
        {
            StartCoroutine(FadeOut(uiElement, ����ʱ��));
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
        element.gameObject.SetActive(false); // ��ѡ������UIԪ��
    }
}
