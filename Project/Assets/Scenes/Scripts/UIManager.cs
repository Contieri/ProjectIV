using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button PreviousButton;
    public Button NextButton;
    public PropertyToggle ToggleTemplate;

    public Transform TogglesParent;

    public ObjectManager Manager;

    public TextMeshProUGUI ObjectNameText;

    private List<PropertyToggle> _toggles = new List<PropertyToggle>();

    private void Start()
    {
        PreviousButton.onClick.AddListener(Previous);
        NextButton.onClick.AddListener(Next);
        UpdateObject();
    }
    
    void Previous()
    {
        Manager.Previous();
        UpdateObject();
    }

    void Next()
    {
        Manager.Next();
        UpdateObject();
    }

    private void UpdateObject()
    {
        foreach (PropertyToggle toggle in _toggles)
        {
            Destroy(toggle.gameObject);
        }

        _toggles.Clear();

        DisplayObject current = Manager.Current;

        foreach (string property in current.Properties)
        {
            PropertyToggle toggle = Instantiate(ToggleTemplate.gameObject, TogglesParent, false).GetComponent<PropertyToggle>();
            toggle.gameObject.SetActive(true);
            toggle.SetProperty(current, property);
            _toggles.Add(toggle);
        }

        ObjectNameText.text = Manager.Current.DescriptionText;
    }
}
