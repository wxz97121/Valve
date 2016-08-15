using UnityEngine;
using System.Collections;

public class spriteupdate : MonoBehaviour {
    public Sprite many;
    public Sprite some;
    public Sprite few;
    public Sprite zero;
    public GameObject shadow;
    private GameObject Controller;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Controller = GameObject.FindGameObjectWithTag("GameController");
        if (Controller.GetComponent<MainController1>().have >= 12) gameObject.GetComponent<SpriteRenderer>().sprite = many;
        else if (Controller.GetComponent<MainController1>().have >= 6) gameObject.GetComponent<SpriteRenderer>().sprite = some;
        else if (Controller.GetComponent<MainController1>().have > 0) gameObject.GetComponent<SpriteRenderer>().sprite = few;
        else gameObject.GetComponent<SpriteRenderer>().sprite = zero;
        if (Controller.GetComponent<MainController1>().have == 0) shadow.SetActive(false); else shadow.SetActive(true);
    }
}
