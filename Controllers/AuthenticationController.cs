using System;
using TaskManagementApp.Models;
using TaskManagementApp.Services;

public class AuthenticationController
{
    private readonly UserService _userService;
    private readonly UserController _userController;

    public AuthenticationController(UserService userService, UserController userController)
    {
        _userService = userService;
        _userController = userController;
    }

    public void Register()
    {
        Console.WriteLine("Register a new user");
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        var newUser = new User { Username = username, Password = password };

        // Check if the username already exists
        var existingUser = _userService.GetUserByUsername(username);
        if (existingUser != null)
        {
            Console.WriteLine("Username already exists. Registration failed.");
            return;
        }

        _userController.RegisterUser(newUser);
        Console.WriteLine("Registration successful.");
    }

    public bool Login()
    {
        Console.WriteLine("User Login");
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        // Check if the username and password match
        var user = _userService.GetUserByUsername(username);
        if (user != null && user.Password == password)
        {
            Console.WriteLine("Login successful.");
            return true;
        }
        else
        {
            Console.WriteLine("Login failed. Invalid username or password.");
            return false;
        }
    }
}
