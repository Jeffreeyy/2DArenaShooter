using UnityEngine;
using System.Collections;

public class ExplosionForce2D : MonoBehaviour
{
	[SerializeField]private float _power;
    public float Power
    {
        get
        {
            return _power;
        }
    }
	[SerializeField]private float _radius;
    public float Radius
    {
        get
        {
            return _radius;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{

# if (UNITY_EDITOR || UNITY_WEBPLAYER)

	    if (Input.GetKeyDown(KeyCode.Mouse1))
        {
		    Vector3 mousePos = Input.mousePosition;
		    mousePos.z = 10;
		    Vector3 objPos1 = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(mousePos);
		    AddExplosionForce(GetComponent<Rigidbody2D>(), _power * 100, objPos1, _radius);
	    }
# endif	
	
	}

	public void AddExplosionForce (Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
	{
		var dir = (body.transform.position - expPosition);
		float calc = 1 - (dir.magnitude / expRadius);
		if (calc <= 0) 
        {
				calc = 0;		
		}

		body.AddForce (dir.normalized * expForce * calc);
	}
}
