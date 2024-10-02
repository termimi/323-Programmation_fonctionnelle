string directoryPath = @"C:\Temp";

(int filesNumber,int directoriesNumber)GetFilesAndDirectoryNumber(string path)
{
    int _totalFile = 0;
    int _totalFolder = 0;
    FileInfo[] files = null;
    DirectoryInfo d = new DirectoryInfo($@"{path}");
    List<DirectoryInfo> subDirectories = d.EnumerateDirectories().ToList();

    _totalFolder += subDirectories.Count;
    files = d.GetFiles();
    _totalFile = files.Count();

    if (subDirectories.Count() > 0)
    {
        subDirectories.ForEach(d =>
        {
            (int totalFileInSubDir,int totaFolderInSubDir) = GetFilesAndDirectoryNumber(d.FullName);
            _totalFile += totalFileInSubDir;
            _totalFolder += totaFolderInSubDir;
        });
    }
    return (_totalFile, _totalFolder);
}
(int totalFiles, int totalDirectories) = GetFilesAndDirectoryNumber(directoryPath);
Console.WriteLine($"Nombre de dossier : {totalDirectories},  nombre de fichier {totalFiles}");