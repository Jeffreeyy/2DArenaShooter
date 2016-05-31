using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

    [SerializeField]private float _destoryTime;

	void Start () {
        Destroy(this.gameObject, _destoryTime);
	}
}
