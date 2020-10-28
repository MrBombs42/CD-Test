using System;

namespace CD_Test.Assets.Scripts.Selectable
{
    using System.IO;
    using CD_Test.Assets.Scripts.Models;
    using UnityEngine;
    using UnityEngine.UI;

    public class SaveSceneManager : MonoBehaviour {
        [SerializeField] private Button _saveButton;
        private string _fileName = "SceneSavedData.json";
        private static string Path;

        private void Start() {
            _saveButton.onClick.AddListener(SaveScene);
            Path = string.Format("{0}/{1}", Application.persistentDataPath, _fileName);
        }

        private void SaveScene()
        {
            Debug.Log(Application.persistentDataPath);
            var cache = AssetSceneCache.CachedObjectsList;
           
            ModelListData modelsData = new ModelListData();
            modelsData.models = new ModelData[cache.Count];

            for (int i = 0; i < cache.Count; i++)
            {
                var cachedObj = cache[i];
                modelsData.models[i] = GetModelData(cachedObj);
            }

             var data = JsonUtility.ToJson(modelsData);

             File.WriteAllText(Path, data);
        }

        public string Load()
        {
            return File.ReadAllText(Path);
        }

        private ModelData GetModelData(GameObject obj){
            
            return new ModelData{
                 name = obj.name,
                 position = ConvertVector3InArray(obj.transform.position),
                 rotation = ConvertVector3InArray(obj.transform.rotation.eulerAngles),
                 scale = ConvertVector3InArray(obj.transform.localScale)
            };
        }

        private float[] ConvertVector3InArray(Vector3 vector){
            float[] array = {vector.x, vector.y, vector.z};
            return array;
        }
    }
}
