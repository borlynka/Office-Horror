using UnityEngine;
using TMPro;

public class ComputerWarningManager : MonoBehaviour
{
    public TextMeshProUGUI warningText;

    [Header("Random Warning Sounds")]
    public AudioSource warningAudioSource;
    public AudioClip[] warningSounds;

    public float minTime = 12f;
    public float maxTime = 22f;
    public float warningDuration = 8f;

    public int ignoredWarnings = 0;

    public string[] warningMessages =
    {
        "Something moved outside.",
        "You heard something.",
        "The office feels wrong.",
        "Check your surroundings."
    };

    private float timer;
    private bool warningActive = false;
    private AudioClip lastPlayedClip;

    void Start()
    {
        if (warningText != null)
            warningText.gameObject.SetActive(false);

        SetNextWarningTime();
    }

    void Update()
    {
        if (warningActive)
            return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
            TriggerWarning();
    }

    void TriggerWarning()
    {
        warningActive = true;

        if (warningText != null)
        {
            warningText.gameObject.SetActive(true);
            warningText.text =
                warningMessages[Random.Range(0, warningMessages.Length)] +
                "\nPress SPACE to check.";
        }

        PlayRandomWarningSound();

        Invoke(nameof(WarningIgnored), warningDuration);
    }

    void PlayRandomWarningSound()
    {
        if (warningAudioSource == null || warningSounds == null || warningSounds.Length == 0)
            return;

        AudioClip chosen = warningSounds[Random.Range(0, warningSounds.Length)];

        if (warningSounds.Length > 1)
        {
            int safety = 0;
            while (chosen == lastPlayedClip && safety < 10)
            {
                chosen = warningSounds[Random.Range(0, warningSounds.Length)];
                safety++;
            }
        }

        lastPlayedClip = chosen;

        warningAudioSource.Stop();
        warningAudioSource.clip = chosen;
        warningAudioSource.volume = 0.35f;
        warningAudioSource.pitch = Random.Range(0.9f, 1.1f);
        warningAudioSource.Play();
    }

    void WarningIgnored()
    {
        warningActive = false;
        ignoredWarnings++;

        HorrorProgress.fearLevel += 1;

        if (warningText != null)
        {
            warningText.gameObject.SetActive(true);

            if (ignoredWarnings == 1)
                warningText.text = "You ignored it.";
            else if (ignoredWarnings == 2)
                warningText.text = "The computer glitches. Progress lost.";
            else
                warningText.text = "Something is closer.";
        }

        if (ignoredWarnings == 2)
            ResetComputerProgress();

        if (ignoredWarnings >= 3)
        {
            HorrorProgress.suspicionLevel += 2;
            HorrorProgress.shouldStartThreatCheck = true;
        }

        Invoke(nameof(HideWarningText), 2f);
        SetNextWarningTime();
    }

    void HideWarningText()
    {
        if (warningText != null)
            warningText.gameObject.SetActive(false);
    }

    void SetNextWarningTime()
    {
        timer = Random.Range(minTime, maxTime);
    }

    void ResetComputerProgress()
    {
        if (TaskManager.Instance != null)
            TaskManager.Instance.ResetAllTasks();
    }
}