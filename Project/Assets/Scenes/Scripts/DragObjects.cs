using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjects : MonoBehaviour
{
    private float _distance = 5;

    void OnMouseDrag()
    {

                Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance);
//              Vector3  objPosition = Camera.main.ScreenToWorldPoint((mousePosition));
            
              transform.position = mousePosition;
        
        
    }

    
    void Update()
    {

       if(Input.GetMouseButton(1)) OnMouseDrag();


    }
}
