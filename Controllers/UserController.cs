using System;
using System.Collections.Generic;
using TaskManagementApp.Models;
using TaskManagementApp.Services;

public class UserController
{
    private readonly UserService _userService;
    private readonly TaskService _taskService;

    public UserController(UserService userService, TaskService taskService)
    {
        _userService = userService;
        _taskService = taskService;
    }

    public void RegisterUser()
    {
        Console.WriteLine("User Registration");

        Console.Write("Enter username: ");
        var username = Console.ReadLine();

        Console.Write("Enter password: ");
        var password = Console.ReadLine();

        var newUser = new User
        {
            Username = username,
            Password = password
        };

        try
        {
            _userService.CreateUserAsync(newUser).Wait();
            Console.WriteLine("Registration successful!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Registration failed: {ex.Message}");
        }
    }

    public bool Login()
    {
        Console.WriteLine("User Login");

        Console.Write("Enter username: ");
        var username = Console.ReadLine();

        Console.Write("Enter password: ");
        var password = Console.ReadLine();

        // Implement your authentication logic here.
        // You can check if the username and password match a user in the database.
        // Return true if login is successful, otherwise false.
        var user = _userService.GetUserByUsernameAndPassword(username, password).Result;

        if (user != null)
        {
            Console.WriteLine("Login successful!");
            return true;
        }
        else
        {
            Console.WriteLine("Login failed. Invalid username or password.");
            return false;
        }
    }

    public void ViewTasksForUser(int userId)
    {
        Console.WriteLine("Tasks Assigned to You:");

        var tasks = _taskService.GetTasksForUser(userId).Result;

        foreach (var task in tasks)
        {
            Console.WriteLine($"Task ID: {task.Id}");
            Console.WriteLine($"Title: {task.Title}");
            Console.WriteLine($"Status: {task.TaskStatus}");
            Console.WriteLine($"Is Completed: {task.IsCompleted}");
            Console.WriteLine();
        }
    }

    public void MarkTaskAsCompleted(int taskId)
    {
        Console.WriteLine("Mark Task as Completed");

        var task = _taskService.GetTaskByIdAsync(taskId).Result;

        if (task != null)
        {
            task.IsCompleted = true;
            task.TaskStatus = TaskStatus.Completed;

            _taskService.UpdateTaskAsync(task).Wait();

            Console.WriteLine("Task marked as completed!");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }
}
