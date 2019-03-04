using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = transform.position;
        pos.y = pos.y + 0.002f;
        transform.position = pos;
    }
}
