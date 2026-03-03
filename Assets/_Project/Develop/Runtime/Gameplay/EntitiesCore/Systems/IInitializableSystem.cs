namespace Runtime.Gameplay.EntitiesCore.Features
{
    public interface IInitializableSystem : IEntitySystem
    {
        void OnInit(Entity entity);
    }
}