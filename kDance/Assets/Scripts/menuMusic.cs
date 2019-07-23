using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMusic : MonoBehaviour
{

    public AudioSource audioSourceMenu;
    public AudioClip songName1;
    public AudioClip songName2;
    public AudioClip songName3;
    public AudioClip songName4;
    public AudioClip songName5;
    public AudioClip songName6;
    public AudioClip songName7;
    public AudioClip songName8;
    public AudioClip songName9;
    public AudioClip songName10;
    public AudioClip songName11;
    public AudioClip songName12;
    public AudioClip songName13;
    public AudioClip songName14;
    public AudioClip songName15;
    public AudioClip songName16;
    public AudioClip songName17;
    public AudioClip songName18;
    //public AudioClip songName19;
    //public AudioClip songName20;
    //public AudioClip songName21;
    //public AudioClip songName22;
    //public AudioClip songName23;
    //public AudioClip songName24;
    //public AudioClip songName25;
    //public AudioClip songName26;
    //public AudioClip songName27;
    //public AudioClip songName28;
    //public AudioClip songName29;
    //public AudioClip songName30;
    //public AudioClip songName31;
    //public AudioClip songName32;
    //public AudioClip songName33;
    //public AudioClip songName34;
    //public AudioClip songName35;
    //public AudioClip songName36;
    //public AudioClip songName37;
    //public AudioClip songName38;
    //public AudioClip songName39;
    //public AudioClip songName40;
    //public AudioClip songName41;
    //public AudioClip songName42;
    //public AudioClip songName43;
    //public AudioClip songName44;
    //public AudioClip songName45;
    //public AudioClip songName46;
    //public AudioClip songName47;
    //public AudioClip songName48;
    //public AudioClip songName49;
    //public AudioClip songName50;
    //public AudioClip songName51;
    //public AudioClip songName52;
    //public AudioClip songName53;
    //public AudioClip songName54;
    //public AudioClip songName55;
    //public AudioClip songName56;
    //public AudioClip songName57;
    //public AudioClip songName58;
    //public AudioClip songName59;

    private AudioClip[] musicList = new AudioClip[18];

    // Start is called before the first frame update
    void Start()
    {
        int width = 1920; // or something else
        int height = 1080; // or something else
        bool isFullScreen = false; // should be windowed to run in arbitrary resolution
        int desiredFPS = 60; // or something else
        Screen.SetResolution(width, height, isFullScreen, desiredFPS);

        musicList[0] = songName1;
        musicList[1] = songName2;
        musicList[2] = songName3;
        musicList[3] = songName4;
        musicList[4] = songName5;
        musicList[5] = songName6;
        musicList[6] = songName7;
        musicList[7] = songName8;
        musicList[8] = songName9;
        musicList[9] = songName10;
        musicList[10] = songName11;
        musicList[11] = songName12;
        musicList[12] = songName13;
        musicList[13] = songName14;
        musicList[14] = songName15;
        musicList[15] = songName16;
        musicList[16] = songName17;
        musicList[17] = songName18;
        //musicList[18] = songName19;
        //musicList[19] = songName20;
        //musicList[20] = songName21;
        //musicList[21] = songName22;
        //musicList[22] = songName23;
        //musicList[23] = songName24;
        //musicList[24] = songName25;
        //musicList[25] = songName26;
        //musicList[26] = songName27;
        //musicList[27] = songName28;
        //musicList[28] = songName29;
        //musicList[29] = songName30;
        //musicList[30] = songName31;
        //musicList[31] = songName32;
        //musicList[32] = songName33;
        //musicList[33] = songName34;
        //musicList[34] = songName35;
        //musicList[35] = songName36;
        //musicList[36] = songName37;
        //musicList[37] = songName38;
        //musicList[38] = songName39;
        //musicList[39] = songName40;
        //musicList[40] = songName41;
        //musicList[41] = songName42;
        //musicList[42] = songName43;
        //musicList[43] = songName44;
        //musicList[44] = songName45;
        //musicList[45] = songName46;
        //musicList[46] = songName47;
        //musicList[47] = songName48;
        //musicList[48] = songName49;
        //musicList[49] = songName50;
        //musicList[50] = songName51;
        //musicList[51] = songName52;
        //musicList[52] = songName53;
        //musicList[53] = songName54;
        //musicList[54] = songName55;
        //musicList[55] = songName56;
        //musicList[56] = songName57;
        //musicList[57] = songName58;
        //musicList[58] = songName59;

        audioSourceMenu.clip = musicList[Random.Range(0, musicList.Length)];

        audioSourceMenu.loop = true;
        audioSourceMenu.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
