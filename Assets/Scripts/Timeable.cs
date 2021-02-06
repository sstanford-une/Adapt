using UnityEngine;

public class Timeable : MonoBehaviour
{
    public delegate void OnChangeEvent(float amount);

    public event OnChangeEvent OnChange;

    public delegate void OnFinishEvent();

    public event OnFinishEvent OnFinish;

    private float value = 0;
    private float start = 0;
    private float end = 0;
    private float delay = 1;
    private float delta = 0;
    private bool isIncrement = true;

    public void Fade(float start, float end, float delay)
    {
        this.value = start;
        this.start = start;
        this.end = end;
        this.delay = delay;
        this.isIncrement = this.start < this.end;
        this.delta = Mathf.Abs(this.start - this.end);
    }

    public void Update()
    {
        if (this.isIncrement)
        {
            if (this.value < this.end)
            {
                var change = Time.deltaTime / this.delay * this.delta;

                this.value = Mathf.Clamp(
                    value + change,
                    this.isIncrement ? this.start : this.end,
                    this.isIncrement ? this.end : this.start
                );

                Debug.Log($"value: {this.value}");

                this.OnChange.Invoke(this.value);
            }
            else
            {
                this.OnFinish.Invoke();
            }
        }
        else
        {
            if (this.value > this.end)
            {
                var change = Time.deltaTime / this.delay * this.delta;

                this.value = Mathf.Clamp(
                    value - change,
                    this.isIncrement ? this.start : this.end,
                    this.isIncrement ? this.end : this.start
                );

                Debug.Log($"value: {this.value}");

                this.OnChange.Invoke(this.value);
            }
            else
            {
                this.OnFinish.Invoke();
            }
        }
    }
}
