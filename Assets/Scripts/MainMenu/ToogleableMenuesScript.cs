using UnityEngine;
using UnityEngine.UIElements;

public class ToogleableMenuesScript : MonoBehaviour
{
    protected UIDocument _UIDocument;
    protected VisualElement MainContainer;

    protected virtual void Awake()
    {
        _UIDocument = GetComponent<UIDocument>();
        MainContainer = _UIDocument.rootVisualElement.Q("MainContainer");
        MainContainer.style.display = DisplayStyle.None;
        MainContainer.AddToClassList("hidden");
    }

    public virtual void ShowWithAnim(int delayMs = 1)
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
