namespace CD_Test.Assets.Scripts.UI
{
    using CD_Test.Assets.Scripts.Models;
    using UnityEngine;

    public class UIManager : MonoBehaviour {
        
        [SerializeField] private GameObject _loadingGroup;
        [SerializeField] private ThumbnailsListView _thumbnailsListView;
        
        public void ShowLoading(){
            _loadingGroup.gameObject.SetActive(true);
        }

        public void HideLoading(){
            _loadingGroup.gameObject.SetActive(false);
        }

        public void ShowThumbnails(ModelListData modelsData){
            _thumbnailsListView.LoadAndShow(modelsData);
        }

        public void Clear(){
            _thumbnailsListView.Clear();
        }
    }
}
