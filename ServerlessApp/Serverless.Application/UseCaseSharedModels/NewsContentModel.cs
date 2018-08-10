using Serverless.Domain.News;
using System;

namespace Serverless.Application.UseCaseSharedModels
{
	public class NewsContentModel
    {
		public NewsContentModel(NewsContent newsContent)
		{
			Id = newsContent.Id;
			Date = newsContent.Date;
			Time = newsContent.Time;
			CountryName = newsContent.CountryName;
			Title = newsContent.Title;
			Supplementation = newsContent.Supplementation;
			Important = newsContent.Important;
			ImportantLevel = newsContent.ImportantLevel;
			Ratio = newsContent.Ratio;
			Unit = newsContent.Unit;
			Period = newsContent.Period;
			Expectation = newsContent.Expectation;
			Result = newsContent.Result;
			LastTime = newsContent.LastTime;
			Correction = newsContent.Correction;
			Uid = newsContent.Uid;
		}

		public int Id { get; set; }
		public DateTime Date { get; set; }
		public DateTime Time { get; set; }
		public string CountryName { get; set; }         //TODO: is just a name?

		public string Title { get; set; }
		public string Supplementation { get; set; }

		public int Important { get; set; }				//TODO: should be enum
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
