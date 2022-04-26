using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody player_RB;
    public float current_Speed;
    public float normal_Speed;
    private Vector2 move_Input;

    void Start()
    {
        current_Speed = normal_Speed;
    }
    private void Update()
    {
        move_Input.x = Input.GetAxis("Horizontal");
        move_Input.y = Input.GetAxis("Vertical");
        move_Input.Normalize();

        //Use Rigidbody to move player
        player_RB.velocity = new Vector3(move_Input.x * current_Speed, 0, move_Input.y * current_Speed);
    }

    public virtual void OnTriggerEnter(Collider other) { }
}