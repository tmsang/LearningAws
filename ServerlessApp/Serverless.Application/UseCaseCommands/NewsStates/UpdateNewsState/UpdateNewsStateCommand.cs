namespace Serverless.Application.UseCaseCommands.NewsStates
{
	public class UpdateNewsStateCommand
    {
		public int Id { get; set; }
		public string Status { get; set; }
		public int NewsContentId { get; set; }
	}
}
