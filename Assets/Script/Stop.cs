using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Stop : MonoBehaviour
{
    [SerializeField]
    private UILabel all, part, title;

    public void stop()
    {
        gameObject.GetComponent<AudioSource>().DOFade(0, 1);
/*        if (this.tag == "Type")
        {
            all.GetComponent<TypewriterEffect>().ResetToBeginning();
            part.GetComponent<TypewriterEffect>().ResetToBeginning();
            title.GetComponent<TypewriterEffect>().ResetToBeginning();
        }
*/
        return;
    }

    // Use this for initialization s
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
