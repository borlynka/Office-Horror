using UnityEngine;

public class ShowControlTipsOnce : MonoBehaviour
{
    public float showSeconds = 6f;

    void Start()
    {
        if (HorrorProgress.hasShownControlTips)
        {
            gameObject.SetActive(false);
            return;
        }

        HorrorProgress.hasShownControlTips = true;
        Invoke(nameof(Hide), showSeconds);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}