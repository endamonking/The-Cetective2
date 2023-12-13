using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmManager : MonoBehaviour
{
    public static bgmManager Instance { get { return _instance; } }
    private static bgmManager _instance;

    public List<AudioClip> audioClips = new List<AudioClip>();
    private AudioSource audioSource;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //int index - index of audio clip in this context mean bgm 
    public void playBGM(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    // Pause the background music
    public void PauseBackgroundMusic()
    {
        audioSource.Pause();
    }

    // Resume playing the background music
    public void ResumeBackgroundMusic()
    {
        audioSource.UnPause();
    }

}
