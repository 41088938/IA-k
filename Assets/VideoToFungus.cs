using UnityEngine;
using UnityEngine.Video;
using Fungus;

public class VideoToFungus : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // 影片播放器
    public Flowchart flowchart;      // Fungus Flowchart

    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoFinished; // 設定影片結束事件
            videoPlayer.Play(); // 開始播放影片
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("影片播放完成，啟動 Fungus Flowchart");

        if (flowchart != null)
        {
            flowchart.ExecuteBlock("StartFungus"); // 執行 Fungus 中的 Block
        }
    }
}
