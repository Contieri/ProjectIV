using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button PreviousButton;
    public Button NextButton;

    public ObjectManager Manager;

    public Text ObjectNameText;

    private void Start()
    {
        PreviousButton.onClick.AddListener(Previous);
        NextButton.onClick.AddListener(Next);
        UpdateName();
    }

    void Previous()
    {
        Manager.Previous();
        UpdateName();
    }

    void Next()
    {
        Manager.Next();
        UpdateName();
    }

    private void UpdateName()
    {
        ObjectNameText.text = Manager.Current.DescriptionText;
    }
}
