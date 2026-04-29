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
        anim = GetComponent<Animator>();

        if (npcType == NPCType.Sitting)
        {
            anim.SetTrigger("Sit");
        }
        else if (npcType == NPCType.Walking)
        {
            anim.SetTrigger("Walk");
        }
        else if (npcType == NPCType.Talking)
        {
            anim.SetTrigger("Talk");
        }
    }

    public void TriggerStandLookBack()
    {
        anim.SetTrigger("Stand");
    }
}