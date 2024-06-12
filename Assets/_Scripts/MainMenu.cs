using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Main components")]
    [SerializeField] GameObject ContentSlider;//This object holds all the tabs, we will move this to transition tabs
    [SerializeField] Button button_Middle;

    //Color highlights for buttons
    [SerializeField] Color selectedColor;
    [SerializeField] Color unselectedColor;

    [Header("Variables")]
    [SerializeField] private float transitionSpeed;
    private Button _currentSelectedButton = null;

    private float FarLeftPos;
    private float LeftPos;
    private float MiddlePos;
    private float RightPos;
    private float FarRightPos;

    void Start()
    {
        button_Middle.Select();
        SelectButton(button_Middle);

        RectTransform rect = ContentSlider.GetComponent<RectTransform>();
        
        //Measure width of screen
        float width = rect.rect.width;
        //Assign positions based on width of screen
        FarLeftPos = rect.localPosition.y;
        LeftPos = RightPos - width;
        MiddlePos = LeftPos - width;
        RightPos = MiddlePos - width;
        FarRightPos = RightPos - width;

        //Show middle tab
        ContentSlider.transform.DOLocalMoveX(MiddlePos, 0);
    }

    void Update()
    {

    }

    public void SelectButton(Button button)
    {
        if (_currentSelectedButton != null)
        {
            DeSelectButton(_currentSelectedButton);
            _currentSelectedButton.image.color = unselectedColor;
        }
        buttonSelection(button.gameObject, 180, 0.5f);
        _currentSelectedButton = button;
        button.image.color = selectedColor;
    }

    void DeSelectButton(Button button)
    {
        buttonSelection(button.gameObject, 150, 0.5f);
    }

    void buttonSelection(GameObject buttonObject, float height, float speed)
    {
        RectTransform rect = buttonObject.GetComponent<RectTransform>();
        rect.DOLocalMoveY(height, speed);
    }

    #region Tabs
    public void ShowFarLeftTab()
    {
        ContentSlider.transform.DOLocalMoveX(FarLeftPos, transitionSpeed);
    }

    public void ShowLeftTab()
    {
        ContentSlider.transform.DOLocalMoveX(LeftPos, transitionSpeed);
    }

    public void ShowMiddleTab()
    {
        ContentSlider.transform.DOLocalMoveX(MiddlePos, transitionSpeed);
    }

    public void ShowRightTab()
    {
        ContentSlider.transform.DOLocalMoveX(RightPos, transitionSpeed);
    }

    public void ShowFarRightTab()
    {
        ContentSlider.transform.DOLocalMoveX(FarRightPos, transitionSpeed);
    }
    #endregion

}
