using System;

namespace CD_Test.Assets.Scripts.UI
{
    using UnityEngine;
    using UnityEngine.UI;
    
    public class ThumbnailView : MonoBehaviour {
        
        [SerializeField] private RawImage _rawImage;

        public void SetTexture(Texture texture){
            _rawImage.texture = texture;
        }

    }
}
