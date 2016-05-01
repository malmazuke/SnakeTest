using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Snake : MonoBehaviour {

    public GameObject tailPrefab;
    public int numberOfInitialTailSegments = 5;
    public float idleSpeed = 5.0f;
    public float sprintSpeed = 10.0f;
    public float rotateSpeed = 5.0f;

    public bool isAlive { get; private set; }

    private float currentVelocity;
    private Rigidbody rb;
    private LinkedList<GameObject> segments;

    void Start () {
        isAlive = true;
        rb = GetComponent<Rigidbody> ();
        currentVelocity = idleSpeed;

        segments = new LinkedList<GameObject> ();
        segments.AddLast (gameObject);
        GameObject prevSegment = gameObject;
        for (int i = 0; i < numberOfInitialTailSegments; i++) {
            GameObject tailSegment = (GameObject)Object.Instantiate (tailPrefab);
            Vector3 pos = prevSegment.transform.position;
            pos.z = pos.z - prevSegment.GetComponent<SphereCollider> ().radius * 2.0f;
            tailSegment.transform.position = pos;
            segments.AddLast (tailSegment);
            prevSegment = tailSegment;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (isAlive) {
            if (Input.GetMouseButton (0)) {
                currentVelocity = sprintSpeed;
            } else {
                currentVelocity = idleSpeed;
            }
            MoveForward ();
        }
    }

    private void MoveForward () {

        // Starting tail to head
        LinkedListNode<GameObject> node = segments.Last;
        LinkedListNode<GameObject> previousNode = node.Previous;
        while (previousNode != null) {
            GameObject segment = node.Value;
            segment.transform.LookAt (previousNode.Value.transform);
            segment.transform.position = Vector3.Lerp (segment.transform.position, previousNode.Value.transform.position, currentVelocity * Time.deltaTime);

            node = previousNode;
            previousNode = node.Previous;
        }

        LookAtMouse ();
        rb.velocity = transform.forward * currentVelocity;
    }

    private void LookAtMouse () {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint (mousePosition);
        mouseWorldPosition.y = transform.position.y;

        transform.LookAt (mouseWorldPosition);
    }
}
