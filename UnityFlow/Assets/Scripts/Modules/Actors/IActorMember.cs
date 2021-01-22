namespace Modules.Actors
{
    public interface IActorMember
    {
        IActor Owner { get; }

        void Initialize(IActor owner);
    }
}