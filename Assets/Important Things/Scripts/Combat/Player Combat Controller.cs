using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    public float playerAttackStr;
    public float playerHP;

    public TriggerController playerAttackBox;

    void PlayerBasicAttack()
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
}