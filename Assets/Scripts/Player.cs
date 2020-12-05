using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] float xSpeed, ySpeed;
    [SerializeField] float xMax, yMax;
    private float xThrow, yThrow;
    [SerializeField] float yawPositionFactor, yawControlFactor, positionPitchFactor, controlPitchFactor, rollFactor;
    [SerializeField] float aimDistance;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        //ProcessAimRotation();
        ProcessNormalRotation();
    }

    void onCollisionEnter(Collision collision) {
        print(collision.gameObject.tag);
        
        switch(collision.gameObject.tag) {
            case "Terrain":
                print("Terrain Collision");
                break;
            default:
                break;
        }
    }

    private void ProcessTranslation() {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float xNew = Mathf.Clamp(transform.localPosition.x + xOffset, -1.0f * xMax, xMax);
        float yNew = Mathf.Clamp(transform.localPosition.y + yOffset, -1.0f * yMax, yMax);

        transform.localPosition = new Vector3(xNew,transform.localPosition.y,transform.localPosition.z);
        transform.localPosition = new Vector3(transform.localPosition.x,yNew,transform.localPosition.z);
    }

    private void ProcessNormalRotation() {
        float yaw = (transform.localPosition.x * yawPositionFactor) + (xThrow * yawControlFactor);
        float pitch = (transform.localPosition.y * positionPitchFactor) + (yThrow * controlPitchFactor);
        float roll = (xThrow * rollFactor);

        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);

    }
    private void ProcessAimRotation() {
        float xShip =  Camera.main.WorldToScreenPoint(transform.position).x;
        float yShip =  Camera.main.WorldToScreenPoint(transform.position).y;

        float xDiff = Input.mousePosition.x - xShip;
        float yDiff = yShip - Input.mousePosition.y;

        float xDepth = Mathf.Sqrt( (aimDistance * aimDistance) + (xDiff * xDiff) );
        float yDepth = Mathf.Sqrt( (aimDistance * aimDistance) + (yDiff * yDiff) );

        //DEBUG
        print("Ship: (" + xShip + "," + yShip + ")   Mouse: (" + Input.mousePosition.x + "," + Input.mousePosition.y + ")");


        float xTheta = Mathf.Atan( xDiff / xDepth ) * (180.0f / Mathf.PI);
        float yTheta = Mathf.Atan( yDiff / yDepth ) * (180.0f / Mathf.PI);

        transform.localRotation = Quaternion.Euler(yTheta,xTheta,0f);
    }
}
