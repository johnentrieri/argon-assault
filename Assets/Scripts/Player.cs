using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] float xSpeed, ySpeed;
    [SerializeField] float xMax, yMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessHorizontalMovement();
        ProcessVerticalMovement();
    }

    private void ProcessHorizontalMovement() {
        float horizontalThrow = Input.GetAxis("Horizontal");
        float xTarget = xMax * horizontalThrow;

        //Move Right
        if ( (xTarget - transform.localPosition.x) > (xSpeed * Time.deltaTime) ) {
            transform.Translate(Vector3.right * xSpeed * Time.deltaTime);
        } 
        
        //Move Left
        if ( (transform.localPosition.x - xTarget) > (xSpeed * Time.deltaTime) ) {
            transform.Translate(Vector3.left * xSpeed * Time.deltaTime);
        }
    }

    private void ProcessVerticalMovement() {
        float verticalThrow = Input.GetAxis("Vertical");
        float yTarget = yMax * verticalThrow;

        //Move Up
        if ( (yTarget - transform.localPosition.y) > (ySpeed * Time.deltaTime) ) {
            transform.Translate(Vector3.up * ySpeed * Time.deltaTime);
        } 

        //Move Down       
        if ( (transform.localPosition.y - yTarget) > (ySpeed * Time.deltaTime) ) {
            transform.Translate(Vector3.down * ySpeed * Time.deltaTime);
        }
    }
}
