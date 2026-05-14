using UnityEngine;
using System.Collections;

public class MonitorFailureEvent : MonoBehaviour
{
    public Light computerScreenLight;
    public GameObject computerScreenGlow;

    public GameObject farBossObject;
    public Transform farBossSpawnPoint;

    public AudioSource glitchAudio;

    public int triggerFearLevel = 6;
    public float lockComputerTime = 5f;

    public float blinkOnTime = 0.15f;
    public float blinkOffTime = 0.2f;
    public int blinkCount = 3;

    void Update()
    {
        if (HorrorProgress.monitorFailurePlayed)
            return;

        if (HorrorProgress.fearLevel >= triggerFearLevel)
        {
            StartCoroutine(MonitorFailureRoutine());
        }
    }

    IEnumerator MonitorFailureRoutine()
    {
        HorrorProgress.monitorFailurePlayed = true;
        HorrorProgress.computerLocked = true;

        if (glitchAudio != null)
            glitchAudio.Play();

        // blink monitor light 2-3 times
        for (int i = 0; i < blinkCount; i++)
        {
            SetMonitor(false);
            yield return new WaitForSeconds(blinkOffTime);

            SetMonitor(true);
            yield return new WaitForSeconds(blinkOnTime);
        }

        SetMonitor(false);

        // boss appears far away
        if (farBossObject != null && farBossSpawnPoint != null)
        {
            farBossObject.SetActive(true);
            farBossObject.transform.position = farBossSpawnPoint.position;
            farBossObject.transform.rotation = farBossSpawnPoint.rotation;
        }

        yield return new WaitForSeconds(lockComputerTime);

        if (farBossObject != null)
            farBossObject.SetActive(false);

        SetMonitor(true);
        HorrorProgress.computerLocked = false;
    }

    void SetMonitor(bool isOn)
    {
        if (computerScreenLight != null)
            computerScreenLight.enabled = isOn;

        if (computerScreenGlow != null)
            computerScreenGlow.SetActive(isOn);
    }
}