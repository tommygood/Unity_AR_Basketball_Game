using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {
    
    private bool is_shot = false;
    
    private Vector2 first_pos; // first pos of player touch
    
    private Vector2 last_pos; // last pos of player touch
    
    private Vector3 start_pos; // start pos of ball
    
    public Rigidbody rb;
    
    public GameObject ball;
    
    public GameObject ball_child;
    
    void Start() {
        start_pos = ball.transform.position;
    }
    
    void Update() // 600,500  (9.7)20,(-9.25)13.95
    {
        /*if (Input.touchCount > 0)
            Debug.Log(Input.GetTouch(0).position.x);*/
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            first_pos = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && (Input.GetTouch(0).position.y < 350)) { // shot
            transform.position = new Vector3(transform.position.x, (Input.GetTouch(0).position.y)/872.5f, transform.position.z);
            is_shot = true;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && is_shot) { // last pos of shot
            if (Input.GetTouch(0).position.y >= 350) // max height = 350
                last_pos.y = 350f;
            else 
                last_pos = Input.GetTouch(0).position;
            for (int i = 1;i < 1001;i++) 
                Invoke("Move", i*0.001f);
            Invoke("UseGravity", 1f); // at the top, start the gravity
            Invoke("BallBack", 5f); // put the ball back
        }
    }
    
    void Move() {
        transform.position = new Vector3(transform.position.x+(((last_pos.x-first_pos.x)/30f)/1000), transform.position.y+0.002f, transform.position.z+((Mathf.Abs(last_pos.y-first_pos.y)/10f)/5000));
    }
    
    void UseGravity() {
        rb.isKinematic = false;
    }
    
    void BallBack() {
        ball.transform.position = start_pos;
        ball_child.transform.position = start_pos;
        ball_child.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        rb.isKinematic = true;
    }
}
