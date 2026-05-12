using UnityEngine;

public class FearManager : MonoBehaviour
{
    public Light mainLight;

    public float normalLight = 1.2f;
    public float darkestLight = 0.25f;

    void Start()
    {
        UpdateEnvironment();
    }

    public void UpdateEnvironment()
    {
        int fearLevel = HorrorProgress.fearLevel;

        if (mainLight != null)
        {
            if (fearLevel < 2)
                mainLight.intensity = 1.2f;   // normal
            else if (fearLevel < 4)
                mainLight.intensity = 0.45f;  // suddenly darker
            else if (fearLevel < 6)
                mainLight.intensity = 0.15f;  // very dark
            else
                mainLight.intensity = 0.03f;  // almost black
        }

        RenderSettings.fog = true;
        RenderSettings.fogDensity = 0.01f + fearLevel * 0.012f;

        RenderSettings.ambientLight = Color.Lerp(
            Color.white,
            new Color(0.05f, 0.05f, 0.08f),
            Mathf.Clamp01(fearLevel / 6f)
        );

        HorrorSoundManager soundManager = FindObjectOfType<HorrorSoundManager>();

        if (soundManager != null)
        {
            soundManager.TryPlayScarySound();
        }

        WatcherNPCManager watcherManager = FindObjectOfType<WatcherNPCManager>();

        if (watcherManager != null)
        {
            watcherManager.TrySpawnWatcher();
        }

    }

    public static bool CanStartDanger()
    {
        return HorrorProgress.fearLevel >= 2;
    }
}