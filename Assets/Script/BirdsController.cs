using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsController : MonoBehaviour
{
    private GameObject player;
    private float speed = 0.1f;         // 새가 날아가는 속도

    // 새 효과음들을 재생하기 위함
    private AudioSource audioSource;
    public AudioClip audioBird1;
    public AudioClip audioBird2;
    public AudioClip audioBird3;

    private int birdAudioCount = 0;     // 효과음을 교대로 재생하기 위한 카운트

    private void PlayBirdAudio()
    {
        // 카운트 초기화
        if (birdAudioCount >= 3)
        {
            birdAudioCount = 0;
        }

        // 카운트에 따라 다른 소리 등록
        switch (birdAudioCount)
        {
            // 첫 번째 새 소리 등록
            case 0:
                audioSource.clip = audioBird1;
                break;

            // 두 번째 새 소리 등록
            case 1:
                audioSource.clip = audioBird2;
                break;
                
            // 세 번째 새 소리 등록
            case 2:
                audioSource.clip = audioBird3;
                break;
        }
        
        // 새 효과음 재생
        audioSource.Play();
        
        // 카운트 증가
        birdAudioCount++;
    }

    private void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
        this.player = GameObject.Find("cat");

        // 0초부터 0.2초 간격으로 새 효과음 재생
        InvokeRepeating("PlayBirdAudio", 0f, 0.2f);
    }

    private void Update()
    {
        // speed 만큼 우측으로 등속 이동
        transform.Translate(speed, 0, 0);

        // 화면 밖으로 나가면 오브젝트를 소멸
        if (transform.position.x > 5.0f)
        {
            Destroy(gameObject);

            // 이벤트 진행 중임을 표시하는 플래그 내리기
            player.GetComponent<PlayerController>().SetIsActiveEvent(false);
        }
    }
}
