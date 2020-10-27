using System;

namespace CD_Test.Assets.Scripts.UI
{
   using UnityEngine;
   using UnityEngine.UI;

   public class SelectableView : MonoBehaviour {
       
      [SerializeField] private Text _selectedObjectText;
      [SerializeField] private Button _duplicateButton;

      public void SetSelectionName(string selectionName){
         _selectedObjectText.text = selectionName;
      }

      public Button DuplicateButton{get{return _duplicateButton;}}
   }
}
