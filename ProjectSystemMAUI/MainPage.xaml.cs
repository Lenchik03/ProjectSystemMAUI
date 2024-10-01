namespace ProjectSystemMAUI
{
    public partial class MainPage : ContentPage
    {
        public List<ProjectModel> Projects { get; set; }

        public Task<List<TaskModel>> Tasks { get; set; }



        public MainPage()
        {
            InitializeComponent();
            
            UpdateList();
            BindingContext = this;
        }

        private void UpdateList()
        {
            DB dB = new DB();
            Tasks = dB.GetTasks();
        }

        private void NewTask(object sender, EventArgs e)
        {
            NewTaskWindow newTaskWindow = new NewTaskWindow();
            
        }
    }

}
