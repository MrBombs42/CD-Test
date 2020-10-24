using System;

namespace CD_Test.Assets.Scripts.Loadables
{
    using System.Collections;
    using UnityEngine;
   
   public class ResourcesLoader{
        public IEnumerator LoadAsset<T>(string assetName, Action<T> objectLoadedCallback) where T : Object{

            var request = Resources.LoadAsync<T>(assetName);

            while(!request.isDone){
                yield return null;
            }

            objectLoadedCallback(request.asset as T);            
        }


        public ResourceRequest LoadAsset(string assetName){
            return Resources.LoadAsync(assetName);          
        }
    }
}
