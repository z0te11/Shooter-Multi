using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] public Movement moveComp;
    [SerializeField] public Ability mainAbilityComp;
    [SerializeField] public Ability secondAbilityComp;
    [SerializeField] public PlayerAnimController animController;

    private void Update()
    {
        if (mainAbilityComp != null && UserInputSystem.mainAbilityInput > 0) mainAbilityComp.Execute();
        if (secondAbilityComp != null && UserInputSystem.secondAbilityInput > 0) secondAbilityComp.Execute();
    }

    private void FixedUpdate()
    {
        if (moveComp != null)
        {
            moveComp.Move(UserInputSystem.moveInput);
            if (animController != null) animController.MovePlayer(UserInputSystem.moveInput, moveComp.speed);
        } 
    }
}
