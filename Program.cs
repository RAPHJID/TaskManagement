using TaskManagementApp.Data;
using TaskManagementSystem.Controller;

TaskManagerContext context = new TaskManagerContext();

AuthenticationController userAuth = new AuthenticationController();
userAuth.Init();
