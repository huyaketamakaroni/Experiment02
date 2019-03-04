using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_UWP
using Windows.Storage;
using System.Threading.Tasks;
#endif

public class DocumentLibraryTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
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
                    var bytes = System.Text.Encoding.UTF8.GetBytes(@"テストてすとtestあああ");
                    await stream.WriteAsync(bytes, 0, bytes.Length);
                }
            }

           
        });
#endif
    }

    // Update is called once per frame
    void Update () {
		
	}
}
