using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class setMessage : MonoBehaviour {
    public Button backButton;
    public GameObject noteBook;
    public GameObject shadow;
    public CanvasGroup noteBookAlph;
    public CanvasGroup shadowAlph;
    public Text text;
    public Image image;

    public void Start () {
        noteBookAlph.alpha = 0;
        shadowAlph.alpha = 0;
        noteBook.SetActive(false);
        shadow.SetActive(false);
        backButton.transform.SetSiblingIndex(100);                               
	}
    IEnumerator disappear()
    {
        yield return new WaitForSeconds(1.0f);
        noteBook.SetActive(false);
        shadow.SetActive(false);
    }	

	void Update () {		
	}
    public void showBook()
    {
        GetConcept();
        noteBook.SetActive(true);
        noteBookAlph.DOFade(1, 1);
        shadow.SetActive(true);
        shadowAlph.DOFade(0.7f, 1);
    }
    public void EscN()
    {
        noteBookAlph.DOFade(0, 1);
        shadowAlph.DOFade(0, 1);
        StartCoroutine(disappear());      
    }
    void GetConcept()
    {

    }
}
