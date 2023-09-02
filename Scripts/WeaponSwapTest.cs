using System.Collections.Generic;
using BaseCustomFactions.Scripts.Logging;
using UnityEngine;

namespace BaseCustomFactions.Scripts
{
    public class WeaponSwapTest : MonoBehaviour
    {
        private readonly ILog Logger = LogFactory.GetLogger(typeof(WeaponSwapTest), LogLevelsEnum.All);

        public GameObject prefabToUse;
        
        public void SwapThem()
        {
            GameObject[] bone = GetRootItemBones("Root Item Bone");
            foreach (GameObject workingBone in bone)
            {
                int childCount = workingBone.transform.childCount;
                for (int i = 0; i < childCount; i++)
                {
                    Transform currentWeapon = workingBone.transform.GetChild(i);
                    Logger.Debug($"Weapon: {currentWeapon.name} has pos: {currentWeapon.position} and rot: {currentWeapon.rotation}");
                    GameObject test = Instantiate(prefabToUse, workingBone.transform);
                    test.transform.position = currentWeapon.position;
                    test.transform.rotation = currentWeapon.rotation;
                    Logger.Debug("Created weapon copy");

                    //test = Instantiate(prefabToUse, workingBone.transform);
                    Logger.Debug("Created weapon copy alternative");
                    
                    currentWeapon.gameObject.SetActive(false);

                }
            }
        }
        
        
        
        
        public GameObject[] GetRootItemBones(string objectName)
        {
            List<GameObject> final = new List<GameObject>();
                
            GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>(true);
            foreach (GameObject working in allObjects)
            {
                if (working.name == objectName)
                {
                    final.Add(working);
                    Logger.Debug($"Found {objectName}");
                    break;
                }
            }
            return final.ToArray();
        }
    }
}