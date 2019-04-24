public interface IGameManager
{
    ManagerStatus status
    { get;}

    void Startup(NetWorkService service);
}