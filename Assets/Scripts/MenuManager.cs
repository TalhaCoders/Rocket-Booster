using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private RectTransform StartElement;
    [SerializeField] private RectTransform OptionElement;
    [SerializeField] private RectTransform Credit_element;
    [SerializeField] private RectTransform GameTitle;
    [SerializeField] private GameObject Option_panel , optionBack , credit_In;

    public float Start_value;
    public float Option_Value;
    public float Credit_Value;
    public float GameTitle_value;

    public float[] times;

    public Vector2 position;

    private void Start()
    {
        ShowMenu();
    }

    public void SceneChanger()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(sceneIndex);
    }

    private void ShowMenu()
    {
        StartElement.DOMoveX(Start_value, times[0]).SetEase(Ease.InOutBack);
        OptionElement.DOMoveX(-Option_Value, times[1]).SetEase(Ease.InOutBack);
        Credit_element.DOMoveX(Credit_Value, times[2]).SetEase(Ease.InOutBack);
        GameTitle.DOMoveY(-GameTitle_value, times[3]).SetEase(Ease.InOutBack);
        GameTitle.GetComponent<Image>().DOFade(1, 1);
    }

    public void StartAnimation()
    {
        StartElement.DOMoveX(-150, 1).SetEase(Ease.InBack);
        OptionElement.DOMoveX(150, 1).SetEase(Ease.InBack);
        Credit_element.DOMoveX(-150, 1).SetEase(Ease.InBack);
        GameTitle.DOMoveY(150, 1).SetEase(Ease.InBack);
        GameTitle.GetComponent<Image>().DOFade(1, 1);
        Invoke("SceneChanger", 1f);
    }

    public void OptionAnimation()
    {
        StartElement.DOMoveX(-150, 1).SetEase(Ease.InBack);
        OptionElement.DOMoveX(150, 1).SetEase(Ease.InBack);
        Credit_element.DOMoveX(-150, 1).SetEase(Ease.InBack);
        GameTitle.DOMoveY(150, 1).SetEase(Ease.InBack);
        GameTitle.GetComponent<Image>().DOFade(1, 1);
        Invoke("InvokeOption", 1f);
    }

    public void CreditAnimation()
    {
        StartElement.DOMoveX(-150, 1).SetEase(Ease.InBack);
        OptionElement.DOMoveX(150, 1).SetEase(Ease.InBack);
        Credit_element.DOMoveX(-150, 1).SetEase(Ease.InBack);
        GameTitle.DOMoveY(150, 1).SetEase(Ease.InBack);
        GameTitle.GetComponent<Image>().DOFade(1, 1);
        Invoke("InvokeCredit", 1f);
    }

    public void GetBack()
    {
        InvokeBackOption();
        ShowMenu();
    }

    #region invoking
    void InvokeOption()
    {
        Option_panel.SetActive(true);
    }
    void InvokeBackOption()
    {
        optionBack.SetActive(true);
    }
    void InvokeCredit()
    {
        credit_In.SetActive(true);
    }
    #endregion
}
