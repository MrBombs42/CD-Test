using System;

namespace CD_Test.Assets.Scripts.UI
{
   using UnityEngine;
   using UnityEngine.UI;

   public class SelectableView : MonoBehaviour {
       
      [SerializeField] private Text _selectedObjectText;
      [SerializeField] private Button _duplicateButton;
      [SerializeField] private Button _colorOneButton;
      [SerializeField] private Button _colorTwoButton;
      [SerializeField] private Button _colorThreeButton;


      public void SetSelectionName(string selectionName){
         _selectedObjectText.text = selectionName;
      }

      public Button DuplicateButton{get{return _duplicateButton;}}

      public Button ColorOneButton{get{return _colorOneButton;}}
      public Button ColorTwoButton { get{return _colorTwoButton;} }
      public Button ColorThreeButton { get{return _colorThreeButton;} }
    }
}
