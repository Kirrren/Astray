using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [Header("Components")]
    public TriggerController playerAttackBox;
    public InputManager inputs;
    public PlayerMovementController player;
    public Animator playerAnim;
    public GameObject playerSword;

    [Header("Base Stats")]
    public float playerAttackStr;
    public float playerHP;

    [Header("Skills")]
    public float dashForce;

    bool playerAttacking;


    void Start()
    {
        inputs = GetComponent<InputManager>();
        player = GetComponent<PlayerMovementController>();
    }

    void Update()
    {
        PlayerBasicAttack();
        PlayerDash();
        SwingSword();
    }

    public void PlayerBasicAttack()
    {
        if (Input.GetMouseButtonDown(0) || playerAttacking)
        {
            playerAttacking = true;
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
            playerAnim.Play("Running");
            Vector3 inputDir = inputs.GetMovementInput().normalized * dashForce;
            Vector3 moveDir = player.playerTransform.forward * inputDir.x + player.playerTransform.right * inputDir.z;
            player.playerRB.AddForce(moveDir, ForceMode.Impulse);
        }
    }

    public void SwingSword()
    {
        if (playerAttacking)
        {
            playerSword.SetActive(true);
            Transform sword = playerSword.GetComponent<Transform>();
            sword.rotation =  Quaternion.Euler
            (sword.rotation.x, sword.rotation.y - 10f, sword.rotation.z);
            if (sword.rotation.y < 0)
            {
                playerSword.SetActive(false);
                sword.rotation = Quaternion.Euler(0, 180, 90);
                playerAttacking = false;
            }
        }
    }
}