using System;
using TaskManagementApp.Models;
using TaskManagementApp.Services;

public class AdminController
{
    private readonly ProjectService _projectService;

    public AdminController(ProjectService projectService)
    {
        _projectService = projectService;
    }

    public void CreateProject()
    {
        Console.WriteLine("Create Project");

        Console.Write("Enter project name: ");
        var projectName = Console.ReadLine();

        var newProject = new Project
        {
            Name = projectName
        };

        try
        {
            _projectService.CreateProjectAsync(newProject).Wait();
            Console.WriteLine("Project created successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to create project: {ex.Message}");
        }
    }

    public void UpdateProject()
    {
        Console.WriteLine("Update Project");

        Console.Write("Enter project ID to update: ");
        if (!int.TryParse(Console.ReadLine(), out int projectId))
        {
            Console.WriteLine("Invalid project ID.");
            return;
        }

        var projectToUpdate = _projectService.GetProjectByIdAsync(projectId).Result;

        if (projectToUpdate == null)
        {
            Console.WriteLine("Project not found.");
            return;
        }

        Console.Write("Enter new project name: ");
        var newProjectName = Console.ReadLine();

        projectToUpdate.Name = newProjectName;

        try
        {
            _projectService.UpdateProjectAsync(projectToUpdate).Wait();
            Console.WriteLine("Project updated successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to update project: {ex.Message}");
        }
    }

    public void DeleteProject()
    {
        Console.WriteLine("Delete Project");

        Console.Write("Enter project ID to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int projectId))
        {
            Console.WriteLine("Invalid project ID.");
            return;
        }

        try
        {
            _projectService.DeleteProjectAsync(projectId).Wait();
            Console.WriteLine("Project deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to delete project: {ex.Message}");
        }
    }
}