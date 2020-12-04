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
        float xThrow = Input.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float xNew = Mathf.Clamp(transform.localPosition.x + xOffset, -1.0f * xMax, xMax);
        transform.localPosition = new Vector3(xNew,transform.localPosition.y,transform.localPosition.z);
    }

    private void ProcessVerticalMovement() {
        float yThrow = Input.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float yNew = Mathf.Clamp(transform.localPosition.y + yOffset, -1.0f * yMax, yMax);
        transform.localPosition = new Vector3(transform.localPosition.x,yNew,transform.localPosition.z);
    }
}
