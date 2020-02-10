using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float diamonds;

    public Text diamondsTxt;

    private void Awake()
    {
        instance = this;
        diamondsTxt.text = "Diamonds: " + diamonds.ToString();
    }

    public void UpdateResourse()
    {
        diamondsTxt.text = "Diamonds: " + diamonds.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
