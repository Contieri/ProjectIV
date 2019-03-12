using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class ObjectManager : MonoBehaviour
{
    private DisplayObject[] _objects;

    private int _current;
   

    public DisplayObject Current => _objects[_current];

    private void Awake()
    {
        _objects = GetComponentsInChildren<DisplayObject>();

        for(int i = 0; i < _objects.Length; i++)
        {
            _objects[i].SetEnabled(i==0);
        }
    }

    public void Next()
    {
        ChangeObject(_current + 1);
    }

    public void Previous()
    {
        ChangeObject(_current - 1);
    }

    
    public void ChangeObject(int newIndex)
    {
        newIndex = (int)Mathf.Repeat(newIndex, _objects.Length);
        _objects[_current].SetEnabled(false);
        _objects[newIndex].SetEnabled(true);
        _current = newIndex;
        

    }
}
