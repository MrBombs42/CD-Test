namespace CD_Test.Assets.Scripts.UI
{
    using System.Collections.Generic;
    using CD_Test.Assets.Scripts.Loadables;
    using CD_Test.Assets.Scripts.Models;
    using UnityEngine;

    public class ThumbnailsListView : MonoBehaviour {
        
        [SerializeField] private ThumbnailView _thumbnailViewPrefab;
        [SerializeField] private Transform _gridTransform;
        private const string ThumbnailPrefix = "Textures/Thumbnails/";

        private List<ThumbnailView> _thumbsList; 
        private ResourcesLoader _resourcesLoader;

        void Awake()
        {
            _thumbsList = new List<ThumbnailView>();
            _resourcesLoader = new ResourcesLoader();
        }


        public void LoadAndShow(ModelListData modelsData){

            foreach (var model in modelsData.models)
            {
                var path = string.Format("{0}{1}", ThumbnailPrefix, model.name);
                StartCoroutine(_resourcesLoader.LoadAsset<Texture>(path, CreateThumb));
            }
        }

        private void CreateThumb(Texture texture)
        {
            var thumb = Instantiate(_thumbnailViewPrefab);
            thumb.SetTexture(texture);
            thumb.transform.SetParent(_gridTransform);
            thumb.gameObject.SetActive(true);
            _thumbsList.Add(thumb);
        }

        public void Clear(){
            foreach (var item in _thumbsList)
            {
                Destroy(item.gameObject);
            }

            _thumbsList.Clear();
        }

    }
}
