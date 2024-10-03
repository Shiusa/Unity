using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private float jumpHeight = 1.5f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField]
    private bool groundedPlayer;

    // Start is called before the first frame update
    void Start()
    {

        controller = gameObject.GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (controller.isGrounded)
        {
            groundedPlayer = true;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * speed);

        // reoriente le perso vers la direction du deplacement
        if(move != Vector3.zero)
        {
            //forward = Z axis
            gameObject.transform.forward = move;
        }

        if (Input.GetButtonDown("Jump") && groundedPlayer) {
            groundedPlayer = false;
            Debug.Log("je saute");
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        } else
        {
            playerVelocity.y += gravity * Time.deltaTime;
        }

        // applique la gravite + saut
        controller.Move(playerVelocity * Time.deltaTime);
        
    }
}
