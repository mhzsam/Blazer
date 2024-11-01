using static BlazerTest.Components.Alert;

public class AlertService
{
	public event Action<string, AlertColorEnum> OnShow;

	public void Show(string message, AlertColorEnum alertColor)
	{
		OnShow?.Invoke(message, alertColor);
	}
}

public enum AlertColorEnum
{
	Success,
	Error,
	Info
}
