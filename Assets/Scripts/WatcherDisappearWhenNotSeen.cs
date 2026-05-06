using UnityEngine;

public class WatcherDisappearWhenNotSeen : MonoBehaviour
{
    public Camera playerCamera;
    public float disappearDelay = 1.2f;

    private float notSeenTimer = 0f;

    void Update()
    {
        if (playerCamera == null)
            playerCamera = Camera.main;

        Vector3 viewportPoint = playerCamera.WorldToViewportPoint(transform.position);

        bool isInFront = viewportPoint.z > 0;
        bool isOnScreen =
            viewportPoint.x > 0 && viewportPoint.x < 1 &&
            viewportPoint.y > 0 && viewportPoint.y < 1;

        if (isInFront && isOnScreen)
        {
            notSeenTimer = 0f;
        }
        else
        {
            notSeenTimer += Time.deltaTime;

            if (notSeenTimer >= disappearDelay)
            {
                Destroy(gameObject);
            }
        }
    }
}