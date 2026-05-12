using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int correctClicks = 0;
    public int requiredClicks = 5;

    [Header("Unlock Icons")]
    public GameObject pdf1Icon;
    public GameObject pdf2Icon;
    public GameObject notesIcon;
    public GameObject googleIcon;

    [Header("UI")]
    public GameObject popupMessage;

    [Header("Effects")]
    public Animator accountingAnimator;
    public AudioSource glitchSound;

    private bool completed = false;

    void Awake()
    {
        Instance = this;
    }

    public void AddCorrect()
    {
        correctClicks++;

        Debug.Log("Correct clues: " + correctClicks);

        if (correctClicks >= requiredClicks && !completed)
        {
            completed = true;
            CompleteLevel1();
        }
    }

    void CompleteLevel1()
    {
        Debug.Log("LEVEL 1 COMPLETE");

        // Play glitch sound
        glitchSound.Play();

        // Trigger flicker animation
        accountingAnimator.SetTrigger("Glitch");

        // Unlock icons
        pdf1Icon.SetActive(true);
        pdf2Icon.SetActive(true);
        notesIcon.SetActive(true);
        googleIcon.SetActive(true);

        // Show popup
        popupMessage.SetActive(true);
    }
}