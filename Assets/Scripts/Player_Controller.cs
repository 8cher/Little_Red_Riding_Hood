using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody player_RB;
    public float move_Speed;
    private Vector2 move_Input;
    public Animator character_Animator;
    public Animator flip_Animator;
    public SpriteRenderer character_Sprite_Renderer;
    private bool player_Is_Moving = false;
    private bool player_Is_Moving_Backward = false;
    void Start()
    {

    }

    void Update()
    {
        move_Input.x = Input.GetAxis("Horizontal");
        move_Input.y = Input.GetAxis("Vertical");
        move_Input.Normalize();


        //use sprite renderer to flip pic
        if (!character_Sprite_Renderer.flipX && move_Input.x < 0)
        {
            character_Sprite_Renderer.flipX = true;
        }
        else if (character_Sprite_Renderer.flipX && move_Input.x > 0)
        {
            character_Sprite_Renderer.flipX = false;
        }

        //check if the player is moving, then set the animation to move
        if (move_Input.x == 0 && move_Input.y == 0)
        {
            player_Is_Moving = false;
            if (player_Is_Moving_Backward)
            {
                player_Is_Moving_Backward = false;
                flip_Animator.SetTrigger("flip");
            }
        }
        else
        {
            player_Is_Moving = true;
        }
        character_Animator.SetBool("moving", player_Is_Moving);



        //check if the player is moving backward
        if (move_Input.y > 0 && !player_Is_Moving_Backward)
        {
            player_Is_Moving_Backward = true;
            flip_Animator.SetTrigger("flip");
        }
        else if (move_Input.y < 0 && player_Is_Moving_Backward)
        {
            player_Is_Moving_Backward = false;
            flip_Animator.SetTrigger("flip");
        }
        character_Animator.SetBool("moving_Backward", player_Is_Moving_Backward);



        //Use Rigidbody to move player
        player_RB.velocity = new Vector3(move_Input.x * move_Speed, 0, move_Input.y * move_Speed);
    }
}
