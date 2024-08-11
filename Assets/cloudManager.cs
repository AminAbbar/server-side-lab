using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.CloudSave;
using System.Threading.Tasks;
using Unity.Services.CloudSave.Models.Data.Player;
using Newtonsoft.Json;

public class cloudManager : MonoBehaviour
{  

          public async Task<playerData> GetUnitInfo(string key)
    {
        try
        {

            var res = await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string>{"archer"}, new LoadOptions(new ProtectedReadAccessClassOptions()));
        
          if (res.TryGetValue(key, out var data)) {
              string jsonValue = JsonConvert.SerializeObject(data.Value);



                 var unitInfoDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonValue);
                 var unitInfo = playerData.FromDictionary(unitInfoDict);

    
            return unitInfo;
          }else{
           return null;
          }
            
           
        }
        catch (CloudSaveException e)
        {
            Debug.LogError("Failed to retrieve UnitInfo: " + e);
            return null;
        }
        catch(System.Exception e){
              Debug.LogError("Failed to retrieve UnitInfo: " + e);
            return null;
        }
    }

}
