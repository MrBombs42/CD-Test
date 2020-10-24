using System;

namespace CD_Test.Assets.Scripts
{
    using CD_Test.Assets.Scripts.Loadables;
    using CD_Test.Assets.Scripts.Models;
    using UnityEngine;

    public class Starter : MonoBehaviour {
        
        [SerializeField] private SceneFactory _sceneFactory;
        void Start()
        {
            WebRequest request = new WebRequest();

            StartCoroutine(request.Get("https://s3-sa-east-1.amazonaws.com/static-files-prod/unity3d/models.json",
             OnRequestSucess, OnRequestError)); 
        }



        private void OnRequestSucess(string webRequest){
            
            var data = JsonUtility.FromJson<ModelListData>(webRequest);
            _sceneFactory.Build(data);
        }

        private void OnRequestError(string webRequest){
            UnityEngine.Debug.Log(webRequest);
        }
    }
}
