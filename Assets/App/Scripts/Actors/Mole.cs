using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger), typeof(Animator))]
public class Mole : MonoBehaviour {
    public void Whacked() {
        Debug.Log("Got Whacked!");

        Animator anim = GetComponent<Animator>();

        anim.SetTrigger("Hide");  
    }
}
