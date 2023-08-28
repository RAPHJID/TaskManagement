namespace TaskManagementApp.Models {
    public class User {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public ICollection<Tasker> Tasks { get; set; }
    }

namespace TaskManagementApp.Models {
    public class Project {
        public int Id {get; set; }
        public string name {get; set; }

        public ICollection<Tasker> Tasks {get; set; }
    }

     public enum TaskStatus {
        Pending,
        InProgress,
        Completed
    }

    public class Tasker{
        public int Id { get; set; }
        public string title { get; set; }
        public bool IsCompleted { get; set; }
        public TaskStatus TaskStatus { get; set; }

        public int AssignedUserId { get; set; }
        public User AssignedUser { get; set; }
    }
}
}