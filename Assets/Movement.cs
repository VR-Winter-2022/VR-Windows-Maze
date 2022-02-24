using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 35F;
    public float sprintSpeedMultiplier = 1.6F;
    public float jumpForce = 35F;

    private Vector3 inputVector;
    private bool isGrounded = true;
    // Start is called before the first frame update

    void FixedUpdate(){
        Vector3 movement = moveSpeed * 10F * inputVector.z * Time.fixedDeltaTime * transform.forward + 
                            moveSpeed * 10F *inputVector.x * Time.fixedDeltaTime * transform.right;
        rb.MovePosition(transform.position + movement * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision){

        Debug.Log("Entered");
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision){
        
        Debug.Log("Exited");
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update(){

        inputVector = new Vector3(Input.GetAxis("Horizontal"),0F,Input.GetAxis("Vertical"));
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded){
            inputVector.z *= sprintSpeedMultiplier;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(jumpForce * 10 * Vector3.up, ForceMode.Acceleration);
        }
        
    }


    
}
