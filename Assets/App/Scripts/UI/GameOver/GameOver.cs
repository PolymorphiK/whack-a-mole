using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public Text score;

    void OnEnable() {
        this.score.text = "You Scored: " + GameManager.Instance.Score;
    }

    public void OnRestart() {
        GameManager.Instance.Restart();

        this.gameObject.SetActive(false);
    }
}