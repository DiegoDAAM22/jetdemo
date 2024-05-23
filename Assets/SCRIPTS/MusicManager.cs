using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource AS;
    public AudioClip[] songs;
    public float volume;
    [SerializeField] private float trackTimer;
    [SerializeField] private float songplayed;
    [SerializeField] private bool[] songplaying;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        songplaying = new bool[songs.Length];
    }

    // Update is called once per frame
    void Update()
    {
        AS.volume = volume;

        if (AS.isPlaying)
            trackTimer += 1 * Time.deltaTime;
        if (!AS.isPlaying || trackTimer >= AS.clip.length)
            ChangeSong(Random.Range(0, songs.Length));

        if (songplayed == songs.Length)
        {
            songplayed = 0;
            for (int i = 0; i < songs.Length; i++)
            {
                if (i == songs.Length)
                    break;
                else
                    songplaying[i] = true;
            }
        }
    }
    public void ChangeSong(int songPicked)
    {
        trackTimer = 0;
        AS.clip = songs[songPicked];
        AS.Play();
        if (!songplaying[songPicked])
        {
            songplayed++;
            songplaying[songPicked] = true;
        }
        else
            AS.Stop();
    }
}
