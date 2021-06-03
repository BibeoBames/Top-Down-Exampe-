using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private Image expBar;
    [SerializeField] private Image hpBar;
    [SerializeField] private Text lvlText;
    [SerializeField] private Text expText;
    [SerializeField] private Text HpText;
    [SerializeField] private Text infoText;
    private IEnumerator infoCoroutine;

    public void UpdateXpUi(int lvl, int neededExp, int exp )
    {
        lvlText.text = "lvl: " + lvl;
        expText.text = "exp: " + exp;
        float fill = (float)exp / (float)neededExp;
        expBar.fillAmount = fill;
    }

    public void UpdateHpUi(int health, int max)
    {
        HpText.text = "hp: " + health;
        float fill = (float)health / (float)max;
        hpBar.fillAmount = fill;
    }

    public void ShowGameOverScreen()
    {
        GameOverScreen.active = true;
    }

    public void RestartButtonOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowInfo(string info, float seconds)
    {
        if (infoCoroutine != null) StopCoroutine(infoCoroutine);
        infoCoroutine = InfoCoroutine(info, seconds);
        StartCoroutine(infoCoroutine);
    }

    private IEnumerator InfoCoroutine(string info, float seconds)
    {
        infoText.text = info;
        yield return new WaitForSeconds(seconds);
        infoText.text = "";
    }
}
