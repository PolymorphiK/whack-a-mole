using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T> {
	private static T instance = null;
	private static object mutex = new object();

	public static T Instance {
		get {
			lock(mutex) {
				if(instance == null) {
					instance = Object.FindObjectOfType<T>();

					if(instance == null) {
						var go = new GameObject(typeof(T).Name);

						go.SetActive(false);

						instance = go.AddComponent<T>();

						go.SetActive(true);
					}

					DontDestroyOnLoad(instance.gameObject);
				}

				return instance;
			}
		}
	}

	protected virtual void Awake() {
		if(Instance != this) {
			Destroy(this.gameObject);
			return;
		}
	}
}