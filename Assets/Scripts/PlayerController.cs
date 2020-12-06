using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    [Header("Movement Speed")]
    [SerializeField] float xSpeed;
    [SerializeField] float ySpeed;

    [Header("Screen Limits")]
    [SerializeField] float xMax;
    [SerializeField] float yMax;

    [Header("Rotation")]  
    [SerializeField] float positionYawFactor;
    [SerializeField] float controlYawFactor;
    [SerializeField] float positionPitchFactor;
    [SerializeField] float controlPitchFactor;
    [SerializeField] float rollFactor;
    [SerializeField] float aimDistance;

    [Header("Guns")]
    [SerializeField] GameObject[] guns;

    private float xThrow;
    private float yThrow;
    private bool isControlEnabled;

    // Start is called before the first frame update
    void Start() {
        isControlEnabled = true;
    }

    // Update is called once per frame
    void Update() {
        if (!isControlEnabled) { return; }

        ProcessTranslation();
        //ProcessAimRotation();
        ProcessNormalRotation();
        ProcessFiring();
    }

    
    public void OnPlayerDeath() { //Called by String Reference
        isControlEnabled = false;
        DeactivateGuns();
    }

    private void ActivateGuns() {
        foreach(GameObject gun in guns ) {
            gun.SetActive(true);
        }
    }

    private void DeactivateGuns() {
        foreach(GameObject gun in guns ) {
            gun.SetActive(false);
        }
    }

    private void ProcessFiring() {
       if( Input.GetButton("Fire1") ) {
           ActivateGuns();
       } else {
            DeactivateGuns();
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
        float yaw = (transform.localPosition.x * positionYawFactor) + (xThrow * controlYawFactor);
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

        float xTheta = Mathf.Atan( xDiff / xDepth ) * (180.0f / Mathf.PI);
        float yTheta = Mathf.Atan( yDiff / yDepth ) * (180.0f / Mathf.PI);

        transform.localRotation = Quaternion.Euler(yTheta,xTheta,0f);
    }    
}
