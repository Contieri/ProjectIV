using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform CenterOfInterest;

    private Vector2 _lastMouse;

    public float Sensivity = 1;

    public float Distance = 5;
    public float VericalRotationLimit = 90;

    private float _angleX;
    private float _angleY;

    void Start()
    {
        transform.position = CenterOfInterest.position + Quaternion.Euler(_angleX, _angleY, 0) * CenterOfInterest.forward * Distance;
        Vector3 direction = CenterOfInterest.position - transform.position;

        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }



    void RotateComponent()
    {
        Vector2 current = Input.mousePosition;
        Vector2 delta = current - _lastMouse;

        _angleY += Sensivity * Time.deltaTime * delta.x;
        _angleX += Sensivity * Time.deltaTime * delta.y;

        _angleX = ClampAngle(-VericalRotationLimit, VericalRotationLimit, _angleX);

        transform.position = CenterOfInterest.position + Quaternion.Euler(_angleX, _angleY, 0) * CenterOfInterest.forward * Distance;

        Vector3 direction = CenterOfInterest.position - transform.position;

        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    void Transladeobject()
    {
        Vector2 current = Input.mousePosition;    
    }

    void MaximizeAndMinimizeObject()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Camera>().fieldOfView--;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Camera>().fieldOfView++;
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastMouse = Input.mousePosition;
        }

        else if (Input.GetMouseButton(0))
        {
            RotateComponent();   
        }

        MaximizeAndMinimizeObject();
    }

    float ClampAngle(float min, float max, float angle)
    {
        if (angle > 180)
            angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
