using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimationTest : MonoBehaviour
{

    [Range(0.0f, 10.0f)]
    public float moveSpeed = 3.0f;
    private Vector2 _hidePos;
    private Vector2 _showPos;
    private RectTransform _rectTransfrom;
    private bool _isShow;
    private CanvasGroup canvasGroup;
    //private CanvasGroup canvasGroup;
    private float UI_Alpha = 1;
    public float alphaSpeed = 4f;

    public float _hidePosX;
    public float _hidePosY;

    //static GameObject itemObject1;
    //public GameObject AssetWindow;

    void Start()
    {


        _rectTransfrom = this.gameObject.GetComponent<RectTransform>();
        _hidePos = _rectTransfrom.anchoredPosition;
        //_showPos = new Vector2(_hidePos.x - _rectTransfrom.rect.width, _hidePos.y);
        _showPos = new Vector2(_hidePosX, _hidePosY);

        _isShow = false;
        canvasGroup = this.GetComponent<CanvasGroup>();


    }

    // Update is called once per frame
    void Update()
    {
        if (canvasGroup == null)
        {
            return;
        }

        if (UI_Alpha != canvasGroup.alpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, UI_Alpha, alphaSpeed * Time.deltaTime);
            if (Mathf.Abs(UI_Alpha - canvasGroup.alpha) <= 0.01f)
            {
                canvasGroup.alpha = UI_Alpha;
            }
        }


    }

    public void UI_FadeIn_Event()
    {
        UI_Alpha = 1;
        canvasGroup.blocksRaycasts = true;      //可以和该对象交互
    }

    public void UI_FadeOut_Event()
    {
        UI_Alpha =0;
        canvasGroup.blocksRaycasts = false;     //不可以和该对象交互
    }

    public void showUI()
    {
        if (_isShow)
        {

            HideMenu();
            UI_FadeOut_Event();
        }
        else
        {
            ShowMenu();
            UI_FadeIn_Event();
           
        }
    }

    public void ShowMenu()
    {

        GameObject.Find("叉").GetComponent<Button>();

        StartCoroutine(Appear());
    }

    public void HideMenu()
    {

        //GameObject.FindGameObjectWithTag("Title").GetComponent<Text>().text = "+";
        GameObject.Find("叉").GetComponent<Button>();
        StartCoroutine(Disappear());

    }

    IEnumerator Disappear()
    {

        _isShow = false;

        float time = Time.time;
        float timeDiff = 0;

        while (timeDiff < 1)
        {
            timeDiff = (Time.time - time) * moveSpeed;
            Vector2 currentPos = Vector2.Lerp(_showPos, _hidePos, timeDiff);
            _rectTransfrom.anchoredPosition = currentPos;

            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator Appear()
    {

        float time = Time.time;
        float timeDiff = 0;

        while (timeDiff < 1)
        {
            timeDiff = (Time.time - time) * moveSpeed;
            Vector2 currentPos = Vector2.Lerp(_hidePos, _showPos, timeDiff);
            _rectTransfrom.anchoredPosition = currentPos;

            yield return new WaitForEndOfFrame();
        }

        _isShow = true;
    }
}