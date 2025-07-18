using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [Header("Components")]
    public TriggerController playerAttackBox;
    public InputManager inputs;
    public PlayerMovementController player;
    public Animator playerAnim;
    public Animator swordAnim;
    public GameObject playerSword;

    [Header("Base Stats")]
    public float playerAttackStr;
    public float playerHP;

    [Header("Skills")]
    public float dashForce;
    public float cooldownDuration;

    bool playerAttacking = false;
    bool attackReady = true;
    float attackDuration = .36f;
    float timer = 0;


    void Start()
    {
        inputs = GetComponent<InputManager>();
        player = GetComponent<PlayerMovementController>();
        playerSword.SetActive(false);
    }

    void Update()
    {
        PlayerBasicAttack();
        PlayerDash();
        PlayerSwing();
    }

    public void PlayerBasicAttack()
    {
        if (Input.GetMouseButtonDown(0) && !playerAttacking)
        {
            //swordAnim.Play("Cyberswing");
            playerAttacking = true;
            Debug.Log("Player Attacking");
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

    public void PlayerSwing()
    {
        if (playerAttacking)
        {
            playerSword.SetActive(true);
            if (playerAttackBox.triggerEntered && playerAttackBox.collisionObject.name != "null")
            {
                playerAttackBox.collisionObject.GetComponent<EnemyMovement>().DamageEnemy(playerAttackStr);
                Debug.Log("Player Hit Enemy");
            }
            timer += Time.deltaTime;
            if (timer > attackDuration)
            {
                playerSword.SetActive(false);
                playerAttacking = false;
                attackReady = false;
                timer = 0;
                Debug.Log("Player Attack Finished");
            }
        }
    }

    public void AttackCooldown()
    {
        if (!attackReady)
        {
            timer += Time.deltaTime;
            if (timer > cooldownDuration)
            {
                timer = 0;
                attackReady = true;
            }
        }
    }
}