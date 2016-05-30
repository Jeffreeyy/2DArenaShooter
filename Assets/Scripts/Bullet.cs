using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [SerializeField]private float _projectileSpeed;
	
    void Start()
    {
        Destroy(this.gameObject, 2.5f);
    }

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * _projectileSpeed * Time.deltaTime);
	}

    void OnDestroy()
    {
        //PlayParticles();
    }
}
