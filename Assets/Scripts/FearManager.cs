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
                mainLight.intensity = 0.30f;  // suddenly darker
            else if (fearLevel < 6)
                mainLight.intensity = 0.05f;  // very dark
            else
                mainLight.intensity = 0.005f;  // almost black
        }

        RenderSettings.fog = true;

        RenderSettings.fogColor = new Color(0.02f, 0.02f, 0.025f);

        float t = Mathf.Clamp01(fearLevel / 12f);

        // stronger fog as fear rises

        RenderSettings.fogDensity = Mathf.Lerp(0.01f, 0.09f, t);

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

        OfficeDistortionManager distortionManager =
            FindObjectOfType<OfficeDistortionManager>();

        if (distortionManager != null)
        {
            distortionManager.UpdateOfficeStage();
        }

    }

    public static bool CanStartDanger()
    {
        return HorrorProgress.fearLevel >= 2;
    }
}