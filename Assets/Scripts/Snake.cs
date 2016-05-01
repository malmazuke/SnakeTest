using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour {
    
    public float idleSpeed = 5.0f;
    public float sprintSpeed = 10.0f;
    public float rotateSpeed = 5.0f;
    
    public bool isAlive { get; private set; }

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

    public void MoveTowards (Vector3 position) {
        transform.LookAt (position);
    }
}
