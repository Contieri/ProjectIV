using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChangeColor : MonoBehaviour
{
    public Transform To;
    public float Duration = 3;
    public Color Color;
    public Color ToColor;
    private float _inicialtime = 1;
    private float _endingtime = 3;

    private Renderer _renderer;


    Vector3 GetPosition()
    {
        return transform.position;
    }

    void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        DOTween.To(() => _renderer.material.color, (color) => _renderer.material.color = color, ToColor, Duration);
        transform.DORotate(GetPosition(), Duration, RotateMode.Fast);
        _renderer.material.DOFade(_inicialtime, _endingtime);

    }



}
