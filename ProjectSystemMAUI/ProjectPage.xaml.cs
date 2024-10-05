using System.Threading.Tasks;

namespace ProjectSystemMAUI;

public partial class ProjectPage : ContentPage
{
    public List<ProjectModel> Projects { get; set; } = new List<ProjectModel>();
    public ProjectModel SelectedProject { get; set; }

    public List<TaskModel> Tasks { get; set; }

    private DB dB;
    public ProjectPage(DB dB)
	{
		InitializeComponent();
        this.dB = dB;
        UpdateList();
        BindingContext = this;

    }

    private async void UpdateList()
    {
        Projects = await dB.GetProjects();
        
        OnPropertyChanged(nameof(Projects));
        
        //if(SelectedProject != null)
        //{
        //    Tasks = SelectedProject.Tasks;
        //    OnPropertyChanged(nameof(Tasks));
        //}
    }

    protected override void OnAppearing()
    {
        UpdateList();
    }

    private async void NewProjectClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewProjectPage(new ProjectModel(), dB));
    }

    private async void UpdateProjectClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewProjectPage(SelectedProject, dB));
    }

    private async void DeleteProjectClick(object sender, EventArgs e)
    {
        if (SelectedProject.Tasks.Count > 0)
        {
            await DisplayAlert("Ошибка", "Перед тем как удалить проект - удалите все задачи, входящие в этот проект", "Отмена");
        }
        else
        {
            await dB.DeleteProject(SelectedProject.Id);
            UpdateList();
        }
    }

    private async void TasksClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}