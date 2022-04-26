using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animator_Play_AI : MonoBehaviour
{
    public NavMeshAgent player_Agent;
    private SpriteRenderer character_Sprite_Renderer;
    public Animator character_Animator;
    public Animator flip_Animator;
    [SerializeField]
    private bool player_Is_Moving = false;
    [SerializeField]
    private bool player_Is_Moving_Backward = false;
    public Sprite sprite_Front;
    public Sprite sprite_Back;
    const float movement_Threshold = 0.03f;


    private void Awake()
    {
        character_Sprite_Renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //use sprite renderer to flip chacter left and right
        if (!character_Sprite_Renderer.flipX && player_Agent.velocity.x < 0)
        {
            character_Sprite_Renderer.flipX = true;
        }
        else if (character_Sprite_Renderer.flipX && player_Agent.velocity.x > 0)
        {
            character_Sprite_Renderer.flipX = false;
        }

        //check if the player is moving, then set the animation to move
        if ((Mathf.Abs(player_Agent.velocity.x) + Mathf.Abs(player_Agent.velocity.z) <= movement_Threshold))
        {
            player_Is_Moving = false;
        }
        else
        {
            player_Is_Moving = true;
        }
        character_Animator.SetBool("moving", player_Is_Moving);

        //check if player has turned and play the animation
        if ((player_Agent.velocity.z > movement_Threshold) && (!player_Is_Moving_Backward))
        {
            player_Is_Moving_Backward = true;
            character_Sprite_Renderer.sprite = sprite_Back;
            flip_Animator.SetTrigger("flip");
        }
        else if ((player_Agent.velocity.z <= movement_Threshold) && player_Is_Moving_Backward)
        {
            player_Is_Moving_Backward = false;
            character_Sprite_Renderer.sprite = sprite_Front;
            flip_Animator.SetTrigger("flip");
        }
    }
}
