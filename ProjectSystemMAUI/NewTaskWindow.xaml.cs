namespace ProjectSystemMAUI;

public partial class NewTaskWindow : ContentPage
{
	public TaskModel TaskM {  get; set; }

    public List<ProjectModel> Projects { get; set; }

    public ProjectModel Project { get; set; }

    private DB dB;

    public NewTaskWindow(TaskModel taskModel, DB dB)
	{
		InitializeComponent();
        this.dB = dB;
        TaskM = taskModel;
        UpdateList();
        BindingContext = this;
        //Project = Projects.FirstOrDefault(s => s.Id == TaskM.ProjectId);
    }

    private async void UpdateList()
    {
        Projects = await dB.GetProjects();
        if(TaskM.Project != null)
        {
            Project = Projects.FirstOrDefault(s => s.Id == TaskM.ProjectId);
        }

        OnPropertyChanged(nameof(Projects));
        OnPropertyChanged(nameof(Project));
    }

    private async void SaveClick(object sender, EventArgs e)
    {
        if (Project != null)
        {
            TaskM.Project = Project;
            TaskM.ProjectId = TaskM.Project.Id;
        }


        if (TaskM == null || TaskM.Id == 0)
        {
            await dB.NewTask(TaskM);
            await Navigation.PopAsync();
        }
        else
        {
            await dB.Update(TaskM);
            await Navigation.PopAsync();
        }
    }
}