using UnityEngine;
using UnityEngine.UIElements;
public class UIHandler : MonoBehaviour
{
    public static UIHandler instance { get; private set; }
    private VisualElement m_Healthbar;
    private Label m_EnergieCount;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar"); // Q est le diminutif de Query un peu comme jquery
        m_EnergieCount = uiDocument.rootVisualElement.Q<Label> ("EnergieCount");
        SetHealthValue(1.0f);
        SetEnergieValue(0);
    }

    public void SetHealthValue (float health)
    {
        m_Healthbar.style.width = Length.Percent(Mathf.Clamp(health, 0, 1) * 100);
    }

    public void SetEnergieValue(int energie) {
        m_EnergieCount.text = energie.ToString();
    }


}
