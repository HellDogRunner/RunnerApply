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

    protected SkinTypesDatabase _skinTypesDatabase;

    [Inject]
    private void Construct(BalanceService balanceService, SkinTypesDatabase skinTypesDatabase)
    {
        _balanceService = balanceService;
        _skinTypesDatabase = skinTypesDatabase;
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
                break;
            case States.Base:
                SwitchMesh(ESkinType.Base);
                break;
            case States.Buisiness:
                SwitchMesh(ESkinType.Buisiness);
                break;
            case States.Cocktail:
                SwitchMesh(ESkinType.Cocktail);
                break;
            case States.Middle:
                SwitchMesh(ESkinType.Middle);
                break;
        }
    }

    public void DanceWinAnimation(bool isAble)
    {
        _animator.SetBool("Dance", isAble);
    }

    private void SwitchMesh(ESkinType skinType) 
    {
        _skinTypeModel = _skinTypesDatabase.GetSkinTypeModel(skinType);
        _mesh.sharedMesh = _skinTypeModel.SkinMesh;
    }

    private void OnDestroy()
    {
        _balanceService.OnStateChanged -= TransformAnimation;
    }
}
