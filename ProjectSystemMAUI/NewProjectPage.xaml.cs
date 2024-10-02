namespace ProjectSystemMAUI;

public partial class NewProjectPage : ContentPage
{
    public ProjectModel Project { get; set; } = new();

    private DB dB = new DB();
    public NewProjectPage(ProjectModel project)
	{
		InitializeComponent();
        this.Project = project;
        BindingContext = this;
	}

    private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        header.Text = $"Выбрано: {e.NewValue:F1}";
    }

    private void SaveClick(object sender, EventArgs e)
    {

    }
}