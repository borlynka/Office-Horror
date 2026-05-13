using UnityEngine;
using UnityEngine.InputSystem;

public class GameHorrorManager : MonoBehaviour
{
    public static GameHorrorManager Instance;

    [Header("FEAR")]
    public int fearLevel = 0;
    public int maxFearLevel = 12;

    [Header("SUSPICION")]
    public int suspicionLevel = 0;
    public int maxSuspicionLevel = 10;

    [Header("FEAR TIMERS")]
    public float normalFearInterval = 35f;
    public float computerFearInterval = 20f;

    [Header("WATCHER")]
    public float watcherMoveSpeed = 0.5f;
    public float watcherStopDistance = 1.2f;

    [Header("BLACKOUT")]
    public float blackoutChance = 0.4f;

    [Header("OFFICE DISTORTION")]
    public int crowdedSuspicionLevel = 10;
    public int nightmareFearLevel = 12;

    [Header("BOSS")]
    public int bossFearLevel = 12;

    [Header("MUSIC")]
    public float officeVolume = 0.4f;
    public float tensionVolume = 0.35f;
    public float nightmareVolume = 0.5f;

    [Header("DEBUG")]
    public bool forceNightmareMode = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            HorrorProgress.fearLevel++;
            fearLevel = HorrorProgress.fearLevel;
            Debug.Log("Fear Level: " + HorrorProgress.fearLevel);
        }

        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            HorrorProgress.suspicionLevel++;
            suspicionLevel = HorrorProgress.suspicionLevel;
            Debug.Log("Suspicion Level: " + HorrorProgress.suspicionLevel);
        }
    }
}