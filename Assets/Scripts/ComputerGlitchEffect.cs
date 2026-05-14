using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ComputerGlitchEffect : MonoBehaviour
{
    public RectTransform computerUIRoot;
    public Image glitchFlash;

    public float shakeStrength = 12f;
    public float duration = 0.6f;

    private Vector3 originalPosition;

    void Start()
    {
        if (computerUIRoot != null)
            originalPosition = computerUIRoot.localPosition;

        if (glitchFlash != null)
            glitchFlash.gameObject.SetActive(false);
    }

    public void PlayGlitch()
    {
        StopAllCoroutines();
        StartCoroutine(GlitchRoutine());
    }

    IEnumerator GlitchRoutine()
    {
        float timer = 0f;

        if (glitchFlash != null)
        {
            glitchFlash.gameObject.SetActive(true);
            Color c = glitchFlash.color;
            c.a = 0.35f;
            glitchFlash.color = c;
        }

        while (timer < duration)
        {
            if (computerUIRoot != null)
            {
                float x = Random.Range(-shakeStrength, shakeStrength);
                float y = Random.Range(-shakeStrength, shakeStrength);
                computerUIRoot.localPosition = originalPosition + new Vector3(x, y, 0);
            }

            timer += Time.deltaTime;
            yield return null;
        }

        if (computerUIRoot != null)
            computerUIRoot.localPosition = originalPosition;

        if (glitchFlash != null)
            glitchFlash.gameObject.SetActive(false);
    }
}