using System.ComponentModel;

namespace ProjectSystemMAUI
{
    public partial class MainPage : ContentPage
    {
        public List<ProjectModel> Projects { get; set; }

        public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();

        public TaskModel SelectedTask { get; set; }

        private DB dB = new DB();

        public MainPage()
        {
            InitializeComponent();
            
            UpdateList();
            BindingContext = this;
        }
       

        private async void UpdateList()
        {   
            Tasks = await dB.GetTasks();
            OnPropertyChanged(nameof(Tasks));
        }

        protected override void OnAppearing()
        {
            UpdateList();
        }

        private async void NewTaskClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewTaskWindow(new TaskModel(), dB));
        }

        private async void UpdateTaskClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewTaskWindow(SelectedTask, dB));
        }

        private async void DeleteTaskClick(object sender, EventArgs e)
        {
            await dB.Delete(SelectedTask.Id);
            UpdateList();
        }

        private async void ProjectsClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProjectPage());
        }
    }

}
