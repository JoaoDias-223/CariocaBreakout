using System.Threading;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFPS : MonoBehaviour
{
    private int FramesPerSec;
    private float frequency = 1.0f;
    private string fps;
    public GameObject textLabel;


    Thread ChildThread = null;
    EventWaitHandle ChildThreadWait = new EventWaitHandle(true, EventResetMode.ManualReset);
    EventWaitHandle MainThreadWait = new EventWaitHandle(true, EventResetMode.ManualReset);


    void ChildThreadLoop()
    {
        ChildThreadWait.Reset();
        ChildThreadWait.WaitOne();

        while(true)
        {
            ChildThreadWait.Reset();
            FPS();
            WaitHandle.SignalAndWait(MainThreadWait, ChildThreadWait);
        }
    }

    private void FPS()
    {
        int lastFrameCount = Time.frameCount;
        float lastTime = Time.realtimeSinceStartup;
        float timeSpan = Time.realtimeSinceStartup - lastTime;
        int frameCount = Time.frameCount - lastFrameCount;
        
        // Display it
        fps = string.Format("FPS: {0}" , Mathf.RoundToInt(frameCount / timeSpan));
        textLabel.GetComponent<TMPro.TMP_Text>().text = fps;
    }

    private void Awake() {
        ChildThread = new Thread(ChildThreadLoop);
        ChildThread.Start();
    }

    private void Update() {
        MainThreadWait.WaitOne();
        MainThreadWait.Reset();
        
        ChildThreadWait.Set();
    }
}