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

        MainContainer.style.display = DisplayStyle.None;
        MainContainer.AddToClassList("hidden");
    }

    public void ShowWithAnim(int delayMs = 1)
    {
        if (MainContainer == null) return;

        MainContainer.style.display = DisplayStyle.Flex;

        // On retire hidden après un frame (ou delay) pour forcer la transition CSS
        MainContainer.schedule.Execute(() =>
        {
            MainContainer.RemoveFromClassList("hiddenFast");
            MainContainer.AddToClassList("showFast");
        }).StartingIn(delayMs);
    }

    public void HideWithAnim(bool immediate = false)
    {
        if (MainContainer == null) return;

        MainContainer.RemoveFromClassList("showFast");
        MainContainer.AddToClassList("hiddenFast");

        MainContainer.schedule.Execute(() =>
        {
            MainContainer.style.display = DisplayStyle.None;
        }).StartingIn(200);
    }
}
