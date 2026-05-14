using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public static BackgroundMusicManager Instance;

    public AudioSource officeAmbience;
    public AudioSource tensionDrone;
    public AudioSource nightmareLayer;

    public float fadeSpeed = 3f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        StartSource(officeAmbience, 0.35f);
        StartSource(tensionDrone, 0f);
        StartSource(nightmareLayer, 0f);
    }

    void Update()
    {
        int fear = HorrorProgress.fearLevel;

        float officeTarget = 0.35f;
        float tensionTarget = 0f;
        float nightmareTarget = 0f;

        if (fear >= 2)
            tensionTarget = 0.25f;

        if (fear >= 5)
        {
            tensionTarget = 0.45f;
            officeTarget = 0.2f;
        }

        if (fear >= 8)
        {
            nightmareTarget = 0.45f;
            tensionTarget = 0.08f;
            officeTarget = 0.03f;
        }

        if (HorrorProgress.finalBossMode)
        {
            nightmareTarget = 0.75f;
            tensionTarget = 0.03f;
            officeTarget = 0f;
        }

        FadeTo(officeAmbience, officeTarget);
        FadeTo(tensionDrone, tensionTarget);
        FadeTo(nightmareLayer, nightmareTarget);
    }

    void StartSource(AudioSource source, float startVolume)
    {
        if (source == null)
            return;

        source.loop = true;
        source.playOnAwake = false;
        source.spatialBlend = 0f;
        source.volume = startVolume;

        if (!source.isPlaying)
            source.Play();
    }

    void FadeTo(AudioSource source, float targetVolume)
    {
        if (source == null)
            return;

        source.volume = Mathf.Lerp(
            source.volume,
            targetVolume,
            Time.deltaTime * fadeSpeed
        );
    }
}