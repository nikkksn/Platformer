using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerFinish;
    [SerializeField] private GameObject deadWindow;
    [SerializeField] private float currentHealth;
    public ScoreManager scoreManager;
    private bool isAlive;


    private void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (currentHealth > 0)
        {
            isAlive = true;
        }
        else
        {
            isAlive = false;
        }

        CheckIsDeath();
    }

    private void CheckIsDeath()
    {
        if(isAlive == false)
        {
            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();

            float jumpForce = 5f; // Значение силы прыжка
            Vector2 jumpDirection = new Vector2(0.5f, 1f).normalized; // Нормализованный вектор для направления прыжка (вправо и вверх)

            playerRb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);

            CinemachineBrain cinemachineBrain = Camera.main.GetComponent<CinemachineBrain>();
            if (cinemachineBrain != null)
            {
                cinemachineBrain.enabled = false;
            }

            StartCoroutine(EnableTriggersAfterDelay());
            StartCoroutine(DeadPlayer());
        }
    }

    IEnumerator EnableTriggersAfterDelay()
    {

        yield return new WaitForSeconds(0.1f);
        player.GetComponent<CapsuleCollider2D>().isTrigger = true;
        playerFinish.GetComponent<CircleCollider2D>().isTrigger = true;
    }
    IEnumerator DeadPlayer()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
        deadWindow.SetActive(true);
        scoreManager.UpdateTextAllDead();
    }
}
