using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MainController1 : MonoBehaviour
{
    public int now;
    private bool Flag;
    public int have;
    public int[] Happen;
    //负数 减少补给，正数 增加补给，100 停止补给，0 有人进来，-100特殊对话
    public GameObject[] People;
    public bool[] done;
    private int AliveAll;
    private int AlivePart;
    public int BigPart;
    public int SmallPart;
    public int BigAll;
    public int SmallAll;
    public int Part_1;
    public int Part_2;
    public int Part_3;
    public int All_1;
    public int All_2;
    public int All_3;
    public int type;
    public UILabel all;
    public UILabel part;
    //public GameObject black;
    public SpriteRenderer myblack;
    //public Light mylight;
    public LastDay LD;
    public Subtitles SB;
    public GameObject MyUI;
    public string Calender;
    public GameObject CalenderObject;
    public UILabel CalenderUI;
    private GameObject TitleUI;
    public GameObject NextController;
    private AudioSource newsAU;
    private AudioSource footstepsAU;
    private AudioSource supplyAU;
    private AudioSource ringAU;
    public GameObject myNews;
    public TextMesh Text1;
    public TextMesh Text2;
    [SerializeField]
    private string Good,Normal,Bad;
    //public int[] PeopleNeed;
    //public double[] P;

    IEnumerator EndOfDay()
    {

        gameObject.GetComponent<AudioSource>().DOFade(0, 3);
        myblack.DOColor(Color.black, 3);
        //播放结算动画
        yield return new WaitForSeconds(3);
        MyUI.SetActive(true);
        LD.delta = 0;
        if (gameObject.name == "MainController (5)")
        {
            GameObject.FindGameObjectWithTag("Title").GetComponent<UILabel>().text = "Fin.";
            all.text = "真正而持久的胜利就是和平, 而不是战争——拉尔夫•沃尔多•埃莫森";
            part.text = "";
            yield return new WaitForSeconds(1000);
        }
        else
        if (gameObject.name == "MainController (4)")
        {
            part.text = "两百余人在空袭中丧生。袭击几乎摧毁了一切。";
        }
        else
        {
            all.text = (People.Length - AliveAll).ToString() + "人因为没有获得足够的物资而死亡。";
            if (AlivePart >= BigPart) { LD.delta += Part_1; part.text = Good; }
            else if (AlivePart >= SmallPart) { LD.delta += Part_2; part.text = Normal; }
            else { LD.delta += Part_3; part.text = Bad; }
        }
        //all.gameObject.GetComponent<AudioSource>().Play();
        //GameObject.FindGameObjectWithTag("Type").GetComponent<AudioSource>().Play();

        /*        if (AliveAll >= BigAll) { LD.delta += All_1; all.text = "区域存活情况：A"; }
                else if (AliveAll >= SmallAll) { LD.delta += All_2; all.text = "区域存活情况：B"; }
                else { LD.delta += All_3; all.text = "区域存活情况：C"; }
                if (AlivePart >= BigPart) { LD.delta += Part_1; part.text = "重要产业强度：A"; }
                else if (AlivePart >= SmallPart) { LD.delta += Part_2; part.text = "重要产业强度：B"; }
                else { LD.delta += Part_3; part.text = "重要产业强度：C"; }
        */

        NextController.SetActive(true);
        Destroy(gameObject);
    }

    public void Start()
    {
        
        newsAU = GameObject.FindGameObjectWithTag("news").GetComponent<AudioSource>();
        footstepsAU = GameObject.FindGameObjectWithTag("footstep").GetComponent<AudioSource>();
        supplyAU = GameObject.FindGameObjectWithTag("supply").GetComponent<AudioSource>();
        ringAU = GameObject.FindGameObjectWithTag("ring").GetComponent<AudioSource>();
        Flag = true;
        DOTween.Init();
        AliveAll = 0;
        AlivePart = 0;
        now = 0;
        have += LD.delta;
        StartCoroutine(First());
    }

    IEnumerator First()
    {
        gameObject.GetComponent<AudioSource>().Play();
        Flag = true;

        if (gameObject.name != "MainController")
        {
            yield return new WaitForSeconds(8);
            MyUI.SetActive(false);
        }
        CalenderObject.SetActive(true);
        CalenderUI.gameObject.SetActive(true);
        CalenderUI.text = Calender;
        GameObject.FindGameObjectWithTag("Type2").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(12);
        CalenderUI.gameObject.SetActive(false);
        myNews.SetActive(true);
        newsAU.Play();
        yield return new WaitForSeconds(8);
        myNews.SetActive(false);
        Flag = false;
        CalenderObject.SetActive(false);
        myblack.DOColor(Color.clear, 3);
        yield return null;
    }

    IEnumerator Next()
    {
        Flag = true;
        //Debug.Log(now);
        if (now > 0 && (Happen[now - 1] == 0 || Happen[now - 1] == -100))
        {
            People[now - 1].GetComponent<SpriteRenderer>().DOColor(Color.clear, 2);
            footstepsAU.Play();
            //离开的动画
            yield return new WaitForSeconds(2);
            People[now - 1].SetActive(false);
            SB.Close();
            //气泡消失
        }
        //Debug.Log(People.Length);
        if (now == People.Length)
        {
            //一天过去了。
            StartCoroutine(EndOfDay());
            yield break;
        }
        if (have <= 0)
        {
            AudioSource outof = GameObject.FindGameObjectWithTag("OutOf").GetComponent<AudioSource>();
            outof.Play();
            //播音发完了.
            yield return new WaitForSeconds(9);
            StartCoroutine(EndOfDay());
            yield break;
        }
        if (Happen[now] < 0 && Happen[now] > -100)
        {
            //播音减少供给
            yield return new WaitForSeconds(1);
            have += Happen[now];
            done[now] = true;
            now++;
            yield return null;
        }
        if (Happen[now] == 100)
        {
            //播音结束补给
            AudioSource FKD = GameObject.FindGameObjectWithTag("FKD").GetComponent<AudioSource>();
            FKD.Play();
            yield return new WaitForSeconds(6);
            StartCoroutine(EndOfDay());
            now++;
            yield break;
        }
        if (Happen[now] > 0)
        {
            //播音增加补给
            yield return new WaitForSeconds(1);
            have += Happen[now];
            done[now] = true;
            now++;
            yield return null;
        }
        footstepsAU.Play();
        //进入的动画
        //Debug.Log("What?");
        People[now].SetActive(true);
        if (Happen[now] == 0) StartCoroutine(People[now].GetComponent<Interactive>().First());
        else StartCoroutine(People[now].GetComponent<SpecialInteractive>().First());
        //People[now].GetComponent<SpriteRenderer>().DOFade(255, 3);
        People[now].GetComponent<SpriteRenderer>().DOColor(Color.white, 2);
        yield return new WaitForSeconds(2);
        now++;
        Flag = false;
    }
    void Update()
    {
        Text1.text = have.ToString();
        Text2.text = (Happen.Length-now).ToString();
        if (Flag) return;
        if (now != 0)
        {
            if (Happen[now - 1] != 0 && done[now - 1] && Happen[now - 1] != -100) StartCoroutine(Next());
            else if (Happen[now - 1] == 0 && People[now - 1].GetComponent<Interactive>().done == true)
            {
                
                Interactive myI = People[now - 1].GetComponent<Interactive>();
                if (myI.now >= myI.need)
                {
                    AliveAll++;
                    if (type == myI.type) AlivePart++;
                }
                have -= myI.now;
                StartCoroutine(Next());
            }
            else if (Happen[now - 1] == -100 && People[now - 1].GetComponent<SpecialInteractive>().done == true)
            {
                SpecialInteractive myI = People[now - 1].GetComponent<SpecialInteractive>();
                if (myI.now >= myI.need) AliveAll++;
                have -= myI.now;
                StartCoroutine(Next());
            }
        }
        else StartCoroutine(Next());
    }
}
