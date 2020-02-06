using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public Transform[] holes = new Transform[0];
    public GameObject mole;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Transform hole = this.holes[Random.Range(0, this.holes.Length)];

            this.mole.transform.position = hole.position;

            this.StartCoroutine(this.ShowMole());
        }
    }

    IEnumerator ShowMole() {
        Animator anim = mole.GetComponent<Animator>();

        anim.SetTrigger("Show");

        yield return new WaitForSeconds(1.0F);

        anim.SetTrigger("Hide");
    }
}
