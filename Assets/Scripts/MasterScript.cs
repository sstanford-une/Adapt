using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterScript : MonoBehaviour
{
    public GameObject[] Image1Array;
    public GameObject[] Image2Array;
    public GameObject[] Image3Array;
    public GameObject[] QuestionArray;
    public GameObject[] Answer1Array;
    public GameObject[] Answer2Array;
    public GameObject[] Answer3Array;
    public float FadeSpeed = 0.003f;
    float FadeAmount;
    GameObject TargetImage;
    GameObject TargetQuestion;
    public int ChoiceTarget;
    int ProgressCount;
    bool CoStop;
    Color TargetColor;

    // Start is called before the first frame update
    void Start()
    {
        ProgressCount = 0;
        CoStop = true;
    }

    // Update is called once per frame
    void Update()
    {
        FadeCheck();
    }

    IEnumerator ImageFadeIn()
    {
        FadeAmount = 0;

        while (FadeAmount < 1)
        {
            for (int i = 0; i < 255; i++)
            {
                TargetColor = new Color(255, 255, 255, (255 * FadeAmount));
            }
        }

        if (FadeAmount == 1)
        {
            yield return new WaitForSeconds(5);
            yield return CoStop = true;
        }
    }

    IEnumerator ImageFadeOut()
    {
        FadeAmount = 1;

        while(FadeAmount > 0)
        {
            for (int i = 0; i < 255; i--)
            {
                TargetColor = new Color(255, 255, 255, (255 * FadeAmount));
            }
        }

        if (FadeAmount == 0)
        {
            yield return new WaitForSeconds(5);
            yield return CoStop = true;
        }
    }

    IEnumerator TextFadeIn()
    {
        Color QuestionColor = QuestionArray[ProgressCount].GetComponent<Image>().color; 
        Color Answer1Color = Answer1Array[ProgressCount].GetComponent<Image>().color;
        Color Answer2Color = Answer2Array[ProgressCount].GetComponent<Image>().color;
        Color Answer3Color = Answer3Array[ProgressCount].GetComponent<Image>().color;

        while (FadeAmount < 1)
        {
            for (int i = 0; i < 255; i++)
            {
                QuestionColor = new Color(255, 255, 255, (255 * FadeAmount));
                Answer1Color = new Color(255, 255, 255, (255 * FadeAmount));
                Answer2Color = new Color(255, 255, 255, (255 * FadeAmount));
                Answer3Color = new Color(255, 255, 255, (255 * FadeAmount));
            }
        }

        if (FadeAmount == 1)
        {
            yield return new WaitForSeconds(5);
            yield return CoStop = true;
        }
    }

    IEnumerator TextFadeOut()
    {
        float FadeAmount = 1;
        Debug.Log("Begin Text Fade");
        Image TargetQuestion = QuestionArray[ProgressCount].GetComponent<Image>();
        //Color QuestionColor = QuestionArray[ProgressCount].GetComponent<Image>().color;
        //Color Answer1Color = Answer1Array[ProgressCount].GetComponent<Image>().color;
        //Color Answer2Color = Answer2Array[ProgressCount].GetComponent<Image>().color;
        //Color Answer3Color = Answer3Array[ProgressCount].GetComponent<Image>().color;

        while (FadeAmount > 0)
        {
            for (int i = 0; i < 255; i++)
            {
                TargetQuestion.color  = new Color(255, 255, 255, (i));
                //Answer1Color = new Color(255, 255, 255, (255 * FadeAmount));
                //Answer2Color = new Color(255, 255, 255, (255 * FadeAmount));
                //Answer3Color = new Color(255, 255, 255, (255 * FadeAmount));
                FadeAmount = (i / 255f);
                Debug.Log("Fading..."+ FadeAmount);
            }
        }

        if (FadeAmount == 0)
        {
            Debug.Log("Stopping FadeOut");
            yield return new WaitForSeconds(5);
            yield return CoStop = true;
        }
    }

    void FadeCheck()
    {
        if(CoStop == true)
        {
            StopAllCoroutines();
            CoStop = false;
        } 
    }

    public void PlayerChoice()
    {
        if (ChoiceTarget == 1)
        {
            TargetColor = Image1Array[ProgressCount].GetComponent<Image>().color;
        }
        else if (ChoiceTarget == 2)
        {
            TargetColor = Image2Array[ProgressCount].GetComponent<Image>().color;
        }
        else if (ChoiceTarget ==3)
        {
            TargetColor = Image3Array[ProgressCount].GetComponent<Image>().color;
        }
        else
        {
            Debug.Log("Player Choice error");
        }
    }

    public void ProgressStory()
    {
        Debug.Log("Progressing Story...");
        StartCoroutine("TextFadeOut");
        //Deactivate previous question & Answers
        //Progress += 1
        //Fade in image layer
        //fade in music
        //wait a few seconds
        //activate next question & Answers
        //fade in next question & Answers
    }


}
