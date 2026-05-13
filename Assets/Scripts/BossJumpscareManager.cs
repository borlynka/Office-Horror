using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class BossJumpscareManager : MonoBehaviour
{
    public GameObject bossObject;
    public Transform bossSpawnPoint;
    public AudioSource jumpscareAudio;
    public Image blackScreen;

    public int fearLevelToTrigger = 12;

    public float firstPause = 2f;
    public float secondPause = 2f;
    public float afterBossAppearDelay = 2f;

    private bool hasTriggered = false;

    void Start()
    {
        if (bossObject != null)
            bossObject.SetActive(false);

        ShowBlackScreen(0f);
    }

    void Update()
    {
        if (hasTriggered)
            return;

        if (HorrorProgress.fearLevel >= fearLevelToTrigger)
        {
            StartCoroutine(FinalBossSequence());
        }
    }

    IEnumerator FinalBossSequence()
    {
        hasTriggered = true;
        HorrorProgress.finalBossMode = true;

        OfficeDistortionManager distortionManager =
            FindObjectOfType<OfficeDistortionManager>();

        if (distortionManager != null)
            distortionManager.UpdateOfficeStage();

        // blink 1
        ShowBlackScreen(1f);
        yield return new WaitForSeconds(0.25f);
        ShowBlackScreen(0f);

        yield return new WaitForSeconds(firstPause);

        // blink 2
        ShowBlackScreen(1f);
        yield return new WaitForSeconds(0.35f);
        ShowBlackScreen(0f);

        yield return new WaitForSeconds(secondPause);

        // boss appears
        if (bossObject != null && bossSpawnPoint != null)
        {
            bossObject.SetActive(true);
            bossObject.transform.position = bossSpawnPoint.position;
            bossObject.transform.rotation = bossSpawnPoint.rotation;
        }

        if (jumpscareAudio != null)
            jumpscareAudio.Play();

        yield return new WaitForSeconds(afterBossAppearDelay);

        // final death cut
        ShowBlackScreen(1f);
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Game Over");
    }

    void ShowBlackScreen(float alpha)
    {
        if (blackScreen == null)
            return;

        blackScreen.gameObject.SetActive(alpha > 0f);

        Color c = blackScreen.color;
        c.a = alpha;
        blackScreen.color = c;
    }
}