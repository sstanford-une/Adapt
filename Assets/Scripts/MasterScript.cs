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
    }

    public void PlayerChoice(int choice)
    {
        if (choice == 1)
        {
            this.FadeIn(Image1Array[ProgressCount], 1);
            this.ProgressStory();
        }
        else if (choice == 2)
        {
            this.FadeIn(Image2Array[ProgressCount], 1);
            this.ProgressStory();
        }
        else if (choice == 3)
        {
            this.FadeIn(Image3Array[ProgressCount], 1);
            this.ProgressStory();
        }
        else
        {
            Debug.LogError("Player Choice error");
        }
    }

    public void ProgressStory()
    {
        Debug.Log($"Progressing Story... {this.ProgressCount}");

        this.FadeOut(QuestionArray[ProgressCount], 1);
        this.FadeOut(Answer1Array[ProgressCount], 1);
        this.FadeOut(Answer2Array[ProgressCount], 1);
        this.FadeOut(Answer3Array[ProgressCount], 1);

        this.ProgressCount += 1;

        var timeable = this.gameObject.AddComponent<Timeable>();

        timeable.OnFinish += () =>
        {
            this.FadeIn(QuestionArray[ProgressCount], 1);
            this.FadeIn(Answer1Array[ProgressCount], 1);
            this.FadeIn(Answer2Array[ProgressCount], 1);
            this.FadeIn(Answer3Array[ProgressCount], 1);

            MonoBehaviour.Destroy(timeable);
        };

        timeable.Fade(100, 0, 5);
    }

    void FadeOut(GameObject go, int delay)
    {
        this.Fade(go, 1, 0, delay);
    }

    void FadeIn(GameObject go, int delay)
    {
        this.Fade(go, 0, 1, delay);
    }

    void Fade(GameObject go, float start, float end, float delay)
    {
        var image = go.GetComponent<Image>();
        var spriteRenderer = go.GetComponent<SpriteRenderer>();
        var timeable = go.AddComponent<Timeable>();

        timeable.Fade(start, end, delay);

        timeable.OnChange += amount =>
        {
            if (image != null)
            {
                image.color = new Color(255, 255, 255, amount);

                Debug.Log(image.color);
            }
            else
            {
                spriteRenderer.color = new Color(255, 255, 255, amount);

                Debug.Log(spriteRenderer.color);
            }
        };

        timeable.OnFinish += () =>
        {
            MonoBehaviour.Destroy(timeable);
        };
    }

}
