using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject target;

    private bool isFollowing;
	
    void Start () {
        isFollowing = true;
    }

	// Update is called once per frame
	void Update () {
        if (isFollowing) {
            Vector3 destination = target.transform.position;
            destination.y = transform.position.y;
            transform.position = destination;
        }
	}
}
