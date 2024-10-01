namespace ProjectSystemMAUI;

public partial class NewTaskWindow : ContentPage
{
	public TaskModel Task {  get; set; }

    public List<ProjectModel> Projects { get; set; }

    public ProjectModel Project { get; set; }

    private DB dB = new DB();

    public NewTaskWindow()
	{
		InitializeComponent();
        UpdateList();
        BindingContext = this;
    }

    private async void UpdateList()
    {
        Projects = await dB.GetProjects();
        OnPropertyChanged(nameof(Projects));
    }

    private async void SaveClick(object sender, EventArgs e)
    {
        
        Task.Project = Project;


        if (Task.Id == 0)
        {
            await dB.NewTask(Task);
            UpdateList();
        }
        else
        {
            await dB.Update(Task);
            UpdateList();
        }
    }
}