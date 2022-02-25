using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Hood_Player_Controller : MonoBehaviour
{
    public Rigidbody red_Hood_RB;
    public float move_Speed;
    private Vector2 move_Input;
    public Animator red_Hood_Animator;
    public Animator flip_Animator;
    public SpriteRenderer red_Hood_Sprite_Renderer;
    private bool red_Hood_Is_Moving = false;
    private bool red_Hood_IS_Moving_Backward = false;

    void Start()
    {

    }

    void Update()
    {
        move_Input.x = Input.GetAxis("Horizontal");
        move_Input.y = Input.GetAxis("Vertical");
        move_Input.Normalize();


        //use sprite renderer to flip pic
        if (!red_Hood_Sprite_Renderer.flipX && move_Input.x < 0)
        {
            red_Hood_Sprite_Renderer.flipX = true;
        }
        else if (red_Hood_Sprite_Renderer.flipX && move_Input.x > 0)
        {
            red_Hood_Sprite_Renderer.flipX = false;
        }

        //check if the player is moving, then set the animation to move
        if (move_Input.x == 0 && move_Input.y == 0)
        {
            red_Hood_Is_Moving = false;
            if (red_Hood_IS_Moving_Backward)
            {
                red_Hood_IS_Moving_Backward = false;
                flip_Animator.SetTrigger("flip");
            }
        }
        else
        {
            red_Hood_Is_Moving = true;
        }
        red_Hood_Animator.SetBool("moving", red_Hood_Is_Moving);



        //check if the player is moving backward
        if (move_Input.y > 0 && !red_Hood_IS_Moving_Backward)
        {
            red_Hood_IS_Moving_Backward = true;
            flip_Animator.SetTrigger("flip");
        }
        else if (move_Input.y < 0 && red_Hood_IS_Moving_Backward)
        {
            red_Hood_IS_Moving_Backward = false;
            flip_Animator.SetTrigger("flip");
        }
        red_Hood_Animator.SetBool("moving_Backward", red_Hood_IS_Moving_Backward);



        //Use Rigidbody to move player
        red_Hood_RB.velocity = new Vector3(move_Input.x * move_Speed, 0, move_Input.y * move_Speed);

    }
}
