using UnityEngine;

public class OfficeDistortionManager : MonoBehaviour
{
    public GameObject normalOffice;
    public GameObject crowdedOverlay;
    public GameObject nightmareOverlay;

    public AudioSource distortionAudio;

    public int crowdedSuspicionLevel = 10;
    public int nightmareFearLevel = 12;

    private bool crowdedTriggered = false;
    private bool nightmareTriggered = false;
    public CameraShake cameraShake;
    public float shakeDuration = 0.6f;
    public float shakeStrength = 0.08f;

    private bool crowdedEventPlayed = false;
    private bool nightmareEventPlayed = false;


    void Start()
    {
        UpdateOfficeStage();
    }

    public void UpdateOfficeStage()
    {
        if (normalOffice != null)
            normalOffice.SetActive(true);

        if (crowdedOverlay != null)
            crowdedOverlay.SetActive(false);

        if (nightmareOverlay != null)
            nightmareOverlay.SetActive(false);

        if (HorrorProgress.suspicionLevel >= crowdedSuspicionLevel)
        {
            if (crowdedOverlay != null)
                crowdedOverlay.SetActive(true);

            if (!crowdedEventPlayed)
            {
                crowdedEventPlayed = true;

                PlayDistortionSound();

                if (cameraShake != null)
                    cameraShake.ShakeBurst(shakeStrength);
            }
        }

        if (HorrorProgress.finalBossMode ||
            HorrorProgress.fearLevel >= nightmareFearLevel)
        {
            if (crowdedOverlay != null)
                crowdedOverlay.SetActive(true);

            if (nightmareOverlay != null)
                nightmareOverlay.SetActive(true);

            if (!nightmareEventPlayed)
            {
                nightmareEventPlayed = true;

                PlayDistortionSound();

                if (cameraShake != null)
                    cameraShake.ShakeBurst(shakeStrength * 1.5f);
            }
        }
    }

    void PlayDistortionSound()
    {
        if (distortionAudio != null)
            distortionAudio.time = 3f;
            distortionAudio.Play();

            Invoke(nameof(StopDistortionSound), 5f);

        if (cameraShake != null)
            cameraShake.ShakeBurst(shakeStrength);
    }
    void StopDistortionSound()
    {
        if (distortionAudio != null)
            distortionAudio.Stop();
    }
}