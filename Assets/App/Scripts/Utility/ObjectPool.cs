using UnityEngine;
using System.Collections.Generic;

public class ObjectPool {
    private List<GameObject> pool = new List<GameObject>();
    private int capcity = 0;
    private GameObject original;

    public ObjectPool(int capacity, GameObject original) {
        if(capacity <= 0) {
            this.pool = new List<GameObject>();
            this.capcity = int.MaxValue;
        } else {
            this.pool = new List<GameObject>(capacity);
            this.capcity = capcity;
        }

        this.original = original;
    }

    public bool GetItem(out GameObject go) {
        for(int i = 0; i < this.pool.Count; ++i) {
            if(this.pool[i].activeSelf == false) {
                go = this.pool[i];

                return true;
            }
        }

        if(this.pool.Count < this.capcity) {
            GameObject clone = GameObject.Instantiate(this.original);

            this.pool.Add(clone);

            go = clone;

            return true;
        }

        go = null;

        return false;
    }
}