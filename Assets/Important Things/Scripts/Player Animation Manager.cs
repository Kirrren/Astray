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
        if (isMoving)
        {
            anim.Play(walkAnimation);
        }
        else
        {
            anim.Play(idleAnimation);
        }
    }
}
