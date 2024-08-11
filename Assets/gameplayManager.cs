using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
public class gameplayManager : MonoBehaviour
{
    // Start is called before the first frame update
        private cloudManager cloudManager;

         [SerializeField]
         private  TMP_Text unitNameText;
         [SerializeField]
         private TMP_Text unitHealthText;
         [SerializeField]
         private TMP_Text unitLevelText;
    void Start()
    {
        
    }

    public async Task initGame(){

     if(!cloudManager)  cloudManager = FindObjectOfType<cloudManager>();
           
        
        playerData playerData = await cloudManager.GetUnitInfo("archer");

           
           unitNameText.text = "name : archer";

           unitLevelText.text = $"level : {playerData.level.ToString()}";

           unitHealthText.text = $"health : {playerData.health.ToString()}"; 

         
    }
}
