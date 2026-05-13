using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ExitComputer : MonoBehaviour
{
    void Start()
    {
        UnlockCursor();
    }

    void OnEnable()
    {
        UnlockCursor();
    }

    void Update()
    {
        // Force cursor visible while in computer scene
        UnlockCursor();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            HorrorProgress.playerOnComputer = false;

            if (!HorrorProgress.completedComputerTask)
            {
                HorrorProgress.computerExitCount++;

                int fearIncrease = Mathf.Min(2, HorrorProgress.computerExitCount);
                HorrorProgress.fearLevel += fearIncrease;
            }

            HorrorProgress.shouldStartThreatCheck = true;
            HorrorProgress.passByWarningUsedThisExit = false;

            SceneManager.LoadScene("Main Game");
        }
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}