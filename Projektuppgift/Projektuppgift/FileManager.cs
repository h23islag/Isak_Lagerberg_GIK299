using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Projektuppgift
{
    internal static class FileManager
    {
        public static void SaveContent(List<User> users)
        {
            string usersJson = JsonSerializer.Serialize(users);

            // Get the current working directory of the application
            string projectDirectory = Directory.GetCurrentDirectory();

            // Append the desired subfolder name
            string subfolderName = "Users"; // Modify with your desired subfolder name
            string subfolderPath = Path.Combine(projectDirectory, subfolderName);

            // Create the subfolder if it doesn't exist
            if (!Directory.Exists(subfolderPath))
            {
                Directory.CreateDirectory(subfolderPath);
                Console.WriteLine($"Subfolder '{subfolderName}' created at: {subfolderPath}");
            }

            // Define the file name
            string fileName = "users.json"; // Modify with your desired file name

            // Combine the subfolder path and file name to get the full file path
            string filePath = Path.Combine(subfolderPath, fileName);

            // Save the content to the file
            File.WriteAllText(filePath, usersJson);
        }

        public static List<User> LoadFromFile(string filePath)
        {
            // Read the JSON content from the file
            string usersJson = File.ReadAllText(filePath);

            // Deserialize the JSON data back to the original type
            List<User> users = JsonSerializer.Deserialize<List<User>>(usersJson);

            return users;
        }
    }
}