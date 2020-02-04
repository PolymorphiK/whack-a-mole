using System.Collections.Generic;

public class ObjectPool <T> : System.Object, System.IDisposable where T : class {
    private List<T> pool = new List<T>();
    private System.Func<T> create = null;
    private System.Func<T, bool> isAvailable = null;
    private System.Action<T> free = null;
    private int capacity = 0;

    public ObjectPool(System.Func<T> create, System.Func<T, bool> isAvailable, System.Action<T> free, int capacity = 0) {
        this.create = create;
        this.isAvailable = isAvailable;
        this.free = free;

        this.capacity = capacity;

        if (this.capacity <= 0) this.capacity = int.MaxValue;

        this.pool = new List<T>(this.capacity);
	}

    public virtual bool Get(out T o) {
        for(int i = 0; i < this.pool.Count; ++i) {
            var item = this.pool[i];

            if(this.isAvailable(item)) {
                o = item;

                return true;
			}
        }

        if(this.capacity < this.pool.Count) {
            var clone = this.create();

            o = clone;

            return true;
		}

        o = default(T);
        return false;
	}

    public void Dispose() {
        for(int i = 0; i < this.pool.Count; ++i) {
            if(this.pool[i] != null) {
                this.free(this.pool[i]);
			}
		}

        this.pool.Clear();
        this.pool = null;
        this.create = null;
        this.isAvailable = null;
        this.free = null;
	}
}