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


public class viewer : MonoBehaviour
{
    /*********音源に使う音の変数****************/
    public AudioClip sound_on_iphone;
    public AudioClip sound_in_iphone;
    public AudioClip sound_under_iphone;

    public AudioClip sound_on_cat;
    public AudioClip sound_in_cat;
    public AudioClip sound_under_cat;

    public AudioClip sound_on_mono;
    public AudioClip sound_in_mono;
    public AudioClip sound_under_mono;

    public AudioClip sound_bgm;
    public AudioClip none;

    /********オブジェクトの変数***********/
    GameObject SoundSource_on;
    GameObject SoundSource_in;
    GameObject SoundSource_under;
    GameObject SoundSource_bgm;
    GameObject ResultText;

    GameObject Sphere_0;
    GameObject Sphere_1;
    GameObject Sphere_2;
    GameObject Sphere_3;
    GameObject Sphere_4;
    GameObject Sphere_5;
    GameObject Sphere_6;

    /***テキスト用*****/
    int[] ans = new int[9];
    string title = "Press Space Key";

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

    /******フラグ管理********/
    public int ObjFlag;
    public int TimeFlag = 0;

    public int cnt = 0;
    public int cnt_out = 0;
    public int cnt_task = 1;
    int tmp;



    void Start()
    {
        /******オブジェクトを代入**********/
        SoundSource_on = GameObject.Find("OnSound");
        SoundSource_in = GameObject.Find("InSound");
        SoundSource_under = GameObject.Find("UnderSound");
        SoundSource_bgm = GameObject.Find("GameObject");
        ResultText = GameObject.Find("ResultText");

        Sphere_0 = GameObject.Find("Sphere_0");
        Sphere_1 = GameObject.Find("Sphere_1");
        Sphere_2 = GameObject.Find("Sphere_2");
        Sphere_3 = GameObject.Find("Sphere_3");
        Sphere_4 = GameObject.Find("Sphere_4");
        Sphere_5 = GameObject.Find("Sphere_5");
        Sphere_6 = GameObject.Find("Sphere_6");



        /****オブジェクトを非表示にする****/
       

        Renderer Sphere0 = Sphere_0.GetComponent<Renderer>();
        Renderer Sphere1 = Sphere_1.GetComponent<Renderer>();
        Renderer Sphere2 = Sphere_2.GetComponent<Renderer>();
        Renderer Sphere3 = Sphere_3.GetComponent<Renderer>();
        Renderer Sphere4 = Sphere_4.GetComponent<Renderer>();
        Renderer Sphere5 = Sphere_5.GetComponent<Renderer>();
        Renderer Sphere6 = Sphere_6.GetComponent<Renderer>();

        Sphere0.enabled = false;
        Sphere1.enabled = false;
        Sphere2.enabled = false;
        Sphere3.enabled = false;
        Sphere4.enabled = false;
        Sphere5.enabled = false;
        Sphere6.enabled = false;
        




        /****時間計測＿起動時の値*****/
        starttime = DateTime.Now.Hour * 60 * 60 * 1000 + DateTime.Now.Minute * 60 * 1000 +
                    DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;

        Debug.Log(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" +
                  DateTime.Now.Second + ":" + DateTime.Now.Millisecond);

       
    }


    // Update is called once per frame
    void Update()
    {
        

        Renderer Sphere0 = Sphere_0.GetComponent<Renderer>();
        Renderer Sphere1 = Sphere_1.GetComponent<Renderer>();
        Renderer Sphere2 = Sphere_2.GetComponent<Renderer>();
        Renderer Sphere3 = Sphere_3.GetComponent<Renderer>();
        Renderer Sphere4 = Sphere_4.GetComponent<Renderer>();
        Renderer Sphere5 = Sphere_5.GetComponent<Renderer>();
        Renderer Sphere6 = Sphere_6.GetComponent<Renderer>();

        


        /*************キー入力*********************/



        if (Input.GetKeyDown("0"))
        {
            Sphere0.enabled = true;
        }

        if (Input.GetKeyDown("1"))
        {
            Sphere1.enabled = true;
        }

        if (Input.GetKeyDown("2"))
        {
            Sphere2.enabled = true;
        }

        if (Input.GetKeyDown("3"))
        {
            Sphere3.enabled = true;
        }

        if (Input.GetKeyDown("4"))
        {
            Sphere4.enabled = true;
        }

        if (Input.GetKeyDown("5"))
        {
            Sphere5.enabled = true;
        }

        if (Input.GetKeyDown("6"))
        {
            Sphere6.enabled = true;
        }

        if (Input.GetKeyDown("7"))
        {
            Sphere0.enabled = false;
            Sphere1.enabled = false;
            Sphere2.enabled = false;
            Sphere3.enabled = false;
            Sphere4.enabled = false;
            Sphere5.enabled = false;
            Sphere6.enabled = false;
        }









        /*
        if (Input.GetKeyDown("k"))
        {
            ObjFlag = 0;
            audioSource_in.clip = sound_in;
            audioSource_in.Play();
            InRenderer.enabled = true;



        }

        if (Input.GetKeyDown("l"))
        {
            ObjFlag = 1;
            audioSource_on.clip = sound_on;
            audioSource_on.Play();

            OnRenderer.enabled = true;



        }

        if (Input.GetKeyDown("j"))
        {
            ObjFlag = 2;
            audioSource_under.clip = sound_under;
            audioSource_under.Play();

            UnderRenderer.enabled = true;



        }

        if (Input.GetKeyDown("b"))
        {

            audioSource_bgm.clip = sound_bgm;
            audioSource_bgm.Play();



        }



        if (Input.GetKeyDown("i"))
        {

            Debug.Log("I-String");

            if (ObjFlag == 0)
            {
                s = s + "〇";
                ObjFlag = 3;
            }

            if (ObjFlag == 1)
            {
                s = s + "×";
                ObjFlag = 3;
            }
            if (ObjFlag == 2)
            {
                s = s + "×";
                ObjFlag = 3;
            }

            audioSource_on.clip = none;
            audioSource_on.Play();
            audioSource_in.clip = none;
            audioSource_in.Play();
            audioSource_under.clip = none;
            audioSource_under.Play();
            audioSource_bgm.clip = none;
            audioSource_bgm.Play();

            OnRenderer.enabled = false;
            InRenderer.enabled = false;
            UnderRenderer.enabled = false;


        }

        if (Input.GetKeyDown("o"))
        {
            Debug.Log("O-String");

            if (ObjFlag == 0)
            {
                s = s + "×";
                ObjFlag = 3;
            }

            if (ObjFlag == 1)
            {
                s = s + "〇";
                ObjFlag = 3;
            }
            if (ObjFlag == 2)
            {
                s = s + "×";
                ObjFlag = 3;
            }


            audioSource_on.clip = none;
            audioSource_on.Play();
            audioSource_in.clip = none;
            audioSource_in.Play();
            audioSource_under.clip = none;
            audioSource_under.Play();
            audioSource_bgm.clip = none;
            audioSource_bgm.Play();

            OnRenderer.enabled = false;
            InRenderer.enabled = false;
            UnderRenderer.enabled = false;


        }

        if (Input.GetKeyDown("u"))
        {
            Debug.Log("U-String");

            if (ObjFlag == 0)
            {
                s = s + "×";
                ObjFlag = 3;
            }
            if (ObjFlag == 1)
            {
                s = s + "×";
                ObjFlag = 3;
            }

            if (ObjFlag == 2)
            {
                s = s + "〇";
                ObjFlag = 3;
            }


            audioSource_on.clip = none;
            audioSource_on.Play();
            audioSource_in.clip = none;
            audioSource_in.Play();
            audioSource_under.clip = none;
            audioSource_under.Play();
            audioSource_bgm.clip = none;
            audioSource_bgm.Play();

            OnRenderer.enabled = false;
            InRenderer.enabled = false;
            UnderRenderer.enabled = false;


        }



        if (Input.GetKeyDown("r"))
        {
            InRenderer.enabled = true;
            UnderRenderer.enabled = true;
            OnRenderer.enabled = true;

            scoreText.text = title;
            Debug.Log(s);

        }

        if (Input.GetKeyDown("f"))
        {
            ObjFlag = 3;
            scoreText.text = null;
            InRenderer.enabled = false;
            UnderRenderer.enabled = false;
            OnRenderer.enabled = false;

            audioSource_on.clip = none;
            audioSource_on.Play();
            audioSource_in.clip = none;
            audioSource_in.Play();
            audioSource_under.clip = none;
            audioSource_under.Play();
            audioSource_bgm.clip = none;
            audioSource_bgm.Play();

        }
        
        if (Input.GetKeyDown("z"))
        {
        #if UNITY_UWP
        Task.Run(async ()=>
        {

            

            // ローカルフォルダー
            // 「User Files\LocalAppData\<アプリ名>\LocalState」 以下にできる
            {
                var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("DocumentLibraryTest", CreationCollisionOption.OpenIfExists);
                var file = await folder.CreateFileAsync("test.txt", CreationCollisionOption.ReplaceExisting);

                using (var stream = await file.OpenStreamForWriteAsync())
                {
                    var bytes = System.Text.Encoding.UTF8.GetBytes(@"テストてすとtest" + cnt);
                    await stream.WriteAsync(bytes, 0, bytes.Length);
                }
            }

           
        });
        #endif

        }
        */


        //9回処理を終えた際，計測時間をtxtに書き出し
        if (cnt == 9)
        {
            cnt = 10;
            scoreText.text = "Thank you";
            //ans = null;

            /*
            for (cnt_out = 0; cnt_out <= 8; cnt_out++)
            {
                tmp = MeasureTime[cnt_out];
                hour = tmp / 60 / 60 / 1000;//時間に直す
                tmp = tmp - hour * 60 * 60 * 1000;

                min = tmp / 60 / 1000;//分に直す
                tmp = tmp - min * 60 * 1000;

                sec = tmp / 1000;//秒に直す
                tmp = tmp - sec * 1000;

                msec = tmp;//残ったミリ秒

                Debug.Log(hour + ":" + min + ":" + sec + ":" + msec);
            }
            */


            /********HoloLens用のファイル出力************/
#if UNITY_UWP
        Task.Run(async ()=>
        {

            

            // ローカルフォルダー
            // 「User Files\LocalAppData\<アプリ名>\LocalState」 以下にできる
            {
                var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("DocumentLibraryTest", CreationCollisionOption.OpenIfExists);
                var file = await folder.CreateFileAsync("test" + cnt_task + ".txt", CreationCollisionOption.ReplaceExisting);

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

                        var bytes = System.Text.Encoding.UTF8.GetBytes(@hour + "," + min + "," + sec + "," + msec + "," + ans[cnt_out] + "\n");
                        await stream.WriteAsync(bytes, 0, bytes.Length);
                    }
                }
            }

           
        });
#endif

        }


        if (Input.GetKeyDown(KeyCode.Home) && cnt == 10)
        {
            cnt = 0;
            TimeFlag = 0;
            scoreText.text = "Press Space Key";
            cnt_task++;
        }



    }

}
