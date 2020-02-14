using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {
    public Transform[] holes = new Transform[0];
    public Mole mole;
    public int scoreAmount;

    public event System.Action<int> onScored;

    private int lastHoleIndex = -1;
    private int score;

    private void Start() {
        this.mole.onGotWhacked += Mole_onGotWhacked;

        this.StartCoroutine(this.StartGame());
    }

    public int Score {
        get {
            return this.score;
        }
    }

    private void Mole_onGotWhacked() {
        Debug.Log("+5 Points!");

        this.score += this.scoreAmount;

        //        if(this.onScored != null) {
        //            this.onScored.Invoke(this.score);
        //       }

        this.onScored?.Invoke(this.score);

        this.StartCoroutine(this.ResetMole());
    }

    IEnumerator ResetMole() {
        this.StopCoroutine("MonitorMole");

        yield return new WaitForSeconds(0.5F);

        this.ShowMole();
    }

    IEnumerator MonitorMole() {
        yield return new WaitForSeconds(2.0F);

        this.mole.Show(show: false, doDisableCollider: false);

        this.mole.onHidden += Mole_onHidden;
    }

    private void Mole_onHidden() {
        this.mole.onHidden -= this.Mole_onHidden;

        this.StartCoroutine(this.ResetMole());
    }

    IEnumerator StartGame() {
        Debug.Log("GET READY!");

        yield return new WaitForSeconds(2.0F);

        this.ShowMole();
    }

    private void ShowMole() {
        this.mole.ResetState();

        int next = Random.Range(0, this.holes.Length);

        while(next == this.lastHoleIndex) {
            next = Random.Range(0, this.holes.Length);
        }

        Transform hole = this.holes[next];

        this.lastHoleIndex = next;

        this.mole.transform.position = hole.position;

        this.StartCoroutine("MonitorMole");
    }
}
