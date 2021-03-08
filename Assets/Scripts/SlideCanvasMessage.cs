using System.Collections;
using UnityEngine;

class SlideCanvasMessage : MonoBehaviour, IMessage
{
    [SerializeField] GameObject winMessage;
    [SerializeField] GameObject loseMessage;
    [SerializeField, Range(0f, 50f)] float speed;

    public void Show(Message name)
    {
        var message = name == Message.Win ? winMessage : loseMessage;
        var transform = message.GetComponent<RectTransform>();
        StartCoroutine(AnimationCoroutine(transform));
    }


    IEnumerator AnimationCoroutine(RectTransform transform)
    {
        while (transform.anchoredPosition.x != 0)
        {
            if (transform.anchoredPosition.x > 0) 
                transform.anchoredPosition = new Vector2(Mathf.MoveTowards(transform.anchoredPosition.x, 0, speed), 0);
            else 
                transform.anchoredPosition = new Vector2(Mathf.MoveTowards(transform.anchoredPosition.x, 0, speed), 0);
            yield return new WaitForFixedUpdate();
        }
    }
}