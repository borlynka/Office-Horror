using UnityEngine;

public class NPCWalkBetweenPoints : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float moveSpeed = 1.5f;
    public float reachDistance = 0.4f;

    public float turnAnimationTime = 1.2f; // adjust to match your turn animation length

    private Transform targetPoint;
    private Animator anim;

    private bool isTurning = false;
    private bool hasStarted = false;
    private float turnTimer = 0f;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        targetPoint = pointB;

        FaceTargetInstantly();

        if (anim != null)
        {
            anim.SetTrigger("StartWalk");
            anim.SetBool("IsWalking", true);
        }

        hasStarted = true;
    }

    void Update()
    {
        if (pointA == null || pointB == null || !hasStarted)
            return;

        if (isTurning)
        {
            WaitForTurnAnimation();
        }
        else
        {
            WalkToTarget();
        }
    }

    void WalkToTarget()
    {
        Vector3 targetPosition = targetPoint.position;
        targetPosition.y = transform.position.y;

        float distance = Vector3.Distance(transform.position, targetPosition);

        if (distance <= reachDistance)
        {
            StartTurn();
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );
    }

    void StartTurn()
    {
        isTurning = true;
        turnTimer = 0f;

        if (anim != null)
        {
            anim.SetBool("IsWalking", false);
            anim.SetTrigger("Turn");
        }
    }

    void WaitForTurnAnimation()
    {
        turnTimer += Time.deltaTime;

        if (turnTimer >= turnAnimationTime)
        {
            targetPoint = targetPoint == pointA ? pointB : pointA;

            // after turn animation finishes, make code direction clean
            FaceTargetInstantly();

            isTurning = false;

            if (anim != null)
                anim.SetBool("IsWalking", true);
        }
    }

    void FaceTargetInstantly()
    {
        if (targetPoint == null)
            return;

        Vector3 direction = targetPoint.position - transform.position;
        direction.y = 0;

        if (direction.sqrMagnitude > 0.001f)
            transform.rotation = Quaternion.LookRotation(direction);
    }
}