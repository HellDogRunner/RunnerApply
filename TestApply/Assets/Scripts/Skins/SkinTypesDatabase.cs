using RedMoonGames.Basics;
using RedMoonGames.Database;
using UnityEngine;

namespace Scripts.Skins
{
    [CreateAssetMenu(fileName = "SkinTypessDatabase", menuName = "[RMG] Scriptable/Skins/SkinTypesDatabase", order = 1)]
    public class SkinTypesDatabase : ScriptableDatabase<SkinTypeModel>
    {
        public SkinTypeModel GetSkinTypeModel(ESkinType skinType)
        {
            return _data.GetBy(skinModel => skinModel.SkinType == skinType);
        }
    }
}
