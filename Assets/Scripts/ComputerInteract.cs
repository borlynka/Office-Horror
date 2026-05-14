using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ComputerInteract : MonoBehaviour
{
    public float interactDistance = 3f;
    public Camera playerCamera;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (HorrorProgress.computerLocked)
                {
                    Debug.Log("Computer is temporarily unavailable.");
                    return;
                }
            if (HorrorProgress.finalBossMode || HorrorProgress.computerLocked)
                {
                    Debug.Log("Computer is no longer available.");
                    return;
                }
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.transform == transform || hit.transform.IsChildOf(transform))
                {
                    HorrorProgress.playerOnComputer = true;
                    SceneManager.LoadScene("Computer screen");
                }
            }
        }
    }
}