public class TimeExecute : Execute
{
    public float[] times;

    public void SubscribeAll()
    {
        foreach (var time in times) Subscribe(time);
    }

    void Subscribe(float time)
    {
        TimeHandler.Get.AddEvent(() =>
        {
            Action();
        }, time, true);
    }
}
