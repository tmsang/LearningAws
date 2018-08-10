namespace Serverless.Application.UseCaseCommands.News
{
	public class UpdateNewsCommand
    {
		public int Id { get; set; }
		public string CountryName { get; set; }         //TODO: is just a name?

		public string Title { get; set; }
		public string Supplementation { get; set; }

		public int Important { get; set; }              //TODO: should be enum
		public int ImportantLevel { get; set; }         //TODO: should be enum		

		public string Ratio { get; set; }               //TODO: should be enum
		public string Unit { get; set; }                //TODO: should be enum
		public string Period { get; set; }              //TODO: should be enum

		public double Expectation { get; set; }
		public double Result { get; set; }
		public double LastTime { get; set; }
		public double Correction { get; set; }

		public string Uid { get; set; }

	}
}
