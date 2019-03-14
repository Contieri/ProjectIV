using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class PropertyToggle : MonoBehaviour
{
    private Toggle _toggle;
    public TextMeshProUGUI Text;

    private DisplayObject _object;
    private string _property;

    void Awake()
    {
        _toggle = GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener(PropertyChanged);
    }

    public void SetProperty(DisplayObject obj, string property)
    {
        _object = obj;
        _property = property;
        Text.text = property;
    }

    private void PropertyChanged(bool value)
    {
        _object.SetPropery(_property, value);
    }
}
