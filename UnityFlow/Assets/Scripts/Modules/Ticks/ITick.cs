namespace Modules.Ticks
{
    public interface ITick
    {
        void Tick();
    }
    
    public interface ITickFixedUpdate : ITick
    {
        
    }
    
    public interface ITickLateUpdate : ITick
    {
        
    }
    
    public interface ITickUpdate : ITick
    {
        
    }
}