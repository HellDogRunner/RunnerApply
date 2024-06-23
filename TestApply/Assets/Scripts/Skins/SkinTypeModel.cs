using RedMoonGames.Database;
using System;
using UnityEngine;

namespace Scripts.Skins 
{
    [Serializable]
    public class SkinTypeModel : IDatabaseModelPrimaryKey<ESkinType>
    {
        public ESkinType SkinType;
        [Space]
        [Header("Mesh")]
        public Mesh SkinMesh;

        public ESkinType PrimaryKey => SkinType;
    }

}