using Serverless.Domain.News;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Serverless.Application.UseCaseSharedModels
{
	[XmlRoot("model")]
	public class NewsContainerModel
	{
		[XmlElement("contents")]
		public List<NewsContentModel> NewsContentModels { get; set; }
	}
	
	[XmlType("contents")]
	public class NewsContentModel
    {
		public NewsContentModel()
		{

		}

		public NewsContentModel(NewsContent newsContent)
		{
			Id = newsContent.Id;
			Date = newsContent.Date.ToString("yyyyMMdd");
			Time = newsContent.Time.ToString("HHmm");
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

		[XmlAttribute("id")]
		public int Id { get; set; }

		[XmlElement("date")]
		public string Date { get; set; }

		[XmlElement("time")]
		public string Time { get; set; }

		[XmlElement("country")]
		public string CountryName { get; set; }         //TODO: is just a name?

		[XmlElement("title")]
		public string Title { get; set; }

		[XmlElement("supplementation")]
		public string Supplementation { get; set; }

		[XmlElement("important")]
		public int Important { get; set; }              //TODO: should be enum

		[XmlElement("important_level")]
		public int ImportantLevel { get; set; }         //TODO: should be enum		

		[XmlElement("ratio")]
		public string Ratio { get; set; }               //TODO: should be enum

		[XmlElement("unit")]
		public string Unit { get; set; }                //TODO: should be enum

		[XmlElement("period")]
		public string Period { get; set; }              //TODO: should be enum

		[XmlElement("expect")]
		public double Expectation { get; set; }

		[XmlElement("result")]
		public double Result { get; set; }

		[XmlElement("lasttime")]
		public double LastTime { get; set; }

		[XmlElement("correction")]
		public double Correction { get; set; }

		[XmlElement("uid")]
		public string Uid { get; set; }
    }
}
