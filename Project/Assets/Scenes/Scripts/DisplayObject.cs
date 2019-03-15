using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DisplayObject : MonoBehaviour
{
    public string DescriptionText;
    
    public List<string> Properties { get; } = new List<string>();

    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();

        foreach (AnimatorControllerParameter parameter in _animator.parameters)
        {
            if (parameter.type == AnimatorControllerParameterType.Bool)
                Properties.Add(parameter.name);
        }
    }

    public void SetEnabled(bool enable)
    {
        gameObject.SetActive(enable);
    }

    public void SetPropery(string name, bool value)
    {
        _animator.SetBool(name, value);
    }
}
