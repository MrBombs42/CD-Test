namespace CD_Test.Assets.Scripts.Selectable
{
    using System.Collections;
    using System.IO;
    using CD_Test.Assets.Scripts.Models;
    using UnityEngine;
    using UnityEngine.UI;

    public class SaveSceneManager : MonoBehaviour {
        [SerializeField] private Button _saveButton;
        [SerializeField] private Text _saveText;
        private string _fileName = "SceneSavedData.json";
        private static string _path;

        private void Start() {

            ActivaSavingText(false);
            _saveButton.onClick.AddListener(SaveScene);

            string newPath = Path.GetFullPath(Path.Combine(Application.dataPath, @"..\"));
            _path = string.Format("{0}/{1}", newPath, _fileName);
        }

        private void SaveScene()
        {
            StartCoroutine(ShowSavingFeedback());
            var cache = AssetSceneCache.CachedObjectsList;
           
            ModelListData modelsData = new ModelListData();
            modelsData.models = new ModelData[cache.Count];

            for (int i = 0; i < cache.Count; i++)
            {
                var cachedObj = cache[i];
                modelsData.models[i] = GetModelData(cachedObj);
            }

             var data = JsonUtility.ToJson(modelsData);

             File.WriteAllText(_path, data);
        }

        private IEnumerator ShowSavingFeedback()
        {
            ActivaSavingText(true);
            yield return new WaitForSeconds(2);
            ActivaSavingText(false);
        }

        private void ActivaSavingText(bool active){
             _saveText.gameObject.SetActive(active);
        }

        public string Load()
        {
            return File.ReadAllText(_path);
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
