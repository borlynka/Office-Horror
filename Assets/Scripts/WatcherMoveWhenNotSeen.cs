using UnityEngine;
using UnityEngine.SceneManagement;

public class WatcherMoveWhenNotSeen : MonoBehaviour
{
    public Camera playerCamera;
    public Transform playerTarget;

    public float moveSpeed = 0.7f;
    public float stopDistance = 1.2f;
    public float loseDistance = 0.7f;

    public float graceTime = 1.0f; 
    // gives player time before it starts moving

    private float notSeenTimer = 0f;

    void Start()
    {
        if (playerCamera == null)
            playerCamera = Camera.main;
    }

    void Update()
    {
        if (playerCamera == null || playerTarget == null)
            return;

        bool playerCanSeeMe = IsVisibleToPlayer();

        if (playerCanSeeMe)
        {
            notSeenTimer = 0f;
        }
        else
        {
            notSeenTimer += Time.deltaTime;

            if (notSeenTimer >= graceTime)
            {
                MoveCloser();
            }
        }

        float distance = Vector3.Distance(transform.position, playerTarget.position);

        if (distance <= loseDistance)
        {
            Debug.Log("Player lost: watcher reached player");
            SceneManager.LoadScene("Main Menu");
        }
    }

    bool IsVisibleToPlayer()
    {
        Vector3 viewportPoint = playerCamera.WorldToViewportPoint(transform.position);

        bool isInFront = viewportPoint.z > 0;
        bool isOnScreen =
            viewportPoint.x > 0.05f && viewportPoint.x < 0.95f &&
            viewportPoint.y > 0.05f && viewportPoint.y < 0.95f;

        return isInFront && isOnScreen;
    }

    void MoveCloser()
    {
        Vector3 targetPosition = playerTarget.position;
        targetPosition.y = transform.position.y;

        float distance = Vector3.Distance(transform.position, targetPosition);

        if (distance > stopDistance)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );

            Vector3 direction = targetPosition - transform.position;
            direction.y = 0;

            if (direction.sqrMagnitude > 0.001f)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}