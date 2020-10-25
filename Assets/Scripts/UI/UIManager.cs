using System;

namespace CD_Test.Assets.Scripts.UI
{
    using UnityEngine;
    
    public class UIManager : MonoBehaviour {
        
        [SerializeField] private GameObject _loadingGroup;
        
        public void ShowLoading(){
            _loadingGroup.gameObject.SetActive(true);
        }

        public void HideLoading(){
            _loadingGroup.gameObject.SetActive(false);
        }
    }
}
