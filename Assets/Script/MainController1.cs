using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public GameObject NextController;
    private AudioSource newsAU;
    private AudioSource footstepsAU;
    private AudioSource supplyAU;
    private AudioSource ringAU;
    public AudioSource Boom;
    public GameObject myNews;
    public TextMesh Text1;
    public TextMesh Text2;
    [SerializeField]
    private string Good,Normal,Bad;
    [SerializeField]
    private GameObject TitleUI;
    [SerializeField]
    GameObject PreUIController, NowUIController;
    public AudioSource EndMusic;
    public GameObject[] Ending;
    public Text FiveYears;
    public UILabel Space;
    public GameObject Guide;
    //public int[] PeopleNeed;
    //public double[] P;

    IEnumerator EndOfDay()
    {
        if (gameObject.name == "MainController (4)") Boom.Play();
        gameObject.GetComponent<AudioSource>().DOFade(0, 3);
        myblack.DOColor(Color.black, 3);
        //播放结算动画
        yield return new WaitForSeconds(3);
        
        LD.delta = 0;
        if (gameObject.name == "MainController (5)")
        {
            EndMusic.Play();
            FiveYears.gameObject.SetActive(true);
            FiveYears.DOColor(Color.white, 3);
            yield return new WaitForSeconds(3);
            GetComponent<AudioSource>().Stop();
            myblack.DOColor(Color.white,5);
            FiveYears.DOColor(Color.clear, 3);
            yield return new WaitForSeconds(5);
            Ending[LD.Ending - 1].SetActive(true);
            yield return new WaitForSeconds(30);
            EndMusic.DOFade(0, 5);
            myblack.DOColor(Color.black, 3);
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("UI");
        }
        else
        if (gameObject.name == "MainController (4)")
        {
            TitleUI.GetComponent<UILabel>().text = "区域报告";
            part.text = "两百余人在空袭中丧生。袭击几乎摧毁了一切。";
        }
        else
        {
            TitleUI.GetComponent<UILabel>().text = "区域报告";
            all.text = (People.Length - AliveAll).ToString() + "人因为没有获得足够的物资而死亡。";
            if (AlivePart >= BigPart) { LD.delta += Part_1; part.text = Good; }
            else if (AlivePart >= SmallPart) { LD.delta += Part_2; part.text = Normal; LD.Ending = 1; }
            else { LD.delta += Part_3; part.text = Bad; LD.Ending = 1; }
        }
        //all.gameObject.GetComponent<AudioSource>().Play();

        /*        if (AliveAll >= BigAll) { LD.delta += All_1; all.text = "区域存活情况：A"; }
                else if (AliveAll >= SmallAll) { LD.delta += All_2; all.text = "区域存活情况：B"; }
                else { LD.delta += All_3; all.text = "区域存活情况：C"; }
                if (AlivePart >= BigPart) { LD.delta += Part_1; part.text = "重要产业强度：A"; }
                else if (AlivePart >= SmallPart) { LD.delta += Part_2; part.text = "重要产业强度：B"; }
                else { LD.delta += Part_3; part.text = "重要产业强度：C"; }
        */
        MyUI.SetActive(true);
        NowUIController.SetActive(true);
        //GameObject.FindGameObjectWithTag("Type").GetComponent<AudioSource>().volume = 1;
        //GameObject.FindGameObjectWithTag("Type").GetComponent<AudioSource>().Play();
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
            yield return new WaitForSeconds(5);
            Space.color = Color.white;
            while (!Input.GetKeyDown(KeyCode.Space))
                yield return null;
            Space.color = Color.black;
            PreUIController.SetActive(false);
            MyUI.SetActive(false);
        }
        CalenderObject.SetActive(true);
        CalenderUI.gameObject.SetActive(true);
        CalenderUI.text = Calender;
        GameObject.FindGameObjectWithTag("Type2").GetComponent<AudioSource>().volume = 1;
        GameObject.FindGameObjectWithTag("Type2").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(17);
        CalenderUI.gameObject.SetActive(false);
        myNews.SetActive(true);
        newsAU.Play();
        yield return new WaitForSeconds(8);
        myNews.SetActive(false);
        CalenderObject.SetActive(false);
        myblack.DOColor(Color.clear, 3);
        if (gameObject.name == "MainController")
        {
            Guide.GetComponent<SpriteRenderer>().DOColor(Color.white, 3);
            yield return new WaitForSeconds(3);
            while (!Input.anyKeyDown)
                yield return null;
            Guide.SetActive(false);
            
        }
        Flag = false;
    }

    IEnumerator Next()
    {
        Flag = true;
        //Debug.Log(now);
        if (now > 0 && (Happen[now - 1] == 0 || Happen[now - 1] == -100))
        {
            yield return new WaitForSeconds(2.25f);
            SB.Close();
            People[now - 1].GetComponent<SpriteRenderer>().DOColor(Color.clear, 1.5f);
            footstepsAU.Play();
            //离开的动画
            yield return new WaitForSeconds(2);
            People[now - 1].SetActive(false);
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
        //Debug.Log(Flag);
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
               //have -= myI.now;
                StartCoroutine(Next());
            }
            else if (Happen[now - 1] == -100 && People[now - 1].GetComponent<SpecialInteractive>().done == true)
            {
                SpecialInteractive myI = People[now - 1].GetComponent<SpecialInteractive>();
                if (myI.now >= myI.need) AliveAll++;
                //have -= myI.now;
                StartCoroutine(Next());
            }
        }
        else StartCoroutine(Next());
    }
}
