namespace Challenges.Helpers;

using System.Collections.Generic;
using System.Linq;
using System.IO;

public class FileHelpers : IFileHelpers
{
  /// <summary>
  /// A basic helper function to read the contents of a txt file into a List
  /// </summary>
  /// <param name="fileName">The name of the file to read</param>
  /// <param name="fileLocation">The location of the file (if not provided the app's base directory will be used)</param>
  /// <returns>A string list containing the contents of the file</returns>
  public virtual List<string> ReadFileContents(string fileName, string? fileLocation = null)
  {
    // Get text file path
    fileLocation ??= AppContext.BaseDirectory;
    var filePath = Path.Combine(fileLocation, fileName);

    // Read the content of the file
    var textContent = File.ReadAllLines(filePath);
    var text = textContent.ToList();
    return text;
  }
}

public interface IFileHelpers
{
  public List<string> ReadFileContents(string fileName, string? fileLocation = null);
}