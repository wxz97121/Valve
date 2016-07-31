using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Stop : MonoBehaviour {
    public void stop()
    {
        gameObject.GetComponent<AudioSource>().DOFade(0, 1);
        return;
    }

	// Use this for initialization s
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
