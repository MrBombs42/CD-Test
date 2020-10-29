namespace CD_Test.Assets.Scripts.Selectable
{
    using CD_Test.Assets.Scripts.UI;
    using UnityEngine;

    public class SelectableManager : MonoBehaviour {

        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableView _view;
        [SerializeField] private float _scaleSpeed = 10;
        [SerializeField] private float _translationSpeed = 10;
        [SerializeField] private float _rotationSpeed = 100;
        private Transform _selectedTransform;

        private int _colorId = Shader.PropertyToID("_Color");
        private int _textureId = Shader.PropertyToID("_MainTex");

        private MaterialPropertyBlock _propertyBlock;
        private Renderer _selectedRenderer;

        private void Start() {
            _propertyBlock = new MaterialPropertyBlock();
            _view.DuplicateButton.onClick.AddListener(OnDuplicateButtonClick);
            _view.ColorOneButton.onClick.AddListener(SetSelectObjectToColorOne);
            _view.ColorTwoButton.onClick.AddListener(SetSelectObjectToColorTwo);
            _view.ColorThreeButton.onClick.AddListener(SetSelectObjectToColorThree);
            _view.TextureOneButton.onClick.AddListener(SetTextureButtonOne);
            _view.TextureTwoButton.onClick.AddListener(SetTextureButtonTwo);
            _view.TextureThreeButton.onClick.AddListener(SetTextureButtonThree);
        }

        private void SetSelectObjectToColorOne()
        {           
            SetSelectObjectToColor( _view.ColorOneButton.image.color);
        }
         private void SetSelectObjectToColorTwo()
        {
            SetSelectObjectToColor( _view.ColorTwoButton.image.color);
        }
        private void SetSelectObjectToColorThree()
        {
            SetSelectObjectToColor( _view.ColorThreeButton.image.color);
        }

        private void SetSelectObjectToColor(Color color)
        {
            _propertyBlock.SetColor(_colorId, color);
           SetPropertyBlock();
        }

        private void SetTextureButtonOne(){
            SetTexture(_view.TextureOneButton.image.mainTexture);
        }

         private void SetTextureButtonTwo(){
            SetTexture(_view.TextureTwoButton.image.mainTexture);
         }
        

         private void SetTextureButtonThree(){
            SetTexture(_view.TextureThreeButton.image.mainTexture);
         }
        

        private void SetTexture(Texture texture){
            _propertyBlock.SetTexture(_textureId, texture);
            SetPropertyBlock();
        }

        private void SetPropertyBlock(){
            if(_selectedRenderer == null){
                return;
            }
            _selectedRenderer.SetPropertyBlock(_propertyBlock);
        }

        private void OnDuplicateButtonClick()
        {
            if(_selectedTransform == null){
                Debug.LogError("Select something");
                return;
            }
            var position = _selectedTransform.transform.position + _selectedTransform.up *  3;
            var newObject = Instantiate(_selectedTransform.gameObject, position, _selectedTransform.rotation);
            AssetSceneCache.Add(newObject);
        }

        void Update()
        {
            if(Input.GetMouseButtonDown(0)){
               var ray = _camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
               if(Physics.Raycast(ray, out hit)){
                    _selectedTransform = hit.transform;
                    _selectedRenderer = _selectedTransform.GetComponent<MeshRenderer>();
                    _selectedRenderer.GetPropertyBlock(_propertyBlock);
                    Debug.Log(_selectedTransform.name);
                    _view.SetSelectionName(_selectedTransform.name);
               }
            }

            if(_selectedTransform != null){
                UpdateScale();
                UpdateRotation();
                UpdatePosition();
            }
        }

        private void UpdateScale(){      

            var scrollDelta = GetScrollDelta();                       
            var speed = _scaleSpeed * scrollDelta * Time.deltaTime;
            var scale = new Vector3(speed, speed, speed);
            _selectedTransform.localScale += scale;              
        }

        private float GetScrollDelta(){
            if(Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.KeypadPlus)){
                return 1;
            }

            if(Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus)){
                return -1;
            }

            return Input.mouseScrollDelta.y;
        }
        private void UpdateRotation(){

            var y = Input.GetAxisRaw("RotateY");
            var x = Input.GetAxisRaw("RotateX");
            var z = Input.GetAxisRaw("RotateZ");

            var angleY = y * _rotationSpeed * Time.deltaTime;
            var angleX = x * _rotationSpeed * Time.deltaTime;
            var angleZ = z * _rotationSpeed * Time.deltaTime;

            _selectedTransform.rotation *= Quaternion.AngleAxis(angleY, Vector3.up);
            _selectedTransform.rotation *= Quaternion.AngleAxis(angleX, Vector3.right);
            _selectedTransform.rotation *= Quaternion.AngleAxis(angleZ, Vector3.forward);
        }

        private void UpdatePosition(){
            var x = Input.GetAxisRaw("Horizontal");
            var z = Input.GetAxisRaw("Vertical");
            var y = Input.GetAxisRaw("UpDown");

            _selectedTransform.position += new Vector3(x, y, z) * _translationSpeed * Time.deltaTime;
        }

    }
}
