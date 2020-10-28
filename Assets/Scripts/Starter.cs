using System;

namespace CD_Test.Assets.Scripts
{
    using CD_Test.Assets.Scripts.Loadables;
    using CD_Test.Assets.Scripts.Models;
    using CD_Test.Assets.Scripts.Selectable;
    using CD_Test.Assets.Scripts.UI;
    using UnityEngine;

    public class Starter : MonoBehaviour {
        
        [SerializeField] private SceneFactory _sceneFactory;
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private SaveSceneManager _saveSceneManager;
        
        void Start()
        {
            _sceneFactory.OnBuildCompleted += OnSceneBuildCompleted;
            StartLoading();
            
        }

        void OnDestroy()
        {
            _sceneFactory.OnBuildCompleted -= OnSceneBuildCompleted;
        }

        private void OnSceneBuildCompleted()
        {
            _uiManager.HideLoading();
        }

        // void Update()
        // {
        //     if(Input.GetKeyDown(KeyCode.C)){
        //         Load();
        //     }
        // }

        private void Load(){

             _uiManager.ShowLoading();
            foreach (var item in  AssetSceneCache.CachedObjectsList)
            {
                Destroy(item);
            }
            AssetSceneCache.Clear();
            _uiManager.Clear();
            OnRequestSucess(_saveSceneManager.Load());
        }

        private void StartLoading(){

            _uiManager.ShowLoading();
            WebRequest request = new WebRequest();
            StartCoroutine(request.Get("https://s3-sa-east-1.amazonaws.com/static-files-prod/unity3d/models.json",
             OnRequestSucess, OnRequestError));
        }

        private void OnRequestSucess(string webRequest){
            
            var data = JsonUtility.FromJson<ModelListData>(webRequest);
            _sceneFactory.Build(data);
            _uiManager.ShowThumbnails(data);
        }

        private void OnRequestError(string webRequest){
            UnityEngine.Debug.Log(webRequest);
        }
    }
}
