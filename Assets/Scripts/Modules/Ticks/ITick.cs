namespace Modules.Ticks
{
    public interface ITick
    {
        bool Enabled { get; set; }
    }
    
    public interface ITickFixedUpdate : ITick
    {
        void Tick();
    }
    
    public interface ITickLateUpdate : ITick
    {
        void Tick();
    }
    
    public interface ITickUpdate : ITick
    {
        void Tick();
    }
}