using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

    Transform thisTrans;
    Camera cam;

    TextMesh thisText;

	// Use this for initialization
	void Start () {
        cam = this.GetComponent<Camera>();
        thisTrans = this.transform;
        thisText = this.GetComponentInChildren<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        Ray r = new Ray(thisTrans.position, thisTrans.forward);

        if(Physics.Raycast(r, out hit))
        {
            if(hit.transform.GetComponent<ClickText>() != null)
            {

                if (hit.transform.GetComponent<ClickText>().mustClick == true)
                {
                    if(Input.GetMouseButton(0) == true)
                    {
                        thisText.color = Color.Lerp(thisText.color, Color.black, 0.05f);
                        thisText.text = hit.transform.GetComponent<ClickText>().text;
                    }
                
                }
                else
                {
                    thisText.color = Color.Lerp(thisText.color, Color.black, 0.05f);
                    thisText.text = hit.transform.GetComponent<ClickText>().text;
                } 
            }
            else
            {
                thisText.color = Color.Lerp(thisText.color, new Color(-1, -1, -1, -1), 0.05f);
            }

            if (hit.transform.GetComponent<ParticlePlay>() != null && Input.GetMouseButtonDown(0) == true && hit.transform.GetComponent<ParticlePlay>().part.isPlaying == true)
            {
                hit.transform.GetComponent<ParticlePlay>().part.Stop();
            }
            else if (hit.transform.GetComponent<ParticlePlay>() != null && Input.GetMouseButtonDown(0) == true && hit.transform.GetComponent<ParticlePlay>().part.isPlaying == false)
            {
                hit.transform.GetComponent<ParticlePlay>().part.Play();
            }

            if (hit.transform.GetComponent<ChangeMaterial>() != null && Input.GetMouseButtonDown(0) == true)
            {
                hit.transform.GetComponent<ChangeMaterial>().refNum++;
                if(hit.transform.GetComponent<ChangeMaterial>().refNum >= hit.transform.GetComponent<ChangeMaterial>().materials.Length)
                {
                    hit.transform.GetComponent<ChangeMaterial>().refNum = 0;
                }
                hit.transform.GetComponent<MeshRenderer>().material = hit.transform.GetComponent<ChangeMaterial>().materials[hit.transform.GetComponent<ChangeMaterial>().refNum];
            }

            if (hit.transform.GetComponent<MakeInvisible>() != null && Input.GetMouseButtonDown(0) == true)
            {
                if(hit.transform.GetComponent<MakeInvisible>().thisRenderer.enabled == true)
                {
                    hit.transform.GetComponent<MakeInvisible>().thisRenderer.enabled = false;
                }
                else
                {
                    hit.transform.GetComponent<MakeInvisible>().thisRenderer.enabled = true;
                }
                
            }

            if (hit.transform.GetComponent<Destroy>() != null && Input.GetMouseButtonDown(0) == true)
            {
                Destroy(hit.transform.gameObject);
            }

            }
        else
        {
            thisText.color = Color.Lerp(thisText.color, new Color(-1,-1,-1,-1), 0.05f);
        }
	}
}
