namespace WebAPI.DI
{
    public interface IDbControlService
    {
        Task<bool> CreateDbBackup(string backupName);

        Task<bool> RestoreDbFromBackup(string backupName);
    }
}
