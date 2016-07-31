using UnityEngine;
using System.Collections;

public class spriteupdate : MonoBehaviour {
    public Sprite many;
    public Sprite some;
    public Sprite few;
    public Sprite zero;
    private GameObject Controller;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Controller = GameObject.FindGameObjectWithTag("GameController");
        if (Controller.GetComponent<MainController1>().have >= 15) gameObject.GetComponent<SpriteRenderer>().sprite = many;
        else if (Controller.GetComponent<MainController1>().have >= 5) gameObject.GetComponent<SpriteRenderer>().sprite = some;
        else if (Controller.GetComponent<MainController1>().have > 0) gameObject.GetComponent<SpriteRenderer>().sprite = few;
        else gameObject.GetComponent<SpriteRenderer>().sprite = zero;

    }
}
