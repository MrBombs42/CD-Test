using System;

namespace CD_Test.Assets.Scripts
{
    using CD_Test.Assets.Scripts.Models;
    using UnityEngine;
    using UnityEngine.Networking;

    public class Starter : MonoBehaviour {
        
        void Start()
        {
            WebRequest request = new WebRequest();

            StartCoroutine(request.Get("https://s3-sa-east-1.amazonaws.com/static-files-prod/unity3d/models.json",
             OnRequestSucess, OnRequestError)); 
        }



        private void OnRequestSucess(string webRequest){
            
            UnityEngine.Debug.Log(webRequest);
            var data = JsonUtility.FromJson<ModelListData>(webRequest);
            UnityEngine.Debug.Log(data.models.Length);

        }

        private void OnRequestError(string webRequest){
            UnityEngine.Debug.Log(webRequest);
        }
    }
}
