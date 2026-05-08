using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ExitComputer : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
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

            // allow only one pass-by warning after each computer exit
            HorrorProgress.passByWarningUsedThisExit = false;

            SceneManager.LoadScene("Main Game");
        }
    }
}