using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public Animator anim;

    PlayerMovementController player;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovementController>();
    }

    void Update()
    {
        SetPlayerAnimation(player.playerMoving);
    }
    
    void SetPlayerAnimation(bool isMoving)
    {
        if (isMoving)
        {
            anim.Play("catwalk_loop_251070");
        }
        else
        {
            anim.Play("Standing");
        }
    }
}
