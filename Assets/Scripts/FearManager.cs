using UnityEngine;

public class FearManager : MonoBehaviour
{
    [Header("Fear")]
    public int maxFearLevel = 12;

    [Header("Fear Increase")]
    public float normalFearInterval = 35f;
    public float computerFearInterval = 20f;

    private float fearTimer;

    [Header("Fog Settings")]
    public bool enableFog = true;
    public Color fogColor = new Color(0.01f, 0.01f, 0.015f);

    public float minFogDensity = 0.01f;
    public float maxFogDensity = 0.18f;

    [Header("Lighting")]
    public Light directionalLight;

    public float maxLightIntensity = 0.45f;
    public float minLightIntensity = 0f;

    void Start()
    {
        fearTimer = normalFearInterval;

        UpdateEnvironment();
    }

    void Update()
    {
        RunFearTimer();

        UpdateEnvironment();
    }

    void RunFearTimer()
    {
        float currentInterval = normalFearInterval;

        if (HorrorProgress.playerOnComputer)
        {
            currentInterval = computerFearInterval;
        }

        fearTimer -= Time.deltaTime;

        if (fearTimer <= 0f)
        {
            AddFear(1);

            fearTimer = currentInterval;
        }
    }

    public void AddFear(int amount)
    {
        HorrorProgress.fearLevel += amount;

        HorrorProgress.fearLevel =
            Mathf.Clamp(HorrorProgress.fearLevel, 0, maxFearLevel);

        Debug.Log("Fear Increased To: " + HorrorProgress.fearLevel);
    }

    public void UpdateEnvironment()
    {
        float t =
            Mathf.Clamp01(
                (float)HorrorProgress.fearLevel / maxFearLevel
            );

        // FOG
        RenderSettings.fog = enableFog;
        RenderSettings.fogMode = FogMode.Exponential;
        RenderSettings.fogColor = fogColor;

        RenderSettings.fogDensity =
            Mathf.Lerp(minFogDensity, maxFogDensity, t);

        // DARKNESS
        if (directionalLight != null)
        {
            directionalLight.intensity =
                Mathf.Lerp(
                    maxLightIntensity,
                    minLightIntensity,
                    t
                );
        }
    }
}