using System.ComponentModel;

namespace ProjectSystemMAUI
{
    public partial class MainPage : ContentPage
    {
        public List<ProjectModel> Projects { get; set; }

        public List<TaskModel> Tasks { get; set; }

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

        private async void NewTaskClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewTaskWindow());
        }

        private void UpdateTaskClick(object sender, EventArgs e)
        {

        }

        private async void DeleteTaskClick(object sender, EventArgs e)
        {
            await dB.Delete(SelectedTask);
        }
    }

}
