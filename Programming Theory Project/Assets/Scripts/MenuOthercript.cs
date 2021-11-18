using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuOthercript : MonoBehaviour
{
    public Text countSlabText;
    public Text countMassText;

    private void Start()
    {
        TextInfo();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        MenuScript.instance.Save();
    }
    private void TextInfo()
    {
        countMassText.text = "" + MenuScript.instance.CountMass;
        countSlabText.text = "" + MenuScript.instance.CountSlabs;
    }
}
