using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode runningKey = KeyCode.LeftShift;

    private Rigidbody playerRigidbody;

    float targetMovingSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        playerRigidbody.velocity = transform.rotation * new Vector3(Input.GetAxis("Horizontal"), playerRigidbody.velocity.y,
     Input.GetAxis("Vertical") * targetMovingSpeed);

        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * (100f * Time.deltaTime), Space.Self);
    }
}
