using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CD_Test.Assets.Scripts
{
    public static class AssetSceneCache
    {
        private static Dictionary<int, GameObject> _cache = new Dictionary<int, GameObject>();

        public static List<GameObject> CachedObjectsList{
            get{
                return _cache.Values.ToList();
            }
        }
        public static void Add(GameObject gameObject){
            var id = gameObject.GetInstanceID();
           if(_cache.ContainsKey(id)){
               return;
           }

           _cache[id] = gameObject;
        }

        public static void Clear(){
            _cache.Clear();
        }
    }
}
