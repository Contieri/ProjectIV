using UnityEngine;
using System.Collections;

public class DisplayObject : MonoBehaviour
{
    public string DescriptionText;

    public void SetEnabled(bool enable)
    {
        gameObject.SetActive(enable);
    }
}
