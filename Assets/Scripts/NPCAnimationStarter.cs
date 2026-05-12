using UnityEngine;

public class NPCAnimationStarter : MonoBehaviour
{
    public enum NPCType
    {
        Sitting,
        Walking,
        Talking
    }

    public NPCType npcType;

    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        if (npcType == NPCType.Sitting)
        {
            anim.SetTrigger("Sit");
        }
        else if (npcType == NPCType.Talking)
        {
            anim.SetTrigger("Talk");
        }
        else if (npcType == NPCType.Walking)
        {
            // Do nothing here.
            // Walking NPC animation is controlled by NPCWalkBetweenPoints.
        }
    }

    public void TriggerStandLookBack()
    {
        anim.SetTrigger("Stand");
    }
}