using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudioController : MonoBehaviour
{
    void Start()
    {
        // 다른 씬으로 전환되어도 오디오 오브젝트가 사라지지 않게 함
        // 배경 음악이 이어서 재생될 수 있도록 함
        DontDestroyOnLoad(transform.gameObject);
    }
}
