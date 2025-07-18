using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [Header("Components")]
    public TriggerController playerAttackBox;
    public InputManager inputs;
    public PlayerMovementController player;

    [Header("Base Stats")]
    public float playerAttackStr;
    public float playerHP;

    [Header("Skills")]
    public float dashForce;


    void Start()
    {
        inputs = GetComponent<InputManager>();
        player = GetComponent<PlayerMovementController>();
    }

    void Update()
    {
        PlayerBasicAttack();
        PlayerDash();
    }

    public void PlayerBasicAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Player Attacking");
            if (playerAttackBox.triggerEntered)
            {
                playerAttackBox.collisionObject.GetComponent<EnemyMovement>().DamageEnemy(playerAttackStr);
                Debug.Log("Player Hit Enemy");
            }
        }
    }

    public void PlayerDash()
    {
        if (Input.GetKeyDown(inputs.dash))
        {
            Vector3 inputDir = inputs.GetMovementInput().normalized * dashForce;
            Vector3 moveDir = player.playerTransform.forward * inputDir.x + player.playerTransform.right * inputDir.z;
            player.playerRB.AddForce(moveDir, ForceMode.Impulse);
        }
    }
}