using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlay : MonoBehaviour {

    public ParticleSystem part;

	// Use this for initialization
	void Start () {
        part = this.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
