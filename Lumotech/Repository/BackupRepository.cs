using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class BackupRepository : RepositoryBase<string>, IBackupRepository
{
    private RepositoryContext _repositoryContext;
    
    public BackupRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }

    public void CreateBackupRepository()
    {
        var backupDirectoryPath = "C:\\LumotechBackups";
        var backupFileName = $"lumotech_backup_{DateTime.UtcNow:yyyyMMddHHmmss}.bak"; 

        var backupPath = Path.Combine(backupDirectoryPath, backupFileName);
        var backupCommand = $"BACKUP DATABASE Lumotech TO DISK = '{backupPath}'";
        _repositoryContext.Database.ExecuteSqlRaw(backupCommand);
    }
}