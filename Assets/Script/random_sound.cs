using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

#if UNITY_UWP
using Windows.Storage;
using System.Threading.Tasks;
#endif


public class random_sound : MonoBehaviour
{
    /*********音源に使う音の変数****************/
    public AudioClip sound_on_iphone;
    public AudioClip sound_in_iphone;
    public AudioClip sound_under_iphone;
    public AudioClip sound_iphone;

    public AudioClip sound_on_cat;
    public AudioClip sound_in_cat;
    public AudioClip sound_under_cat;
    public AudioClip sound_cat;

    public AudioClip sound_on_mono;
    public AudioClip sound_in_mono;
    public AudioClip sound_under_mono;
    public AudioClip sound_mono;

    public AudioClip sound_bgm;
    public AudioClip none;

    /********オブジェクトの変数***********/
    GameObject SoundSource_iphone_on;
    GameObject SoundSource_iphone_in;
    GameObject SoundSource_iphone_under;

    GameObject SoundSource_cat_on;
    GameObject SoundSource_cat_in;
    GameObject SoundSource_cat_under;

    GameObject SoundSource_mono_on;
    GameObject SoundSource_mono_in;
    GameObject SoundSource_mono_under;


    GameObject SoundSource_bgm;
    GameObject ResultText;

    /***テキスト用*****/
    TextMesh scoreText;

    /*******時間計測の変数***********/
    private int starttime;
    private int now;
    private int duration;

    public int MeasureStart;
    public int MeasureStop;

    public int hour = 0;
    public int min = 0;
    public int sec = 0;
    public int msec = 0;

    int[] MeasureTime = new int[9];


    /************正誤用の変数************/
    int[] ans = new int[9];
    int[]  user_ans= new int[9];

    /******フラグ管理********/
    public int ObjFlag;
    public int TimeFlag = 0;
    public int PaternFlag = 0;

    public int cnt = 0;
    public int cnt_out = 0;
    public int cnt_task = 1;
    int tmp;



    void Start()
    {
        /******オブジェクトを代入**********/
        SoundSource_iphone_on = GameObject.Find("Sound_Iphone_On");
        SoundSource_iphone_in = GameObject.Find("Sound_Iphone_In");
        SoundSource_iphone_under = GameObject.Find("Sound_Iphone_Under");

        SoundSource_cat_on = GameObject.Find("Sound_Cat_On");
        SoundSource_cat_in = GameObject.Find("Sound_Cat_In");
        SoundSource_cat_under = GameObject.Find("Sound_Cat_Under");

        SoundSource_mono_on = GameObject.Find("Sound_Mono_On");
        SoundSource_mono_in = GameObject.Find("Sound_Mono_In");
        SoundSource_mono_under = GameObject.Find("Sound_Mono_Under");

        SoundSource_bgm = GameObject.Find("GameObject");
        ResultText = GameObject.Find("ResultText");

        /****オブジェクトを非表示にする****/
        Renderer Renderer_iphone_on = SoundSource_iphone_on.GetComponent<Renderer>();
        Renderer_iphone_on.enabled = false;
        Renderer Renderer_iphone_in = SoundSource_iphone_in.GetComponent<Renderer>();
        Renderer_iphone_in.enabled = false;
        Renderer Renderer_iphone_under = SoundSource_iphone_under.GetComponent<Renderer>();
        Renderer_iphone_under.enabled = false;

        Renderer Renderer_cat_on = SoundSource_cat_on.GetComponent<Renderer>();
        Renderer_cat_on.enabled = false;
        Renderer Renderer_cat_in = SoundSource_cat_in.GetComponent<Renderer>();
        Renderer_cat_in.enabled = false;
        Renderer Renderer_cat_under = SoundSource_cat_under.GetComponent<Renderer>();
        Renderer_cat_under.enabled = false;

        Renderer Renderer_mono_on = SoundSource_mono_on.GetComponent<Renderer>();
        Renderer_mono_on.enabled = false;
        Renderer Renderer_mono_in = SoundSource_mono_in.GetComponent<Renderer>();
        Renderer_mono_in.enabled = false;
        Renderer Renderer_mono_under = SoundSource_mono_under.GetComponent<Renderer>();
        Renderer_mono_under.enabled = false;

        /****時間計測＿起動時の値*****/
        starttime = DateTime.Now.Hour * 60 * 60 * 1000 + DateTime.Now.Minute * 60 * 1000 +
                    DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;

        Debug.Log(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" +
                  DateTime.Now.Second + ":" + DateTime.Now.Millisecond);
        /***テキスト設定****/
        scoreText = ResultText.gameObject.GetComponent<TextMesh>();
        scoreText.text = "Press Enter Key";//text描画
    }


    // Update is called once per frame
    void Update()
    {
        /***音源設定****/
        AudioSource audioSource_on = SoundSource_iphone_on.gameObject.GetComponent<AudioSource>();
        AudioSource audioSource_in = SoundSource_iphone_in.gameObject.GetComponent<AudioSource>();
        AudioSource audioSource_under = SoundSource_iphone_under.gameObject.GetComponent<AudioSource>();

        AudioSource audioSource_bgm = SoundSource_bgm.gameObject.GetComponent<AudioSource>();

        /***テキスト設定****/
        scoreText = ResultText.gameObject.GetComponent<TextMesh>();

        /****オブジェクト設定****/
        Renderer Renderer_iphone_on = SoundSource_iphone_on.GetComponent<Renderer>();
        Renderer Renderer_iphone_in = SoundSource_iphone_in.GetComponent<Renderer>();
        Renderer Renderer_iphone_under = SoundSource_iphone_under.GetComponent<Renderer>();

        Renderer Renderer_cat_on = SoundSource_cat_on.GetComponent<Renderer>();
        Renderer Renderer_cat_in = SoundSource_cat_in.GetComponent<Renderer>();
        Renderer Renderer_cat_under = SoundSource_cat_under.GetComponent<Renderer>();

        Renderer Renderer_mono_on = SoundSource_mono_on.GetComponent<Renderer>();
        Renderer Renderer_mono_in = SoundSource_mono_in.GetComponent<Renderer>();
        Renderer Renderer_mono_under = SoundSource_mono_under.GetComponent<Renderer>();

        /****時間計測：今の時間*****/
        now = DateTime.Now.Hour * 60 * 60 * 1000 + DateTime.Now.Minute * 60 * 1000 +
        DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;


        /******計測結果*******/
        duration = now - starttime;//計測時間(ミリ秒)

        hour = duration / 60 / 60 / 1000;//時間に直す
        duration = duration - hour * 60 * 60 * 1000;

        min = duration / 60 / 1000;//分に直す
        duration = duration - min * 60 * 1000;

        sec = duration / 1000;//秒に直す
        duration = duration - sec * 1000;

        msec = duration;//残ったミリ秒

        /*************キー入力*********************/

        if (Input.GetKey("a") && Input.GetKeyDown("1"))
        {
            PaternFlag = 1;//パターンA，変化あり
        }
        else if (Input.GetKey("b") && Input.GetKeyDown("1"))
        {
            PaternFlag = 2;//パターンB，変化あり
        }
        else if (Input.GetKey("a") && Input.GetKeyDown("2"))
        {
            PaternFlag = 3;//パターンA，変化なし
        }
        else if (Input.GetKey("b") && Input.GetKeyDown("2"))
        {
            PaternFlag = 4;//パターンB，変化なし
        }




        if (PaternFlag == 1 || PaternFlag == 2 || PaternFlag == 3 || PaternFlag == 4)
        {
            

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {

                if (TimeFlag == 0 && cnt < 9)
                {
                    MeasureStart = now - starttime;
                    TimeFlag = 1;
                    scoreText.text = null;

                    if(PaternFlag == 1)
                    {
                        switch (cnt + 1)
                        {
                            case 1://音：1　位置：1
                                ObjFlag = 1;
                                audioSource_on.clip = sound_on_iphone;
                                audioSource_on.Play();
                                Renderer_iphone_on.enabled = true;
                                break;
                            case 9://音：1　位置：2
                                ObjFlag = 2;
                                audioSource_in.clip = sound_in_iphone;
                                audioSource_in.Play();
                                Renderer_iphone_in.enabled = true;
                                break;
                            case 6://音：1　位置：3
                                ObjFlag = 3;
                                audioSource_under.clip = sound_under_iphone;
                                audioSource_under.Play();
                                Renderer_iphone_under.enabled = true;
                                break;
                            case 5://音：2　位置：1
                                ObjFlag = 1;
                                audioSource_on.clip = sound_on_cat;
                                audioSource_on.Play();
                                Renderer_cat_on.enabled = true;
                                break;
                            case 2://音：2　位置：2
                                ObjFlag = 2;
                                audioSource_in.clip = sound_in_cat;
                                audioSource_in.Play();
                                Renderer_cat_in.enabled = true;
                                break;
                            case 7://音：2　位置：3
                                ObjFlag = 3;
                                audioSource_under.clip = sound_under_cat;
                                audioSource_under.Play();
                                Renderer_cat_under.enabled = true;
                                break;
                            case 8://音：3　位置：1
                                ObjFlag = 1;
                                audioSource_on.clip = sound_on_mono;
                                audioSource_on.Play();
                                Renderer_mono_on.enabled = true;
                                break;
                            case 4://音：3　位置：2
                                ObjFlag = 2;
                                audioSource_in.clip = sound_in_mono;
                                audioSource_in.Play();
                                Renderer_mono_in.enabled = true;
                                break;
                            case 3://音：3　位置：3
                                ObjFlag = 3;
                                audioSource_under.clip = sound_under_mono;
                                audioSource_under.Play();
                                Renderer_mono_under.enabled = true;
                                break;
                            default:
                                ObjFlag = 0;
                                break;
                        }
                    }

                    if (PaternFlag == 2)
                    {
                        switch (cnt + 1)
                        {
                            case 9://音：1　位置：1
                                ObjFlag = 1;
                                audioSource_on.clip = sound_on_iphone;
                                audioSource_on.Play();
                                Renderer_iphone_on.enabled = true;
                                break;
                            case 1://音：1　位置：2
                                ObjFlag = 2;
                                audioSource_in.clip = sound_in_iphone;
                                audioSource_in.Play();
                                Renderer_iphone_in.enabled = true;
                                break;
                            case 4://音：1　位置：3
                                ObjFlag = 3;
                                audioSource_under.clip = sound_under_iphone;
                                audioSource_under.Play();
                                Renderer_iphone_under.enabled = true;
                                break;
                            case 5://音：2　位置：1
                                ObjFlag = 1;
                                audioSource_on.clip = sound_on_cat;
                                audioSource_on.Play();
                                Renderer_cat_on.enabled = true;
                                break;
                            case 8://音：2　位置：2
                                ObjFlag = 2;
                                audioSource_in.clip = sound_in_cat;
                                audioSource_in.Play();
                                Renderer_cat_in.enabled = true;
                                break;
                            case 3://音：2　位置：3
                                ObjFlag = 3;
                                audioSource_under.clip = sound_under_cat;
                                audioSource_under.Play();
                                Renderer_cat_under.enabled = true;
                                break;
                            case 2://音：3　位置：1
                                ObjFlag = 1;
                                audioSource_on.clip = sound_on_mono;
                                audioSource_on.Play();
                                Renderer_mono_on.enabled = true;
                                break;
                            case 6://音：3　位置：2
                                ObjFlag = 2;
                                audioSource_in.clip = sound_in_mono;
                                audioSource_in.Play();
                                Renderer_mono_in.enabled = true;
                                break;
                            case 7://音：3　位置：3
                                ObjFlag = 3;
                                audioSource_under.clip = sound_under_mono;
                                audioSource_under.Play();
                                Renderer_mono_under.enabled = true;
                                break;
                            default:
                                ObjFlag = 0;
                                break;
                        }
                    }

                    if (PaternFlag == 3)
                    {
                        switch (cnt + 1)
                        {
                            case 1://音：1　位置：1
                                ObjFlag = 1;
                                audioSource_on.clip = sound_iphone;
                                audioSource_on.Play();
                                Renderer_iphone_on.enabled = true;
                                break;
                            case 9://音：1　位置：2
                                ObjFlag = 2;
                                audioSource_in.clip = sound_iphone;
                                audioSource_in.Play();
                                Renderer_iphone_in.enabled = true;
                                break;
                            case 6://音：1　位置：3
                                ObjFlag = 3;
                                audioSource_under.clip = sound_iphone;
                                audioSource_under.Play();
                                Renderer_iphone_under.enabled = true;
                                break;
                            case 5://音：2　位置：1
                                ObjFlag = 1;
                                audioSource_on.clip = sound_cat;
                                audioSource_on.Play();
                                Renderer_cat_on.enabled = true;
                                break;
                            case 2://音：2　位置：2
                                ObjFlag = 2;
                                audioSource_in.clip = sound_cat;
                                audioSource_in.Play();
                                Renderer_cat_in.enabled = true;
                                break;
                            case 7://音：2　位置：3
                                ObjFlag = 3;
                                audioSource_under.clip = sound_cat;
                                audioSource_under.Play();
                                Renderer_cat_under.enabled = true;
                                break;
                            case 8://音：3　位置：1
                                ObjFlag = 1;
                                audioSource_on.clip = sound_mono;
                                audioSource_on.Play();
                                Renderer_mono_on.enabled = true;
                                break;
                            case 4://音：3　位置：2
                                ObjFlag = 2;
                                audioSource_in.clip = sound_mono;
                                audioSource_in.Play();
                                Renderer_mono_in.enabled = true;
                                break;
                            case 3://音：3　位置：3
                                ObjFlag = 3;
                                audioSource_under.clip = sound_mono;
                                audioSource_under.Play();
                                Renderer_mono_under.enabled = true;
                                break;
                            default:
                                ObjFlag = 0;
                                break;
                        }
                    }

                    if (PaternFlag == 4)
                    {
                        switch (cnt + 1)
                        {
                            case 9://音：1　位置：1
                                ObjFlag = 1;
                                audioSource_on.clip = sound_iphone;
                                audioSource_on.Play();
                                Renderer_iphone_on.enabled = true;
                                break;
                            case 1://音：1　位置：2
                                ObjFlag = 2;
                                audioSource_in.clip = sound_iphone;
                                audioSource_in.Play();
                                Renderer_iphone_in.enabled = true;
                                break;
                            case 4://音：1　位置：3
                                ObjFlag = 3;
                                audioSource_under.clip = sound_iphone;
                                audioSource_under.Play();
                                Renderer_iphone_under.enabled = true;
                                break;
                            case 5://音：2　位置：1
                                ObjFlag = 1;
                                audioSource_on.clip = sound_cat;
                                audioSource_on.Play();
                                Renderer_cat_on.enabled = true;
                                break;
                            case 8://音：2　位置：2
                                ObjFlag = 2;
                                audioSource_in.clip = sound_cat;
                                audioSource_in.Play();
                                Renderer_cat_in.enabled = true;
                                break;
                            case 3://音：2　位置：3
                                ObjFlag = 3;
                                audioSource_under.clip = sound_cat;
                                audioSource_under.Play();
                                Renderer_cat_under.enabled = true;
                                break;
                            case 2://音：3　位置：1
                                ObjFlag = 1;
                                audioSource_on.clip = sound_mono;
                                audioSource_on.Play();
                                Renderer_mono_on.enabled = true;
                                break;
                            case 6://音：3　位置：2
                                ObjFlag = 2;
                                audioSource_in.clip = sound_mono;
                                audioSource_in.Play();
                                Renderer_mono_in.enabled = true;
                                break;
                            case 7://音：3　位置：3
                                ObjFlag = 3;
                                audioSource_under.clip = sound_mono;
                                audioSource_under.Play();
                                Renderer_mono_under.enabled = true;
                                break;
                            default:
                                ObjFlag = 0;
                                break;
                        }
                    }
                    

                }

            }



            //ユーザの答え(上)
            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                if (TimeFlag == 1)
                {
                    TimeFlag = 0;


                    MeasureStop = now - starttime;//計測終了
                    MeasureTime[cnt] = MeasureStop - MeasureStart;//計測結果（ミリ秒）


                    if (ObjFlag == 1)
                    {
                        //scoreText.text = "〇";
                        ans[cnt] = 1;
                    }
                    if (ObjFlag == 2)
                    {
                        //scoreText.text = "×";
                        ans[cnt] = 0;
                    }
                    if (ObjFlag == 3)
                    {
                        //scoreText.text = "×";
                        ans[cnt] = 0;
                    }

                    user_ans[cnt] = 1;

                    scoreText.text = "Press Enter Key";
                    ObjFlag = 0;

                    audioSource_on.clip = none;
                    audioSource_on.Play();
                    audioSource_in.clip = none;
                    audioSource_in.Play();
                    audioSource_under.clip = none;
                    audioSource_under.Play();
                    audioSource_bgm.clip = none;
                    audioSource_bgm.Play();

                    Renderer_iphone_on.enabled = false;
                    Renderer_iphone_in.enabled = false;
                    Renderer_iphone_under.enabled = false;

                    Renderer_cat_on.enabled = false;
                    Renderer_cat_in.enabled = false;
                    Renderer_cat_under.enabled = false;

                    Renderer_mono_on.enabled = false;
                    Renderer_mono_in.enabled = false;
                    Renderer_mono_under.enabled = false;

                    cnt++;


                }
            }

            //ユーザの答え(中)
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                if (TimeFlag == 1)
                {
                    TimeFlag = 0;


                    MeasureStop = now - starttime;//計測終了
                    MeasureTime[cnt] = MeasureStop - MeasureStart;//計測結果（ミリ秒）


                    if (ObjFlag == 1)
                    {
                        //scoreText.text = "×";
                        ans[cnt] = 0;
                    }
                    if (ObjFlag == 2)
                    {
                        //scoreText.text = "〇";
                        ans[cnt] = 1;
                    }
                    if (ObjFlag == 3)
                    {
                        //scoreText.text = "×";
                        ans[cnt] = 0;
                    }

                    user_ans[cnt] = 2;

                    scoreText.text = "Press Enter Key";
                    ObjFlag = 0;


                    audioSource_on.clip = none;
                    audioSource_on.Play();
                    audioSource_in.clip = none;
                    audioSource_in.Play();
                    audioSource_under.clip = none;
                    audioSource_under.Play();
                    audioSource_bgm.clip = none;
                    audioSource_bgm.Play();

                    Renderer_iphone_on.enabled = false;
                    Renderer_iphone_in.enabled = false;
                    Renderer_iphone_under.enabled = false;

                    Renderer_cat_on.enabled = false;
                    Renderer_cat_in.enabled = false;
                    Renderer_cat_under.enabled = false;

                    Renderer_mono_on.enabled = false;
                    Renderer_mono_in.enabled = false;
                    Renderer_mono_under.enabled = false;

                    cnt++;


                }
            }


            //ユーザの答え(下)
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                if (TimeFlag == 1)
                {
                    TimeFlag = 0;


                    MeasureStop = now - starttime;//計測終了
                    MeasureTime[cnt] = MeasureStop - MeasureStart;//計測結果（ミリ秒）



                    if (ObjFlag == 1)
                    {
                        //scoreText.text = "×";
                        ans[cnt] = 0;
                    }
                    if (ObjFlag == 2)
                    {
                        //scoreText.text = "×";
                        ans[cnt] = 0;
                    }
                    if (ObjFlag == 3)
                    {
                        //scoreText.text = "〇";
                        ans[cnt] = 1;
                    }

                    user_ans[cnt] = 3;

                    scoreText.text = "Press Enter Key";
                    ObjFlag = 0;


                    audioSource_on.clip = none;
                    audioSource_on.Play();
                    audioSource_in.clip = none;
                    audioSource_in.Play();
                    audioSource_under.clip = none;
                    audioSource_under.Play();
                    audioSource_bgm.clip = none;
                    audioSource_bgm.Play();

                    Renderer_iphone_on.enabled = false;
                    Renderer_iphone_in.enabled = false;
                    Renderer_iphone_under.enabled = false;

                    Renderer_cat_on.enabled = false;
                    Renderer_cat_in.enabled = false;
                    Renderer_cat_under.enabled = false;

                    Renderer_mono_on.enabled = false;
                    Renderer_mono_in.enabled = false;
                    Renderer_mono_under.enabled = false;

                    cnt++;


                }
            }





            //9回処理を終えた際，計測時間をtxtに書き出し
            if (cnt == 9)
            {
                cnt = 10;
                scoreText.text = "Thank you";

                /********HoloLens用のファイル出力************/
#if UNITY_UWP
        Task.Run(async ()=>
        {

            

            // ローカルフォルダー
            // 「User Files\LocalAppData\<アプリ名>\LocalState」 以下にできる
            {
                var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("DocumentLibraryTest", CreationCollisionOption.OpenIfExists);
                var file = await folder.CreateFileAsync("test" + cnt_task + ".csv", CreationCollisionOption.ReplaceExisting);

                using (var stream = await file.OpenStreamForWriteAsync())
                {
                    for(cnt_out=0; cnt_out<9; cnt_out++){
                        tmp = MeasureTime[cnt_out];

                        hour = tmp / 60 / 60 / 1000;//時間に直す
                        tmp = tmp - hour * 60 * 60 * 1000;

                        min = tmp / 60 / 1000;//分に直す
                        tmp = tmp - min * 60 * 1000;

                        sec = tmp / 1000;//秒に直す
                        tmp = tmp - sec * 1000;

                        msec = tmp;//残ったミリ秒

                        var bytes = System.Text.Encoding.UTF8.GetBytes(@hour + "," + min + "," + sec + "," + msec + "," + ans[cnt_out] + "," + user_ans[cnt_out] +"\n");
                        await stream.WriteAsync(bytes, 0, bytes.Length);
                    }
                }
            }

           
        });
#endif

            }


            if (Input.GetKeyDown(KeyCode.Home) )//&& cnt == 10)
            {
                cnt = 0;
                TimeFlag = 0;
                PaternFlag = 0;
                scoreText.text = "Press Enter Key";
                cnt_task++;

                audioSource_on.clip = none;
                audioSource_on.Play();
                audioSource_in.clip = none;
                audioSource_in.Play();
                audioSource_under.clip = none;
                audioSource_under.Play();
                audioSource_bgm.clip = none;
                audioSource_bgm.Play();

                Renderer_iphone_on.enabled = false;
                Renderer_iphone_in.enabled = false;
                Renderer_iphone_under.enabled = false;

                Renderer_cat_on.enabled = false;
                Renderer_cat_in.enabled = false;
                Renderer_cat_under.enabled = false;

                Renderer_mono_on.enabled = false;
                Renderer_mono_in.enabled = false;
                Renderer_mono_under.enabled = false;

            }

        }

    }

}
