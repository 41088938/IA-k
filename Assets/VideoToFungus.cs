using UnityEngine;
using UnityEngine.Video;
using Fungus;

public class VideoToFungus : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // �v������
    public Flowchart flowchart;      // Fungus Flowchart

    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoFinished; // �]�w�v�������ƥ�
            videoPlayer.Play(); // �}�l����v��
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("�v�����񧹦��A�Ұ� Fungus Flowchart");

        if (flowchart != null)
        {
            flowchart.ExecuteBlock("StartFungus"); // ���� Fungus ���� Block
        }
    }
}
