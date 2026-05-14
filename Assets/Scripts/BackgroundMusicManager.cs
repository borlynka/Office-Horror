using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public static BackgroundMusicManager Instance;


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
    public AudioSource officeAmbience;
    public AudioSource tensionDrone;
    public AudioSource nightmareLayer;

    public float fadeSpeed = 0.5f;

    void Update()
    {
        int fear = HorrorProgress.fearLevel;

        // OFFICE AMBIENCE
        float officeTarget =
            fear < 8 ? 0.4f : 0.1f;

        // TENSION DRONE
        float tensionTarget =
            fear >= 4 ? 0.35f : 0f;

        // NIGHTMARE LAYER
        float nightmareTarget =
            fear >= 8 ? 0.5f : 0f;

        officeAmbience.volume =
            Mathf.Lerp(
                officeAmbience.volume,
                officeTarget,
                Time.deltaTime * fadeSpeed
            );

        tensionDrone.volume =
            Mathf.Lerp(
                tensionDrone.volume,
                tensionTarget,
                Time.deltaTime * fadeSpeed
            );

        nightmareLayer.volume =
            Mathf.Lerp(
                nightmareLayer.volume,
                nightmareTarget,
                Time.deltaTime * fadeSpeed
            );
    }
}