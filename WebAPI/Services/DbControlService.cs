using WebAPI.DI;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.Data.SqlClient;
using WebAPI.DataBase;
using WebAPI.Helpers;

namespace WebAPI.Services
{
    public class DbControlService : ServiceBase, IDbControlService
    {
        private readonly string serverName = ".\\SQLEXPRESS";
        private readonly string databaseName = "CynologistPlus";
        private readonly string backupName = "db.bak";
        private readonly ConfigurationHelper _configurationHelper;

        public DbControlService(CynologistPlusContext context, ConfigurationHelper configurationHelper) : base(context)
        {
            _configurationHelper = configurationHelper;
        }

        public bool CreateDbBackup()
        {
            ServerConnection serverConnection = new ServerConnection(serverName);
            Server server = new Server(serverConnection);

            Backup backup = new Backup();
            backup.Action = BackupActionType.Database;
            backup.Database = databaseName;

            BackupDeviceItem backupDeviceItem = new BackupDeviceItem(backupName, DeviceType.File);
            backup.Devices.Add(backupDeviceItem);

            backup.SqlBackup(server);
            return true;
        }

        public bool RestoreDbFromLastBackup()
        {
            ServerConnection serverConnection = new ServerConnection(serverName);
            Server server = new Server(serverConnection);

            Restore restore = new Restore();

            restore.Database = databaseName;
            restore.Action = RestoreActionType.Database;
            restore.Devices.AddDevice(backupName, DeviceType.File);

            restore.SqlRestore(server);
            return true;
        }

        public DateTime? GetLastBackupDate()
        {
            string query = $"USE msdb;\r\nSELECT TOP 1 MAX(bs.backup_finish_date) FROM backupset bs WHERE bs.database_name = '{databaseName}'";
            string? connectionString = _configurationHelper.GetConnectionString("default");
            if (connectionString == null)
                return null;

            DateTime? lastBackupDate;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   lastBackupDate = command.ExecuteScalar() as DateTime?;
                }
            }
            if (lastBackupDate.HasValue)
                return lastBackupDate;
            else
                return null;
        }
    }
}
