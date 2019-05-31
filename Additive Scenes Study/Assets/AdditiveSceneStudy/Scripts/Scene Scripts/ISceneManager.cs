namespace TRIPSS
{
    public interface ISceneManager
    {
        bool Register(IManagedScene managedScene);
        bool Unregister(IManagedScene managedScene);
    }
}
