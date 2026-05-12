using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class MonitorFailureManager : MonoBehaviour
{
    public Light computerScreenLight;
    public Camera playerCamera;
    public TextMeshProUGUI warningText;

    public float interactDistance = 3f;
    public int minimumFearLevel = 3;
    public float blackoutChance = 0.4f;
    public float blackoutDelay = 2f;

    private bool monitorOff = false;

    void Start()
    {
        if (playerCamera == null)
            playerCamera = Camera.main;

        // Always reset monitor ON when returning to Main Game
        monitorOff = false;

        if (computerScreenLight != null)
            computerScreenLight.enabled = true;

        if (warningText != null)
            warningText.gameObject.SetActive(false);

        // If player completed a computer task, reduce fear
        if (HorrorProgress.completedComputerTask)
        {
            HorrorProgress.fearLevel = Mathf.Max(0, HorrorProgress.fearLevel - 2);
            HorrorProgress.completedComputerTask = false;
        }

        // Delay blackout so it does not instantly feel broken
        Invoke(nameof(TryStartBlackout), blackoutDelay);
    }

    void Update()
    {
        if (!monitorOff)
            return;

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            TryRestartMonitor();
        }
    }

    void TryStartBlackout()
    {
        if (HorrorProgress.fearLevel < minimumFearLevel)
            return;

        if (Random.value > blackoutChance)
            return;

        TurnMonitorOff();
    }

    void TurnMonitorOff()
    {
        monitorOff = true;

        if (computerScreenLight != null)
            computerScreenLight.enabled = false;

        if (warningText != null)
        {
            warningText.gameObject.SetActive(true);
            warningText.text = "RESTART THE MONITOR\nLook at the screen and press E";
        }
    }

    void TryRestartMonitor()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.transform.CompareTag("Computer"))
            {
                RestartMonitor();
            }
        }
    }

    void RestartMonitor()
    {
        monitorOff = false;

        if (computerScreenLight != null)
            computerScreenLight.enabled = true;

        if (warningText != null)
            warningText.gameObject.SetActive(false);
    }
}