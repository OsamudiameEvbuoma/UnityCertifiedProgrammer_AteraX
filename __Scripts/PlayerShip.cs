using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour 
{
    static private PlayerShip _S;
    static public PlayerShip S 
    {
        get 
        {
            return _S;
        }
        private set 
        {
            if (_S != null)
            {
                Debug.LogWarning("Second attempt to set playerShip singleton _S");
            }
            _S = value;
        }
    }

    [Header("Set In Inspector")]
    public float shipSpeed = 10f;
    public GameObject bulletPrefab;
    Rigidbody rigid;

	void Start () 
    {
        S = this;

        rigid = GetComponent<Rigidbody>();
	}

    private void Update()
    {
        float aX = CrossPlatformInputManager.GetAxis("Horizontal");
        float aY = CrossPlatformInputManager.GetAxis("Vertical");

        // one unit in the x and y makes more than one unit in the diagonal
        Vector3 vel = new Vector3(aX, aY);
        if(vel.magnitude > 1)
        {
            vel.Normalize();
        }

        rigid.velocity = vel * shipSpeed;

        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire ()
    {

    }
}
