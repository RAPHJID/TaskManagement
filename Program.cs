using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Data;
using TaskManagementApp.Services;

namespace TaskManagementApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ApplicationDbContext context = new ApplicationDbContext();
            ProjectService projectService = new ProjectService(context);
            TaskService taskService = new TaskService(context);
            UserService userService = new UserService(context);
            AuthenticationController authenticationController = new AuthenticationController(userService, projectService, taskService);

            authenticationController.StartSession();
        }
    }
}