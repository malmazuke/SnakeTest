using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour {
    
    public GameObject tail;
    public float idleSpeed = 5.0f;
    public float sprintSpeed = 10.0f;
    public float rotateSpeed = 5.0f;
    
    private bool isAlive;
    private Rigidbody rb;
    
    void Start () {
        isAlive = true;
        rb = GetComponent<Rigidbody> ();
    }
    
    // Update is called once per frame
    void Update () {
        if (isAlive) {
            MoveForward ();
        }
    }
    
    private void MoveForward () {
        rb.velocity = transform.forward * idleSpeed;
    }
}
