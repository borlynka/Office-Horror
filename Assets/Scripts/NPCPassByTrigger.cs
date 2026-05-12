using UnityEngine;
using TMPro;

public class NPCPassByTrigger : MonoBehaviour
{
    public TextMeshProUGUI warningText;
    public AudioSource warningAudio;

    public int suspicionIncrease = 2;
    public int maxSuspicion = 10;

    public AudioClip highSuspicionSound;
    public int highSuspicionLevel = 6;
    public int distortionSuspicionLevel = 10;
    void Start()
    {
        if (warningText != null)
            warningText.gameObject.SetActive(false);

        if (warningAudio != null)
        {
            warningAudio.playOnAwake = false;
            warningAudio.loop = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (HorrorProgress.passByWarningUsedThisExit)
            return;

        if (!other.CompareTag("WalkingNPC"))
            return;

        TriggerPassByEvent();
    }

    void TriggerPassByEvent()
    {
        HorrorProgress.passByWarningUsedThisExit = true;

        HorrorProgress.suspicionLevel += suspicionIncrease;
        HorrorProgress.suspicionLevel = Mathf.Clamp(HorrorProgress.suspicionLevel, 0, maxSuspicion);

        if (warningText != null)
        {
            warningText.gameObject.SetActive(true);
            warningText.text = "DON'T LOOK SUSPICIOUS";
        }

        if (warningAudio != null)
        {
            warningAudio.volume = 1f;
            warningAudio.pitch = 1.2f;
            warningAudio.Play();
        }

        CheckSuspicionDanger();

        Invoke(nameof(HideWarning), 3f);
    }

    void CheckSuspicionDanger()
    {
        if (HorrorProgress.suspicionLevel >= highSuspicionLevel)
        {
            if (warningText != null)
            {
                warningText.gameObject.SetActive(true);
                warningText.text = "THEY NOTICED YOU.";
            }

            if (warningAudio != null && highSuspicionSound != null)
            {
                warningAudio.Stop();
                warningAudio.clip = highSuspicionSound;
                warningAudio.volume = .25f;
                warningAudio.pitch = 1f;
                warningAudio.Play();
            }
        }

        if (HorrorProgress.suspicionLevel > distortionSuspicionLevel)
        {


            OfficeDistortionManager distortionManager =
                FindObjectOfType<OfficeDistortionManager>();

            if (distortionManager != null)
            {
                distortionManager.UpdateOfficeStage();
            }
        }
    }

    void HideWarning()
    {
        if (warningText != null)
            warningText.gameObject.SetActive(false);
    }
}