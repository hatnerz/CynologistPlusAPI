namespace WebAPI.DI
{
    public interface IDbControlService
    {
        bool CreateDbBackup();

        bool RestoreDbFromLastBackup();

        DateTime? GetLastBackupDate();
    }
}
