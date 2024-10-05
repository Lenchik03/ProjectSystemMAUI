using System.Threading.Tasks;

namespace ProjectSystemMAUI;

public partial class NewProjectPage : ContentPage
{
    public ProjectModel Project { get; set; }

    private DB dB;
    public NewProjectPage(ProjectModel project, DB dB)
	{
		InitializeComponent();
        this.dB = dB;
        this.Project = project;
        BindingContext = this;
	}

    public void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        header.Text = $"Выбрано: {e.NewValue:F1}";
        double value = ((Slider)sender).Value;
        Project.Deadlines = value;
    }

    private async void SaveClick(object sender, EventArgs e)
    {
        
        if (Project == null || Project.Id == 0)
        {
            await dB.NewProject(Project);
            await Navigation.PopAsync();
        }
        else
        {
            await dB.UpdateProject(Project);
            await Navigation.PopAsync();
        }
    }
}