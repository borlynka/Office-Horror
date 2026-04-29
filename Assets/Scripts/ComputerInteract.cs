using UnityEngine;
using UnityEngine.SceneManagement;

public class ComputerInteract : MonoBehaviour
{
    public float interactDistance = 3f;
    public Camera playerCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.transform == transform)
                {
                    SceneManager.LoadScene("Computer screen");
                }
            }
        }
    }
}