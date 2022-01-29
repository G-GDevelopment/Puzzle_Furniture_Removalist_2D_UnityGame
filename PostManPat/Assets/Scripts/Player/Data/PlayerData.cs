using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player")]
public class PlayerData : ScriptableObject
{
    [Header("Movement Parameter")]
    public float MovementVelocity = 10f;
    public float PlayerDrag = 0f;
    public float ColliderHeightStandard = 0.88f;
    public float ColliderOffsetStandard = -0.01f;

    [Header("Jump Parameter")]
    public float JumpForce = 15f;
    public float FallMultiplier = 2.5f;
    public float LowJumpMultiplier = 2f;
    public int AmountOfJumps = 1;

    [Header("In Air Parameter")]
    public float CoyoteTime = 0.2f;
    public float VariableJumpHeightMultiplier = 0.5f;

    [Header("WallSlide Parameter")]
    public float WallSlideVelocity = 3.0f;


    
    //[Header("Ability Parameter")]
}
