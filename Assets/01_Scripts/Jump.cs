using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 jumpDirection = transform.forward + Vector3.up;

            jumpDirection.Normalize();

            rb.AddForce(jumpDirection * 10, ForceMode.Impulse);
        }
    }
}
