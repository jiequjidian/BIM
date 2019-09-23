using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    private Vector2 _hidePos;
    private Vector2 _showPos;
    private RectTransform _rectTransfrom;
    private bool _isShow;
    public float _hidePosX;
    public float _hidePosY;
    // Start is called before the first frame update
    public void Start()
    {
        _rectTransfrom = this.gameObject.GetComponent<RectTransform>();
        _hidePos = _rectTransfrom.anchoredPosition;
        //_showPos = new Vector2(_hidePos.x - _rectTransfrom.rect.width, _hidePos.y);
        _showPos = new Vector2(_hidePosX, _hidePosY);

        _isShow = false;
    }

    public void showUI()
    {
        if (_isShow)
        {

            HideMenu();
            //UI_FadeOut_Event();
        }
        else
        {
            ShowMenu();
            //UI_FadeIn_Event();

        }
    }

    public void HideMenu()
    {
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

    public void ShowMenu()
    {
        StartCoroutine(Appear());
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
