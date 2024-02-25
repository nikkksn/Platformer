using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Shooter shooter;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
    }
    private void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);

        playerMovement.Move(horizontalDirection, isJumpButtonPressed);

        if (horizontalDirection < 0)
        {
            playerMovement.SetIsMirror(true);
        }
        else if (horizontalDirection > 0)
        {
            playerMovement.SetIsMirror(false);
        }

        if(Input.GetButtonDown(GlobalStringVars.FIRE_1))
        {
            shooter.Shoot(horizontalDirection);
        }    

    }
}
