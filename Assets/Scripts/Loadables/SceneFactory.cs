using System;

namespace CD_Test.Assets.Scripts.Loadables
{
    using System.Collections;
    using CD_Test.Assets.Scripts.Models;
    using UnityEngine;
    
    public class SceneFactory : MonoBehaviour {
        

        private ResourcesLoader _resourceLoader;

        private void Start() {
            _resourceLoader = new ResourcesLoader();
        }

        public void Build(ModelListData modelsData)
        {
            for(int i=0; i < modelsData.models.Length; i++){
                var model = modelsData.models[i];
                StartCoroutine(WaitForLoadingAndInstantiate(_resourceLoader.LoadAsset(model.name), model));
            }
            
        }

        private IEnumerator WaitForLoadingAndInstantiate(ResourceRequest loadRequest, ModelData data)
        {
            while(!loadRequest.isDone){
                yield return null;
            }
            var asset = loadRequest.asset;
            var position = new Vector3(data.position[0],data.position[1], data.position[2]);
            var rotation = Quaternion.Euler(data.rotation[0], data.rotation[1], data.rotation[2]);
            var scale = new Vector3(data.scale[0],data.scale[1], data.scale[2]);
            
            var obj = Instantiate(asset, position, rotation) as GameObject;     

            obj.transform.localScale = scale; 
        }
    }
}
