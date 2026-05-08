using UnityEngine;

public class AutoFearTimer : MonoBehaviour
{
    public float normalFearInterval = 35f;
    public float computerFearInterval = 20f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        float currentInterval = HorrorProgress.playerOnComputer
            ? computerFearInterval
            : normalFearInterval;

        if (timer >= currentInterval)
        {
            timer = 0f;
            HorrorProgress.fearLevel++;

            FearManager fearManager = FindObjectOfType<FearManager>();
            if (fearManager != null)
                fearManager.UpdateEnvironment();

            Debug.Log("Auto fear increased: " + HorrorProgress.fearLevel);
        }
    }
}