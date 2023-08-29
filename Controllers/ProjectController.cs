using TaskManagementApp.Models;
using TaskManagementApp.Services;
using System;
using System.Collections.Generic;

public class ProjectController
{
    private readonly ProjectService _projectService;

    public ProjectController(ProjectService projectService)
    {
        _projectService = projectService;
    }

    public void DisplayProjectMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Project Management Menu");
            Console.WriteLine("1. Create Project");
            Console.WriteLine("2. Update Project");
            Console.WriteLine("3. Delete Project");
            Console.WriteLine("4. List Projects");
            Console.WriteLine("5. Return to Main Menu");
            Console.Write("Enter your choice: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateProject();
                    break;
                case "2":
                    UpdateProject();
                    break;
                case "3":
                    DeleteProject();
                    break;
                case "4":
                    ListProjects();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private void CreateProject()
    {
        Console.Clear();
        Console.WriteLine("Create a New Project");

        Console.Write("Enter the project name: ");
        var projectName = Console.ReadLine();

        var newProject = new Project { Name = projectName };

        _projectService.CreateProjectAsync(newProject).Wait();
        Console.WriteLine("Project created successfully.");
    }

    private void UpdateProject()
    {
        Console.Clear();
        Console.WriteLine("Update a Project");

        Console.Write("Enter the project ID to update: ");
        if (int.TryParse(Console.ReadLine(), out int projectId))
        {
            var projectToUpdate = _projectService.GetProjectByIdAsync(projectId).Result;
            if (projectToUpdate != null)
            {
                Console.Write("Enter the new project name: ");
                projectToUpdate.Name = Console.ReadLine();

                _projectService.UpdateProjectAsync(projectToUpdate).Wait();
                Console.WriteLine("Project updated successfully.");
            }
            else
            {
                Console.WriteLine("Project not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid project ID.");
        }
    }

    private void DeleteProject()
    {
        Console.Clear();
        Console.WriteLine("Delete a Project");

        Console.Write("Enter the project ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int projectId))
        {
            _projectService.DeleteProjectAsync(projectId).Wait();
            Console.WriteLine("Project deleted successfully.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid project ID.");
        }
    }

    private void ListProjects()
    {
        Console.Clear();
        Console.WriteLine("List of Projects");

        var projects = _projectService.GetAllProjectsAsync().Result;
        if (projects.Count > 0)
        {
            foreach (var project in projects)
            {
                Console.WriteLine($"ID: {project.Id}, Name: {project.Name}");
            }
        }
        else
        {
            Console.WriteLine("No projects found.");
        }
    }
}
