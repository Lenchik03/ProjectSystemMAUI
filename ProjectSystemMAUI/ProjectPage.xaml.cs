using System.Threading.Tasks;

namespace ProjectSystemMAUI;

public partial class ProjectPage : ContentPage
{
    public List<ProjectModel> Projects { get; set; }
	public ProjectModel SelectedProject { get; set; }

    public List<TaskModel> Tasks { get; set; }

    private DB dB = new DB(); 
    public ProjectPage()
	{
		InitializeComponent();
        UpdateList();
        BindingContext = this;

    }

    private async void UpdateList()
    {
        Projects = await dB.GetProjects();
        Tasks = SelectedProject.Tasks;
        OnPropertyChanged(nameof(Projects));
    }

    private async void NewProjectClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewProjectPage(SelectedProject));
    }

    private async void UpdateProjectClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewProjectPage(SelectedProject));
    }

    private async void DeleteProjectClick(object sender, EventArgs e)
    {
        if (SelectedProject.Tasks.Count > 0)
        {
            await DisplayAlert("Ошибка", "Перед тем как удалить проект - удалите все задачи, входящие в этот проект", "Отмена");
        }
        else
        {
            await dB.DeleteProject(SelectedProject);
        }
    }

    private async void TasksClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}