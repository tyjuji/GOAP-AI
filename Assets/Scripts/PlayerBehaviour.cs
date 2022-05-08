using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    int walkSpeed = 5;

    CharacterController charCtrl;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        charCtrl.enableOverlapRecovery = false;
        charCtrl.detectCollisions = false;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CharacterMovement();
    }

    private void Update()
    {
        LookRotation();
    }

    private void LookRotation()
    {
        //Vector3 pos = Input.mousePosition;

        //var worldpos = cam.ScreenToWorldPoint(pos + 100f * Vector3.forward);
        //Debug.Log(pos + " | " + worldpos);
        ////worldpos.y = 0;
        //transform.LookAt(worldpos);
        //transform.rotation.eulerAngles.x = 0;

        //Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Debug.Log(Input.mousePosition + " | " + mousePos);
        //transform.Rotate()


        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        //lookPos = lookPos - transform.position;
        //float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        transform.LookAt(lookPos);
        var oldangles = transform.eulerAngles;
        oldangles.x = 0;
        oldangles.z = 0;
        transform.eulerAngles = oldangles;


        //Mouse Position in the world. It's important to give it some distance from the camera. 
        //If the screen point is calculated right from the exact position of the camera, then it will
        ////just return the exact same position as the camera, which is no good.
        //Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

        ////Angle between mouse and this object
        //float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);

        ////Ta daa
        //transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
    }

    private void CharacterMovement()
    {
        // Get Horizontal and Vertical Input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the Direction to Move based on the tranform of the Player
        Vector3 moveDirectionForward = transform.forward * verticalInput;
        Vector3 moveDirectionSide = transform.right * horizontalInput;

        //find the direction
        Vector3 direction = (moveDirectionForward + moveDirectionSide).normalized;
        //find the distance
        Vector3 distance = direction * walkSpeed * Time.deltaTime;

        // Apply Movement to Player

        charCtrl.Move(distance);
        
    }

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
