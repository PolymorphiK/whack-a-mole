using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger), typeof(Animator))]
public class Mole : MonoBehaviour {
    public Collider collider;

    public event System.Action onGotWhacked;
    public event System.Action onHidden;

    public void Whacked() {
        Debug.Log("Got Whacked!");

        Animator anim = GetComponent<Animator>();

        anim.SetTrigger("Hide");

        this.collider.enabled = false;

        this.onGotWhacked?.Invoke();
    }

    public void ResetState() {
        this.collider.enabled = true;

        Animator anim = GetComponent<Animator>();

        anim.SetTrigger("Show");
    }

    public void OnAnimation_Hide() {
        this.onHidden?.Invoke();
    }

    /// <summary>
    /// This method either shows or hides the Mole. It will
    /// trigger the Animator to play specific animation states.
    /// </summary>
    /// <param name="show">If true, plays the Show animation, else plays the Hide animation.</param>
    /// <param name="doDisableCollider">If true, disables the Collider, else disables the collider.</param>
    public void Show(bool show, bool doDisableCollider) {
        Animator anim = this.GetComponent<Animator>();

        if(show) {
            anim.SetTrigger("Show");
        } else {
            anim.SetTrigger("Hide");
        }

        this.collider.enabled = !doDisableCollider;
    }
}
