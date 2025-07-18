using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public Animator anim;
    public string walkAnimation;
    public string idleAnimation;

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
        if (isMoving && player.playerRB.linearVelocity.magnitude < 8)
        {
            anim.Play(walkAnimation);
        }
        else if (!isMoving)
        {
            anim.Play(idleAnimation);
        }
    }
}
