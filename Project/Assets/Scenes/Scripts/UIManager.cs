using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button PreviousButton;
    public Button NextButton;
    public PropertyToggle ToggleTemplate;

    public Transform TogglesParent;

    public ObjectManager Manager;

    public Button InformationButton;
    public TextMeshProUGUI InformationText;
    public float InformationOpenTime = 0.2f;

    private readonly List<PropertyToggle> _toggles = new List<PropertyToggle>();

    private bool _informationOpen;

    private void Start()
    {
        PreviousButton.onClick.AddListener(Previous);
        NextButton.onClick.AddListener(Next);
        InformationButton.onClick.AddListener(InformationClicked);
        UpdateObject();
    }

    private void InformationClicked()
    {
        _informationOpen = !_informationOpen;
        UpdateInformationTransform(true);
    }

    private void UpdateInformationTransform(bool tween)
    {
        RectTransform textTransform = InformationText.rectTransform;
        float size = textTransform.sizeDelta.y;

        float targetPos = _informationOpen ? 0 : size;

        if (tween)
        {
            textTransform.DOLocalMoveY(targetPos, InformationOpenTime);
        }
        else
        {
            Vector3 pos = textTransform.localPosition;
            pos.y = size;
            textTransform.localPosition = pos;
        }
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
        _informationOpen = false;

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
        
        InformationText.text = Manager.Current.DescriptionText;

        StartCoroutine(UpdateInformationRoutine());
    }

    IEnumerator UpdateInformationRoutine()
    {
        yield return new WaitForEndOfFrame();
        UpdateInformationTransform(false);
    }
}
