using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderRools : MonoBehaviour
{
    [SerializeField] private GameObject enemyBody;
    [SerializeField] private GameObject enemyBodyEmpty;
    [SerializeField] private GameObject enemyHead;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject Player;
    [SerializeField] private int deadEnemyValue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damageable"))
        {
                JumpPlayer();
                JumpEnemy();
        }
    }

    private void JumpPlayer()
    {
        Rigidbody2D PlayerRb = Player.GetComponent<Rigidbody2D>();
        PlayerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void JumpEnemy()
    {
        Rigidbody2D enemyBodyRb = enemyBody.GetComponent<Rigidbody2D>();
        Rigidbody2D enemyHeadRb = enemyHead.GetComponent<Rigidbody2D>();

        float jumpForce = 5f; 
        Vector2 jumpDirection = new Vector2(0.5f, 1f).normalized; 

        enemyBodyRb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
        ScoreManager.instance.AddDeadEnemy(deadEnemyValue);
        StartCoroutine(EnableTriggersAfterDelay());
    }

    IEnumerator EnableTriggersAfterDelay()
    {

        yield return new WaitForSeconds(0.1f); 
        enemyBody.GetComponent<CapsuleCollider2D>().isTrigger = true;
        enemyBodyEmpty.GetComponent<CapsuleCollider2D>().isTrigger = true;
        enemyHead.GetComponent<CircleCollider2D>().isTrigger = true;
        enemyHead.SetActive(false);
        enemyBodyEmpty.SetActive(false);
    }
}
