using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalLocalPosition;

    void Awake()
    {
        originalLocalPosition = transform.localPosition;
    }

    public void ShakeBurst(float strength)
    {
        StopAllCoroutines();
        StartCoroutine(ShakeSequence(strength));
    }

    IEnumerator ShakeSequence(float strength)
    {
        // SHAKE 1
        yield return StartCoroutine(SingleShake(0.12f, strength));

        yield return new WaitForSeconds(0.08f);

        // SHAKE 2
        yield return StartCoroutine(SingleShake(0.1f, strength * 0.8f));

        yield return new WaitForSeconds(0.06f);

        // SHAKE 3
        yield return StartCoroutine(SingleShake(0.08f, strength * 0.6f));

        transform.localPosition = originalLocalPosition;
    }

    IEnumerator SingleShake(float duration, float strength)
    {
        float timer = 0f;

        while (timer < duration)
        {
            float x = Random.Range(-strength, strength);
            float y = Random.Range(-strength, strength);

            transform.localPosition =
                originalLocalPosition + new Vector3(x, y, 0f);

            timer += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalLocalPosition;
    }
}