using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireForce;
    [SerializeField] private Transform firePoint;

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void Shoot(float direction)
    {
        GameObject currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

        if(playerMovement != false && playerMovement.ShootCheck)
        {
            currentBulletVelocity.velocity = new Vector2(fireForce * -1, currentBulletVelocity.velocity.y);
        }
        else
        {
            currentBulletVelocity.velocity = new Vector2(fireForce * 1, currentBulletVelocity.velocity.y);
        }
    }
}
