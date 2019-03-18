using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenInformation : MonoBehaviour
{
    public Transform To;
    public float Duration = 5;


    Vector3 GetPosition()
    {
        return transform.position;
    }

    void SetPosition(Vector3 position)
    {
        transform.position = position;
    }



    Vector3 GetNewPosition()
    {
        return To.position;
    }

    Vector3 GetScale()
    {
        return transform.localScale;
    }


    void Start()
    {



    }



}
