using UnityEngine;
using TMPro;

public class ThreatCheckManager : MonoBehaviour
{
    public Camera playerCamera;
    public TextMeshProUGUI threatCheckText;

    public float sideAngle = 70f;
    public float behindAngle = 150f;

    private bool checkedLeft = false;
    private bool checkedRight = false;
    private bool checkedBehind = false;

    private bool threatCheckActive = false;
    private Vector3 startingForward;

    void Start()
    {
        if (playerCamera == null)
            playerCamera = Camera.main;

        if (threatCheckText != null)
            threatCheckText.gameObject.SetActive(false);

        if (HorrorProgress.shouldStartThreatCheck)
        {
            StartThreatCheck();
            HorrorProgress.shouldStartThreatCheck = false;
        }
    }

    void Update()
    {
        if (!threatCheckActive)
            return;

        CheckDirections();
        UpdateText();

        if (AllChecksComplete())
            CompleteThreatCheck();
    }

    public void StartThreatCheck()
    {
        threatCheckActive = true;

        checkedLeft = false;
        checkedRight = false;
        checkedBehind = false;

        startingForward = playerCamera.transform.forward;
        startingForward.y = 0;
        startingForward.Normalize();

        if (threatCheckText != null)
            threatCheckText.gameObject.SetActive(true);

        UpdateText();
    }

    void CheckDirections()
    {
        Vector3 currentForward = playerCamera.transform.forward;
        currentForward.y = 0;
        currentForward.Normalize();

        float angle = Vector3.SignedAngle(startingForward, currentForward, Vector3.up);

        if (angle <= -sideAngle && angle > -behindAngle)
            checkedLeft = true;

        if (angle >= sideAngle && angle < behindAngle)
            checkedRight = true;

        if (Mathf.Abs(angle) >= behindAngle)
            checkedBehind = true;
    }

    void UpdateText()
    {
        if (threatCheckText == null)
            return;

        threatCheckText.text =
            "LOOK AROUND\n\n" +
            (checkedLeft ? "[DONE] Left\n" : "[ ] Left\n") +
            (checkedRight ? "[DONE] Right\n" : "[ ] Right\n") +
            (checkedBehind ? "[DONE] Behind" : "[ ] Behind");
    }

    void CompleteThreatCheck()
    {
        threatCheckActive = false;

        HorrorProgress.suspicionLevel = Mathf.Max(0, HorrorProgress.suspicionLevel - 1);

        FearManager fearManager = FindObjectOfType<FearManager>();
        if (fearManager != null)
            fearManager.UpdateEnvironment();

        if (threatCheckText != null)
        {
            threatCheckText.text = "SAFE... FOR NOW.";
            Invoke(nameof(HideThreatText), 2f);
        }
    }

    void HideThreatText()
    {
        if (threatCheckText != null)
            threatCheckText.gameObject.SetActive(false);
    }

    bool AllChecksComplete()
    {
        return checkedLeft && checkedRight && checkedBehind;
    }
}