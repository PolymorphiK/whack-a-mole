using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persist : MonoBehaviour {
    public string id = "";

    void Start() {
        var instances = Object.FindObjectsOfType<Persist>();

        for(int i = 0; i < instances.Length; ++i) {
            if (instances[i] == this) continue;

            if(string.Compare(instances[i].id, this.id) == 0) {
                Destroy(this.gameObject);

                return;
            }
        }

        DontDestroyOnLoad(this);
    }
}
