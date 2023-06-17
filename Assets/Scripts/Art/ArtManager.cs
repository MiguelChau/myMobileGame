using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using System.Linq;

public class ArtManager : Singleton<ArtManager>
{
    
    public enum ArtType
    {
        PLATFORM_01,
        PLATFORM_02,
        PLATFORM_03
    }

    public List<ArtSetup> artSetups;

    public ArtSetup GetSetupByType(ArtType artType)
    {
        return artSetups.FirstOrDefault(i => i.artType == artType);
    }
}

[System.Serializable]
public class ArtSetup
{
    public ArtManager.ArtType artType;
    public GameObject gameObject;
}
