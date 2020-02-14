using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    public Text score;

    void OnEnable() {
        GameManager.Instance.onScored += this.OnScoreChanged;

        this.OnScoreChanged(GameManager.Instance.Score);
    }

    void OnDisable() {
        GameManager.Instance.onScored -= this.OnScoreChanged;
    }

    private void OnScoreChanged(int score) {
        this.score.text = "Score: " + score;
    }
}
