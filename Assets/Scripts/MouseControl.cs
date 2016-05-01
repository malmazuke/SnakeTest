using UnityEngine;
using System.Collections;

public class MouseControl : MonoBehaviour {

    private Snake snake;

    void Start () {
        snake = GetComponent<Snake> ();
    }

    // Update is called once per frame
    void Update () {
        if (snake.isAlive) {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint (mousePosition);
            mouseWorldPosition.y = transform.position.y;
            snake.MoveTowards (mouseWorldPosition);
        }
    }
}
