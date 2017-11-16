using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public static TextController highlander;

    Queue<IEnumerator> queue = new Queue<IEnumerator>();
    public Text text;
    public GameObject textBox;
    public GameObject pressAImage;
    public float textSpeed = 0.1f;

    void Awake()
    {
        if (highlander == null)
        {
            highlander = this;
            pressAImage.gameObject.SetActive(false);
            text.text = "";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        StartCoroutine("ProcessQueue");
    }

    void Start ()
    {
        
        //TextController.ShowText("This is some instant text! ");
        //TextController.TypeText("\nText Box: Hello I Am A Text Box! :D");
        //TextController.WaitForInput();
        //TextController.ClearText();
        //TextController.TypeText("You waited for a couple of seconds. Cool Beans!");
        //TextController.WaitForInput();
    }

    IEnumerator ProcessQueue ()
    {
        while (enabled)
        {
            if (queue.Count > 0)
            {
                textBox.SetActive(true);
                while (queue.Count > 0)
                {
                    yield return StartCoroutine(queue.Dequeue());
                }
                textBox.SetActive(false);
            }
            yield return new WaitForEndOfFrame();
        }
    }
    // Show and Hide functions below are not required;
    public static void Show()
    {
        highlander.queue.Enqueue(highlander.ShowHide(true));
    }

    public static void Hide()
    {
        highlander.queue.Enqueue(highlander.ShowHide(false));
    }

    IEnumerator ShowHide(bool show)
    {
        textBox.SetActive(show);
        yield return new WaitForSeconds(0.5f);
    }

    public static void ClearText()
    {
        highlander.queue.Enqueue(highlander.ClearTextCoroutine());
    }

    IEnumerator ClearTextCoroutine()
    {
        text.text = "";
        yield return null;
    }

    public static void TypeText(string str)
    {
        highlander.queue.Enqueue(highlander.TypeTextCoroutine(str));
    }

    IEnumerator TypeTextCoroutine(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            this.text.text += text[i];
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public static void ShowText(string str)
    {
        highlander.queue.Enqueue(highlander.ShowTextCoroutine(str));
    }

    IEnumerator ShowTextCoroutine(string str)
    {
        text.text += str;
        yield return new WaitForSeconds(0.1f);
    }

    public static void WaitForInput ()
    {
        highlander.queue.Enqueue(highlander.WaitForInputCoroutine());
    }

    IEnumerator WaitForInputCoroutine ()
    {
        aPressed = false;
        pressAImage.gameObject.SetActive(true);
        while (!aPressed)
        {
            yield return new WaitForEndOfFrame();
        }
        pressAImage.gameObject.SetActive(false);
    }

    bool aPressed = false;
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) aPressed = true;
    }

}
