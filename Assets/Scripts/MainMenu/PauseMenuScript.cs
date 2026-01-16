using System;
using UnityEngine.UIElements;

public class PauseMenuScript : ToogleableMenuesScript
{
    private Button ReprendreButton;
    private Button _OptionButton;
    private Button _QuitterButton;

    public event Action OnClickReprendre;
    public event Action OnClickQuitter;

    protected override void Awake()
    {
        base.Awake();
        ReprendreButton = _UIDocument.rootVisualElement.Q("ReprendreButton") as Button;
        _OptionButton = _UIDocument.rootVisualElement.Q("OptionButton") as Button;
        _QuitterButton = _UIDocument.rootVisualElement.Q("QuitterButton") as Button;

        ReprendreButton.clicked += () => OnClickReprendre?.Invoke();
        _QuitterButton.clicked += () => OnClickQuitter?.Invoke();
    }
}
