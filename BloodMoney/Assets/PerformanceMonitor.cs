using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Profiling;

public class PerformanceMonitor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI fpsLabel, memoryLabel;

    [SerializeField]
    private GameObject performanceGO;


    float deltaTime = 0.0f;
    void Start()
    {
        Application.targetFrameRate = -1;

        QualitySettings.vSyncCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(performanceGO.activeSelf == true)
        {
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

            UpdateFps();
            UpdateMemory();
        }

    }
    void UpdateFps()
    {
        float fps = 1.0f / deltaTime;

        fpsLabel.text = $"FPS {fps:F2}"; 
    }
    void UpdateMemory()
    {
        float allocatedMemory = Profiler.GetTotalAllocatedMemoryLong() / (1024f * 1024f);

        memoryLabel.text = $"Memory usage {allocatedMemory:F2}";
    }

}
