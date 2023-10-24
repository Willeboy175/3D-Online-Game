using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            float vert = Input.GetAxis("Vertical");
            float horz = Input.GetAxis("Horizontal");

            rb.velocity = new Vector3(horz, rb.velocity.y, vert);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * 500);
            }
        }
    }
}
