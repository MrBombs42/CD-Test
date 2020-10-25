using System;

namespace CD_Test.Assets.Scripts.Selectable
{
    using CD_Test.Assets.Scripts.UI;
    using UnityEngine;
    
    public class SelectableManager : MonoBehaviour {

        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableView _view;
        [SerializeField] private float _scaleSpeed = 10;
          [SerializeField] private float _translationSpeed = 10;

        private Transform _selectedTransform;

        void Update()
        {
            if(Input.GetMouseButtonDown(0)){
               var ray = _camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
               if(Physics.Raycast(ray, out hit)){
                    _selectedTransform = hit.transform;
                    Debug.Log(_selectedTransform.name);
               }
            }

            if(_selectedTransform != null){
                UpdateScale();
                UpdateRotation();
                UpdatePosition();
            }
        }

        private void UpdateScale(){      

            var scrollDelta = Input.mouseScrollDelta;            
            var speed = _scaleSpeed * scrollDelta.y * Time.deltaTime;
            var scale = new Vector3(speed, speed, speed);
            _selectedTransform.localScale += scale;              
        }

        private void UpdateRotation(){
            if(!Input.GetMouseButton(1)){
                return;
            }


        }

        private void UpdatePosition(){
            var x = Input.GetAxisRaw("Horizontal");
            var z = Input.GetAxisRaw("Vertical");
            var y = Input.GetAxisRaw("UpDown");

            _selectedTransform.position += new Vector3(x, y, z) * _translationSpeed * Time.deltaTime;
        }

    }
}
