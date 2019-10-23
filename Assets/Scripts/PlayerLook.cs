using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
        [SerializeField] private string mouseXInputName, mouseYInputName;
        [SerializeField] private float mouseSens;

        [SerializeField] private Transform playerBody;
        private float xAxisClamp;
        private void Awake()
        {
            LockCursor();
            xAxisClamp = 0.0f;
        }
        private void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
        
        }

        private void Update()
        {
            CameraRotation();
        }

        private void CameraRotation()
        {
            float mouseX = Input.GetAxis(mouseXInputName) * mouseSens * Time.deltaTime;
            float MouseY = Input.GetAxis(mouseYInputName) * mouseSens * Time.deltaTime;

            xAxisClamp += MouseY;
            if(xAxisClamp > 90.0f)
            {
                xAxisClamp = 90.0f;
                MouseY = 0.0f;
                ClampXAxisRotationToValue(270.0f);
            } 
            else if(xAxisClamp < -90.0f)
            {
                xAxisClamp = -90.0f;
                MouseY = 0.0f;
                ClampXAxisRotationToValue(90.0f);
            } 
            

            transform.Rotate(Vector3.left * MouseY);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    
    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

}
