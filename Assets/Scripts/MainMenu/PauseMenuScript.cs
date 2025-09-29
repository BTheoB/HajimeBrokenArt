using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenuScript : MonoBehaviour
{
    private UIDocument _UIDocument;
    private Button ReprendreButton;
    private Button _OptionButton;
    private Button _QuitterButton;
    private VisualElement MainContainer;

    public event Action OnClickReprendre;
    public event Action OnClickQuitter;

    private void Awake()
    {
        _UIDocument = GetComponent<UIDocument>();
        MainContainer = _UIDocument.rootVisualElement.Q("MainContainer");
        ReprendreButton = _UIDocument.rootVisualElement.Q("ReprendreButton") as Button;
        _OptionButton = _UIDocument.rootVisualElement.Q("OptionButton") as Button;
        _QuitterButton = _UIDocument.rootVisualElement.Q("QuitterButton") as Button;

        ReprendreButton.clicked += () => OnClickReprendre?.Invoke();
        _QuitterButton.clicked += () => OnClickQuitter?.Invoke();

        HideWithAnim();
    }

    public void ShowWithAnim()
    {
        if (MainContainer == null) return;

        MainContainer.schedule.Execute(() =>
        {
            MainContainer.RemoveFromClassList("hiddenFast");
            
        });
    }

    public void HideWithAnim()
    {
        if (MainContainer == null) return;

        MainContainer.AddToClassList("hiddenFast");
    }
}
