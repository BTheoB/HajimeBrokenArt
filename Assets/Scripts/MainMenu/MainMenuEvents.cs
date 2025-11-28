using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;
public class MainMenu : MonoBehaviour
{
    private UIDocument _UIDocument;
    private Button _button;
    private VisualElement ButtonContainer;
    private VisualElement TitleContainer;

    private void Awake()
    {
        _UIDocument = GetComponent<UIDocument>();
        _button = _UIDocument.rootVisualElement.Q("StartButton") as Button;
        ButtonContainer = _UIDocument.rootVisualElement.Q("ContainerButtons");
        TitleContainer = _UIDocument.rootVisualElement.Q("TitleContainer");

        HideWithAnim(ButtonContainer);
        HideWithAnim(TitleContainer);
    }

    private void OnEnable()
    {
        _button.clicked += OnClickPlay;
    }

    private void OnDisable()
    {
        _button.clicked -= OnClickPlay;
        HideWithAnim(ButtonContainer);
        HideWithAnim(TitleContainer);
    }

    private void Start()
    {
        //schedule.Execute s'assure que unity peinte la première frame et que hidden sois bien appliqué aux EV
        //Ui toolkit realiser les transition uniquement si y'a un changement d'état une fois la première frame peinte
        StartCoroutine(AnimateUI());
    }

    private IEnumerator AnimateUI()
    {
        yield return new WaitForSeconds(0.1f);
        ShowWithAnim(TitleContainer);

        yield return new WaitForSeconds(1f); // attend 0.2 s
        ShowWithAnim(ButtonContainer);
    }


    private void OnClickPlay() {
        SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
    }

    public static void ShowWithAnim(VisualElement ve, int delayMs = 0)
    {
        if (ve == null) return;
        ve.schedule.Execute(() =>
        {
            ve.AddToClassList("show");
            ve.RemoveFromClassList("hidden");
        }).StartingIn(delayMs);
    }

    public static void HideWithAnim(VisualElement ve)
    {
        if (ve == null) return;

        ve.RemoveFromClassList("show");
        ve.AddToClassList("hidden");
    }
}
