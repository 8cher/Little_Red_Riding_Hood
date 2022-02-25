using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_Player_Controller : MonoBehaviour
{

    public Rigidbody wolf_RB;
    public float move_Speed;
    private Vector2 move_Input;
    public Animator wolf_Animator;
    public SpriteRenderer wolf_Sprite_Renderer;
    private bool wolf_Is_Moving = false;

    void Start()
    {

    }


    void Update()
    {
        move_Input.x = Input.GetAxis("Horizontal");
        move_Input.y = Input.GetAxis("Vertical");
        move_Input.Normalize();


        //use sprite renderer to flip pic
        if (!wolf_Sprite_Renderer.flipX && move_Input.x < 0)
        {
            wolf_Sprite_Renderer.flipX = true;
        }
        else if (wolf_Sprite_Renderer.flipX && move_Input.x > 0)
        {
            wolf_Sprite_Renderer.flipX = false;
        }


        //check if the player is moving, then set the animation to move
        if (move_Input.x != 0 || move_Input.y != 0)
        {
            wolf_Is_Moving = true;
        }
        else if (move_Input.x == 0 && move_Input.y == 0)
        {
            wolf_Is_Moving = false;
        }
        wolf_Animator.SetBool("moving", wolf_Is_Moving);

        //Use Rigidbody to move player
        wolf_RB.velocity = new Vector3(move_Input.x * move_Speed, 0, move_Input.y * move_Speed);



    }
}
