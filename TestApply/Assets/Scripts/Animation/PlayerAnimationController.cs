using Scripts.Skins;
using UnityEngine;
using Zenject;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SkinnedMeshRenderer _mesh;
    [SerializeField] private ParticleSystem _positiveParticles;
    [SerializeField] private ParticleSystem _negativePartivles;

    private BalanceService _balanceService;
    private SkinTypeModel _skinTypeModel;
    private BalanceBar _balanceBar;

    protected SkinTypesDatabase _skinTypesDatabase;

    [Inject]
    private void Construct(BalanceService balanceService, SkinTypesDatabase skinTypesDatabase, BalanceBar balanceBar)
    {
        _balanceService = balanceService;
        _skinTypesDatabase = skinTypesDatabase;
        _balanceBar = balanceBar;
        _balanceService.OnStateChanged += TransformAnimation;
    }

    private void Awake()
    {
        SwitchMesh(ESkinType.Base);
    }
    public void WalkAnimation(bool isWalking) 
    {
        _animator.SetBool("Move", isWalking);
    }

    public void DeathAnimation(bool isDead) 
    {
        _animator.SetBool("Death", isDead);
    }


    public void EmitPositiveParticles()
    {
        _positiveParticles.Emit(10);
    }

    public void EmitNegativeParticles()
    {
        _negativePartivles.Emit(10);
    }

    public void TransformAnimation(States state)
    {
        _animator.SetTrigger("Transform");

        switch (state)
        {
            case States.Poor:
                SwitchMesh(ESkinType.Poor);
                _balanceBar.UpperBarText.text = GetSkinType(ESkinType.Poor).Description;
                break;
            case States.Base:
                SwitchMesh(ESkinType.Base);
                _balanceBar.UpperBarText.text = GetSkinType(ESkinType.Base).Description;
                break;
            case States.Buisiness:
                SwitchMesh(ESkinType.Buisiness);
                _balanceBar.UpperBarText.text = GetSkinType(ESkinType.Buisiness).Description;
                break;
            case States.Cocktail:
                SwitchMesh(ESkinType.Cocktail);
                _balanceBar.UpperBarText.text = GetSkinType(ESkinType.Cocktail).Description;
                break;
            case States.Middle:
                SwitchMesh(ESkinType.Middle);
                _balanceBar.UpperBarText.text = GetSkinType(ESkinType.Middle).Description;
                break;
        }
    }

    public void DanceWinAnimation(bool isAble)
    {
        _animator.SetBool("Dance", isAble);
    }

    private void SwitchMesh(ESkinType skinType) 
    {
        _skinTypeModel = GetSkinType(skinType);
        _mesh.sharedMesh = _skinTypeModel.SkinMesh;
    }

    private SkinTypeModel GetSkinType(ESkinType skinType) 
    {
        return _skinTypesDatabase.GetSkinTypeModel(skinType);
    }

    private void OnDestroy()
    {
        _balanceService.OnStateChanged -= TransformAnimation;
    }
}
